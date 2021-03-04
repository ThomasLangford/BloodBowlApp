using AutoMapper;
using BloodBowlAPI.Controllers;
using BloodBowlAPI.DTOs;
using BloodbowlData.Contexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using System;
using System.Threading.Tasks;
using System.Data.Common;
using Xunit;
using FluentAssertions;
using BloodBowlAPITests.Data;
using System.Linq;
using BloodbowlData.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace BloodBowlAPITests.Controllers
{
    public class SkillsControllerTests : IDisposable
    {

        private readonly DbConnection _connection;
        private readonly BloodBowlAPIContext _bloodBowlAPIContext;
        private readonly IMapper _mapper;

        private DbConnection connection;
        public SkillsControllerTests()
        {
            connection = CreateInMemoryDatabase();
            var options = new DbContextOptionsBuilder<BloodBowlAPIContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;
            _connection = RelationalOptionsExtension.Extract(options).Connection;

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DTOProfile());
            });

            this._mapper = mapperConfig.CreateMapper();

            Seed();
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => _connection.Dispose();

        private SkillsController CreateSkillsController()
        {
            var options = new DbContextOptionsBuilder<BloodBowlAPIContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;
            var bloodBowlAPIContext = new BloodBowlAPIContext(options);

            return new SkillsController(
                bloodBowlAPIContext,
                this._mapper);
        }

        private void Seed()
        {
            using (var bloodBowlAPIContext = new BloodBowlAPIContext(new DbContextOptionsBuilder<BloodBowlAPIContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options))
            {

                bloodBowlAPIContext.Database.EnsureDeleted();
                bloodBowlAPIContext.Database.EnsureCreated();

                var SkillCategory1 = new SkillCategory()
                {
                    Id = 1,
                    Name = "Skill Category 1"
                };

                bloodBowlAPIContext.SkillCategory.Add(SkillCategory1);

                bloodBowlAPIContext.Skill.Add(new Skill()
                {
                    Id = 1,
                    Name = "Skill 1",
                    Icon = "Icon 1",
                    SkillCategoryId = 1
                });

                //_bloodBowlAPIContext.Skill.Add(new Skill()
                //{
                //    Id = 2,
                //    Name = "Skill 2",
                //    Icon = "Icon 2",
                //    SkillCategoryId = 1,
                //    SkillCategory = SkillCategory1
                //});

                //_bloodBowlAPIContext.Skill.AddRange(SkillTestData.GetModels());

                bloodBowlAPIContext.SaveChanges();

            }                
        }

        [Fact]
        public async Task GetSkill_WhenNoSkills_ReturnEmptyList()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            // Act
            var result = await skillsController.GetSkill();

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeEmpty();
        }

        [Fact]
        public async Task GetSkill_WhenSkillsExist_ReturnSkillsDTO()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            var expected = SkillTestData.GetDTOs();

            // Act
            var result = await skillsController.GetSkill();

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetSkill_WhenNoSkillsExist_ReturnNull()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = 1;

            // Act
            var result = await skillsController.GetSkill(id);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeNull();
        }

        [Fact]
        public async Task GetSkill_WhenSkillIdDoesNotExist_ReturnNull()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = -1;

            // Act
            var result = await skillsController.GetSkill(id);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeNull();
        }

        [Fact]
        public async Task GetSkill_WhenSkillIdDoesExist_ReturnSkillDTO()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            int id = 1;
            var expected = SkillTestData.GetDTOs().First(d => d.Id == id);

            // Act
            var result = await skillsController.GetSkill(id);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task PutSkill_WhenSkillIdIsDifferntToTheId_ReturnBadRequestResult()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            int id = -1;
            SkillDTO skill = SkillTestData.GetDTOs().First(d => d.Id == 1);

            // Act
            // var result = await skillsController.PutSkill(id, skill);

            // Assert
            // result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task PutSkill_WhenSkillDoesNotExist_ReturnNotFoundResult()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            
            int id = -1;

            SkillDTO skill = SkillTestData.GetDTOs().First(d => d.Id == 1);
            skill.Id = id;

            // Act
            // var result = await skillsController.PutSkill(id, skill);

            // Assert
           //  result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public async Task PutSkill_WhenSkillDoesExist_ReturnNoContentResult()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            var skill1 = new Skill()
            {
                Id = 1,
                Name = "Skill 1",
                Icon = "Icon 1",
                SkillCategoryId = 1
            };

            //_bloodBowlAPIContext.Skill.Add(skill1);
            //_bloodBowlAPIContext.SaveChanges();

            int id = 1;

            // Act
            var result = await skillsController.PutSkill(skill1.Id, skill1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task PostSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            SkillDTO skill = null;

            // Act
            var result = await skillsController.PostSkill(
                skill);

            // Assert
            Assert.True(false);
            //this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = 0;

            // Act
            var result = await skillsController.DeleteSkill(
                id);

            // Assert
            Assert.True(false);
            //this.mockRepository.VerifyAll();
        }
    }
}

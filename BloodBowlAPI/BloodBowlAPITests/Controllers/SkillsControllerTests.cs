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
using System.Threading;
using System.Linq.Expressions;
using MockQueryable.Moq;
using System.Collections.Generic;
using Moq.EntityFrameworkCore;

namespace BloodBowlAPITests.Controllers
{
    public class SkillsControllerTests : ContextControllerTestBase<BloodBowlAPIContext>
    {
        private readonly IMapper _mapper;
        
        public SkillsControllerTests() : base()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DTOProfile());
            });

            this._mapper = mapperConfig.CreateMapper();
        }      

        private SkillsController CreateSkillsController()
        {
            return new SkillsController(
                GetDBContext(),
                this._mapper);
        }

        private void Seed()
        {
            using BloodBowlAPIContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.SkillCategory.AddRange(SkillTestData.GetSkillCategories());
            bloodBowlAPIContext.Skill.AddRange(SkillTestData.GetSkills());

            bloodBowlAPIContext.SaveChanges();
        }

        protected void ClearSeed()
        {
            using BloodBowlAPIContext bloodBowlAPIContext = GetDBContext();
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.SaveChanges();
        }

        [Fact]
        public async Task GetSkill_WhenNoSkills_ReturnEmptyList()
        {
            // Arrange
            ClearSeed();
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
            Seed();
            var skillsController = this.CreateSkillsController();

            var expected = SkillTestData.GetSkillDTOs();

            // Act
            var result = await skillsController.GetSkill();

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetSkill_WhenNoSkillsExist_ReturnNull()
        {
            // Arrange
            ClearSeed();
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
            Seed();
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
            Seed();
            var skillsController = this.CreateSkillsController();

            int id = 1;
            var expected = SkillTestData.GetSkillDTOs().First(d => d.Id == id);

            // Act
            var result = await skillsController.GetSkill(id);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task PutSkill_WhenSkillIdIsDifferntToTheId_ReturnBadRequestResult()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();

            SkillDTO skill = SkillTestData.GetSkillDTOs().First(d => d.Id == 1);

            // Act
            var result = await skillsController.PutSkill(skill.Id + 1, skill);

            // Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task PutSkill_WhenSkillDoesNotExist_ReturnNotFoundResult()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();

            SkillDTO skill = SkillTestData.GetExampleSkillDTOs().First();

            // Act
            var result = await skillsController.PutSkill(skill.Id, skill);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task PutSkill_WhenSkillExistsAndDbUpdateConcurrencyExceptionIsThrown_ThrowDbUpdateConcurrencyException()
        {
            // Arrange
            //Using Moq.EntityFrameworkCore
            var contextMock = new Mock<BloodBowlAPIContext>(new DbContextOptionsBuilder<BloodBowlAPIContext>().Options);
            IList<Skill> mockSkills = (IList<Skill>)SkillTestData.GetSkills();

            contextMock.Setup(x => x.Skill).ReturnsDbSet(mockSkills);
            contextMock.Setup(m => m.SaveChangesAsync(default))
                       .Throws(new DbUpdateConcurrencyException());

            var skillsController = new SkillsController(
                contextMock.Object,
                this._mapper);

            SkillDTO skill = SkillTestData.GetSkillDTOs().First(d => d.Id == 1);

            // Act
            Func<Task> act = async () => await skillsController.PutSkill(skill.Id, skill);

            // Assert
            await act.Should().ThrowAsync<DbUpdateConcurrencyException>();
        }


        [Fact]
        public async Task PutSkill_WhenSkillDoesExist_ReturnNoContentResult()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();

            var skillDto = SkillTestData.GetSkillDTOs().First();
            skillDto.Icon = "Test Icon";

            // Act
            var result = await skillsController.PutSkill(skillDto.Id, skillDto);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task PutSkill_WhenSkillDoesExist_ShouldUpdateRecordInDBContext()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();
            var skill = SkillTestData.GetSkills().First();
            var skillDto = SkillTestData.GetSkillDTOs().First(s => s.Id == skill.Id);

            skill.Icon = "Test Icon";
            skill.SkillCategory = SkillTestData.GetSkillCategories().First(s => s.Id == skill.SkillCategoryId);
            skillDto.Icon = "Test Icon";

            // Act
            var result = await skillsController.PutSkill(skillDto.Id, skillDto);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            GetDBContext().Skill.Where(s => s.Id == skill.Id).Include(s => s.SkillCategory).First().Should().BeEquivalentTo(skill, opt => opt.Excluding(p => p.SkillCategory.Skills));
        }

        [Fact]
        public async Task PostSkill_WhenSkillDoesNotExistAndIsValid_ReturnCreatedAtActionResult()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();

            var skill = SkillTestData.GetExampleSkills().First();
            var dto = SkillTestData.GetExampleSkillDTOs().First(s => s.Id == skill.Id);

            var expected = new CreatedAtActionResult("GetSkill", null, new { id = dto.Id }, dto);

            // Act
            var result = await skillsController.PostSkill(dto);

            // Assert
            result.Result.Should().BeOfType<CreatedAtActionResult>();
            var actionResult = (CreatedAtActionResult)result.Result;
            actionResult.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task PostSkill_WhenSkillDoesNotExistAndIsValid_ShouldAddRecordToDBContext()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();

            var skill = SkillTestData.GetExampleSkills().First();
            var dto = SkillTestData.GetExampleSkillDTOs().First(s => s.Id == skill.Id);

            // Act
            var result = await skillsController.PostSkill(dto);

            // Assert
            GetDBContext().Skill.Where(s => s.Id == skill.Id).Include(s => s.SkillCategory).First().Should().BeEquivalentTo(skill, opt => opt.Excluding(p => p.SkillCategory.Skills));
        }

        [Fact]
        public async Task PostSkill_WhenSkillDoesExistAndIsValid_ReturnConflictResult()
        {
            // Arrange
            Seed();
            var skillsController = this.CreateSkillsController();

            SkillDTO skill = new()
            {
                Id = SkillTestData.GetSkills().First().Id,
                Name = "Skill 2",
                Icon = "Icon 2",
                SkillCategoryId = 1,
                SkillCategoryName = "Skill Category 2",
                SkillCategoryShortName = 'S'
            };

            // Act
            var result = await skillsController.PostSkill(skill);

            // Assert
            result.Result.Should().BeOfType<ConflictResult>();
        }

        [Fact]
        public async Task DeleteSkill_WhenSkillExists_ReturnOKObjectResult()
        {
            Seed();
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = 1;

            var expected = new OkObjectResult(SkillTestData.GetSkillDTOs().First(dto => dto.Id == id));

            // Act
            var result = await skillsController.DeleteSkill(id);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
            var a = ((OkObjectResult)result.Result);
            a.Should().BeEquivalentTo(expected);
            GetDBContext().Skill.Should().NotContain(s => s.Id == id);
        }

        [Fact]
        public async Task DeleteSkill_WhenSkillExists_ShouldRemoveRecordFromDBContext()
        {
            Seed();
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = 1;

            var expected = new OkObjectResult(SkillTestData.GetSkillDTOs().First(dto => dto.Id == id));

            // Act
            var result = await skillsController.DeleteSkill(id);

            // Assert
            GetDBContext().Skill.Should().NotContain(s => s.Id == id);
        }

        [Fact]
        public async Task DeleteSkill_WhenSkillDoesNotExist_ReturnNotFoundResult()
        {
            Seed();
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = -1;

            // Act
            var result = await skillsController.DeleteSkill(id);

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}

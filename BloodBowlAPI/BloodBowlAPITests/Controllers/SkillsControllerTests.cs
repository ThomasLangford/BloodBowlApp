using AutoMapper;
using BloodBowlData.Contexts;
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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Linq.Expressions;
using MockQueryable.Moq;
using System.Collections.Generic;
using Moq.EntityFrameworkCore;
using BloodBowlData.Models.Skills;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Controllers.Skills;

namespace BloodBowlAPITests.Controllers
{
    public class SkillsControllerTests : ContextControllerTestBase<BloodBowlAPIContext>
    {
        private readonly IMapper _mapper;

        public SkillsControllerTests() : base()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SkillsDtoProfile());
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

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.RuleSet.AddRange(SkillTestData.GetRuleSets());
            bloodBowlAPIContext.SkillCategory.AddRange(SkillTestData.GetSkillCategories());
            bloodBowlAPIContext.Skill.AddRange(SkillTestData.GetSkills());

            bloodBowlAPIContext.SaveChanges();
        }

        protected void ClearSeed()
        {
            using BloodBowlAPIContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
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
            int id = 1000;

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

            int id = 1000;
            var expected = SkillTestData.GetSkillDTOs().First(d => d.Id == id);

            // Act
            var result = await skillsController.GetSkill(id);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }
    }
}

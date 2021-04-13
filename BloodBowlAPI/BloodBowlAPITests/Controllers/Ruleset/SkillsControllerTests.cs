using AutoMapper;
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
using BloodBowlAPITests.Mocks;
using BloodBowlAPI.Resources;
using BloodBowlAPITests.TestingClass;
using BloodBowlData.Contexts;
using BloodBowlAPI.Controllers.Ruleset;
using BloodBowlData.Enums;

namespace BloodBowlAPITests.Controllers.Ruleset
{
    public class SkillsControllerTests : DBContextTestBase<BloodBowlApiDbContext>
    {
        private readonly IMapper _mapper;
        private readonly LocalizerMock<Localization> _localizerMock;

        public SkillsControllerTests() : base()
        {
            _localizerMock = new LocalizerMock<Localization>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SkillsDtoProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        private SkillsController CreateController()
        {
            return new SkillsController(GetDBContext(), _mapper, _localizerMock.Object);
        }

        private void Seed()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.Ruleset.AddRange(RulesetTestData.GetRuleSets());
            bloodBowlAPIContext.SkillCategory.AddRange(SkillTestData.GetSkillCategories());
            bloodBowlAPIContext.Skill.AddRange(SkillTestData.GetSkills());

            bloodBowlAPIContext.SaveChanges();
        }

        [Fact]
        public async Task GetSkill_WhenNoSkillsForRuleset_ReturnEmptyList()
        {
            // Arrange
            Seed();
            var skillsController = CreateController();

            // Act
            var result = await skillsController.GetSkill(RulesetEnum.BloodBowl3);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeEmpty();
        }

        [Fact]
        public async Task GetSkill_WhenSkillsExist_ReturnSkillsDTO()
        {
            // Arrange
            Seed();
            var skillsController = CreateController();

            var expected = SkillTestData.GetSkillDTOs();

            // Act
            var result = await skillsController.GetSkill(RulesetEnum.BloodBowl2);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetSkill_WhenSkillIdDoesNotExist_ReturnNull()
        {
            // Arrange
            Seed();
            var skillsController = CreateController();
            int id = -1;

            // Act
            var result = await skillsController.GetSkill(id, RulesetEnum.BloodBowl2);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeNull();
        }

        [Fact]
        public async Task GetSkill_WhenSkillDoesNotExistForRuleset_ReturnNull()
        {
            // Arrange
            Seed();
            var skillsController = CreateController();
            int id = 1000;

            // Act
            var result = await skillsController.GetSkill(id, RulesetEnum.BloodBowl3);

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeNull();
        }

        [Fact]
        public async Task GetSkill_WhenSkillIdDoesExist_ReturnSkillDTO()
        {
            // Arrange
            Seed();
            var skillsController = CreateController();

            int id = 1000;
            var expected = SkillTestData.GetSkillDTOs().First(d => d.Id == id);

            // Act
            var result = await skillsController.GetSkill(id, RulesetEnum.BloodBowl2);

            // Assert
            result.Value.Should().BeEquivalentTo(expected);
        }
    }
}

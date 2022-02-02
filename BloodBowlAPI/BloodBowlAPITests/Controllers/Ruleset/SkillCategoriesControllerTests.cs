using AutoMapper;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Resources;
using BloodBowlAPI.Controllers.Ruleset;
using BloodBowlAPITests.Data;
using BloodBowlAPITests.Mocks;
using BloodBowlAPITests.TestingClass;
using BloodBowlData.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BloodBowlData.Enums;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc;

namespace BloodBowlAPITests.Controllers.Ruleset
{
    public class SkillCategoriesControllerTests : DBContextTestBase<BloodBowlApiDbContext>
    {
        private readonly IMapper _mapper;

        public SkillCategoriesControllerTests() : base()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient(sp => new LocalizerMock<Localization>().Object);
            services.AddAutoMapper(typeof(SkillsDtoProfile));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        private SkillCategoriesController CreateController()
        {
            return new SkillCategoriesController(GetDBContext(), _mapper, new LocalizerMock<Localization>().Object);
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
        public async Task GetSkillCategory_WhenAlways_ShouldReturnAllSkillCategoriesWithSkillsForCurrentRuleset()
        {
            Seed();
            var controller = CreateController();

            var skillCategories = await controller.GetSkillCategory(RulesetEnum.BloodBowl2);

            skillCategories.Should().NotBeNull();
            skillCategories.Value.Should().BeEquivalentTo(SkillTestData.GetSkillCategoryDTOs());
        }

        [Fact]
        public async Task GetSkillCategory_WhenSkillCategoryDoesNotExist_ShouldReturnNotFound()
        {
            Seed();
            var controller = CreateController();

            var skillCategories = await controller.GetSkillCategory(RulesetEnum.BloodBowl2, SkillCategoryEnum.Agility);

            skillCategories.Should().NotBeNull();
            skillCategories.Result.Should().BeEquivalentTo(new NotFoundResult());
        }

        [Fact]
        public async Task GetSkillCategory_WhenSkillCategoryDoesExist_ShouldReturnSkillCategoryWithSkillsForCurrentRuleset()
        {
            Seed();
            var controller = CreateController();

            var skillCategory = await controller.GetSkillCategory(RulesetEnum.BloodBowl2, SkillCategoryEnum.General);

            skillCategory.Should().NotBeNull();
            skillCategory.Value.Should().BeEquivalentTo(SkillTestData.GetSkillCategoryDTOs().First());
        }
    }
}

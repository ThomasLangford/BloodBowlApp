using AutoMapper;
using BloodBowlAPI.Controllers.Ruleset;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPI.Resources;
using BloodBowlAPITests.Data;
using BloodBowlAPITests.Mocks;
using BloodBowlAPITests.TestingClass;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BloodBowlAPITests.Controllers.Ruleset
{
    public class TeamTypesControllerTests : DBContextTestBase<BloodBowlApiDbContext>
    {
        private readonly IMapper _mapper;

        public TeamTypesControllerTests() : base()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient(sp => new LocalizerMock<Localization>().Object);
            services.AddAutoMapper(typeof(TeamTypesDtoProfile));

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        private TeamTypesController CreateController()
        {
            return new TeamTypesController(GetDBContext(), _mapper, new LocalizerMock<Localization>().Object);
        }

        private void Seed()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.Ruleset.AddRange(RulesetTestData.GetRuleSets());

            bloodBowlAPIContext.SkillCategory.AddRange(TeamTypesTestData.GetSkillCategories());
            bloodBowlAPIContext.Skill.AddRange(TeamTypesTestData.GetSkills());

            bloodBowlAPIContext.LevelUpType.AddRange(TeamTypesTestData.GetLevelUpTypes());

            bloodBowlAPIContext.TeamType.AddRange(TeamTypesTestData.GetTeamTypes());
            bloodBowlAPIContext.PlayerType.AddRange(TeamTypesTestData.GetPlayerTypes());

            bloodBowlAPIContext.StartingSkill.AddRange(TeamTypesTestData.GetStartingSkills());
            bloodBowlAPIContext.AvailableSkillCategory.AddRange(TeamTypesTestData.GetAvailableSkillCategories());

            bloodBowlAPIContext.SaveChanges();
        }

        [Fact]
        public async Task GetSkillCategory_WhenTeamTypesDoNotExistForRuleset_ShouldReturnNullResult()
        {
            Seed();
            var controller = CreateController();

            var skillCategories = await controller.GetTeamType(RulesetEnum.BloodBowl2020);

            skillCategories.Result.Should().BeNull();
            skillCategories.Value.Should().BeEmpty();
        }

        [Fact]
        public async Task GetSkillCategory_WhenTeamTypesExistForRuleset_ShouldReturnAllTeamTypesWithPlayerTypesForCurrentRuleset()
        {
            Seed();
            var controller = CreateController();

            var skillCategories = await controller.GetTeamType(RulesetEnum.BloodBowl2);

            skillCategories.Value.Should().BeEquivalentTo(new List<TeamTypeDto> { TeamTypesTestData.GetTeamTypeDto() });
        }

        //[Fact]
        //public async Task GetSkillCategory_WhenTeamTypeDoesNotExistForRuleset_ShouldNotFoundResult()
        //{
        //    Seed();
        //    var controller = CreateController();

        //    var skillCategories = await controller.GetTeamType(RulesetEnum.BloodBowl2020, 1000);

        //    skillCategories.Result.Should().BeEquivalentTo(new NotFoundResult());
        //    skillCategories.Value.Should().BeNull();
        //}

        //[Fact]
        //public async Task GetSkillCategory_WhenTeamTypeDoesNotExistForId_ShouldNotFoundResult()
        //{
        //    Seed();
        //    var controller = CreateController();

        //    var skillCategories = await controller.GetTeamType(RulesetEnum.BloodBowl2, -1);

        //    skillCategories.Result.Should().BeEquivalentTo(new NotFoundResult());
        //    skillCategories.Value.Should().BeNull();
        //}

        //[Fact]
        //public async Task GetSkillCategory_WhenTeamTypeDoesExist_ShouldTeamType()
        //{
        //    Seed();
        //    var controller = CreateController();

        //    var skillCategories = await controller.GetTeamType(RulesetEnum.BloodBowl2, 1000);

        //    skillCategories.Value.Should().BeEquivalentTo( TeamTypesTestData.GetTeamTypeDto() );
        //}
    }
}

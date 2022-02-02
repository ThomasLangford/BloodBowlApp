using AutoMapper;
using BloodBowlAPI.Controllers.Ruleset;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPI.Resources;
using BloodBowlAPITests.Data;
using BloodBowlAPITests.Mocks;
using BloodBowlAPITests.TestingClass;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BloodBowlAPITests.Controllers.Ruleset
{
    public class TeamTypesControllerTests : DBContextTestBase<BloodBowlApiDbContext>
    {
        private readonly IMapper _mapper;
        private readonly LocalizerMock<Localization> _localizerMock;

        public TeamTypesControllerTests() : base()
        {
            _localizerMock = new LocalizerMock<Localization>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TeamTypesDtoProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        private TeamTypesController CreateTeamTypesController()
        {
            return new TeamTypesController(GetDBContext(), this._mapper, this._localizerMock.Object);
        }

        private void Seed()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            AddDefaultTablesToContext(bloodBowlAPIContext);
            AddTeamTypeTablesToContext(bloodBowlAPIContext);

            bloodBowlAPIContext.SaveChanges();
        }

        private void SeedNoTeamTypes()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            AddDefaultTablesToContext(bloodBowlAPIContext);

            bloodBowlAPIContext.SaveChanges();
        }

        private void AddDefaultTablesToContext(BloodBowlApiDbContext bloodBowlApiDbContext)
        {

            bloodBowlApiDbContext.Ruleset.AddRange(RulesetTestData.GetRuleSets());
            bloodBowlApiDbContext.SkillCategory.AddRange(TeamTypeTestData.GetSkillCategories());
            bloodBowlApiDbContext.Skill.AddRange(TeamTypeTestData.GetSkills());
            bloodBowlApiDbContext.LevelUpType.AddRange(TeamTypeTestData.GetLevelUpTypes());
        }

        private void AddTeamTypeTablesToContext(BloodBowlApiDbContext bloodBowlApiDbContext)
        {
            bloodBowlApiDbContext.TeamType.AddRange(TeamTypeTestData.GetTeamTypes());
            bloodBowlApiDbContext.PlayerType.AddRange(TeamTypeTestData.GetPlayerTypes());
            bloodBowlApiDbContext.StartingSkill.AddRange(TeamTypeTestData.GetStartingSkills());
            bloodBowlApiDbContext.AvailableSkillCategory.AddRange(TeamTypeTestData.GetAvailableSkillCategories());
        }

        private void SeedEmpty()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.SaveChanges();
        }

        #region GetTeamType
        [Fact]
        public async Task GetTeamType_WhenNoTeamTypes_ReturnEmptyList()
        {
            // Arrange
            SeedEmpty();
            var teamTypesController = this.CreateTeamTypesController();
            RulesetEnum rulesetId = default;

            // Act
            var result = await teamTypesController.GetTeamType(rulesetId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<List<TeamTypeDto>>>();
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            (okResult.Value as List<TeamTypeDto>).Should().BeEmpty();
        }

        [Fact]
        public async Task GetTeamType_WhenTeamTypesExist_ReturnTeamTypeDtos()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2;

            // Act
            var result = await teamTypesController.GetTeamType(rulesetId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<List<TeamTypeDto>>>();
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            (okResult.Value as List<TeamTypeDto>).Should().BeEquivalentTo(TeamTypeTestData.GetTeamTypeDtos());
        }


        [Fact]
        public async Task GetTeamTypeById_WhenTeamTypeIdDoesNotExist_ReturnNotFoundResult()
        {
            // Arrange
            Seed();

            var teamTypesController = this.CreateTeamTypesController();
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2;
            int id = 1005;

            // Act
            var result = await teamTypesController.GetTeamTypeById(rulesetId, id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<TeamTypeDto>>();
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task GetTeamTypeById_WhenTeamTypeIdDoesExist_ReturnTeamTypeDto()
        {
            // Arrange
            Seed();

            var teamTypesController = this.CreateTeamTypesController();
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2;
            int id = 1000;

            // Act
            var result = await teamTypesController.GetTeamTypeById(rulesetId, id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<TeamTypeDto>>();
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            (okResult.Value as TeamTypeDto).Should().BeEquivalentTo(TeamTypeTestData.GetTeamTypeDto());
        }

        #endregion

        #region PutTeamType

        [Fact]
        public async Task PutTeamType_WhenTeamTypeDtoIsNull_ReturnBadRequest()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2;
            int id = 0;
            TeamTypeDto teamTypeDto = null;

            // Act
            var result = await teamTypesController.PutTeamType(rulesetId, id, teamTypeDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task PutTeamType_WhenTeamTypeDtoIdIsDifferentToId_ReturnBadRequest()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();
            int id = -1;
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2;
            TeamTypeDto teamTypeDto = TeamTypeTestData.GetTeamTypeDto();

            // Act
            var result = await teamTypesController.PutTeamType(rulesetId, id, teamTypeDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task PutTeamType_WhenTeamTypeDoesNotExistInRuleset_ReturnBadRequest()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();
            TeamTypeDto teamTypeDto = TeamTypeTestData.GetTeamTypeDto();
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2020;

            // Act
            var result = await teamTypesController.PutTeamType(rulesetId, teamTypeDto.Id, teamTypeDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task PutTeamType_WhenTeamTypeIdDoesNotExist_ReturnNotFound()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();
            TeamTypeDto teamTypeDto = TeamTypeTestData.GetTeamTypeDto();
            RulesetEnum rulesetId = RulesetEnum.BloodBowl2;

            int id = ++teamTypeDto.Id;

            // Act
            var result = await teamTypesController.PutTeamType(rulesetId, id, teamTypeDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task PutTeamType_WhenTeamTypeDtoIsValid_ShouldReturnNoContent()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();

            TeamTypeDto teamTypeDto = TeamTypeTestData.GetTeamTypeDto();

            // Act
            var result = await teamTypesController.PutTeamType(teamTypeDto.RulesetId, teamTypeDto.Id, teamTypeDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult>();
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task PutTeamType_WhenTeamTypeDtoHasChanged_ShouldUpdateRecordInContext()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();

            TeamTypeDto teamTypeDto = TeamTypeTestData.GetTeamTypeDto();

            teamTypeDto.Name = "Updated" + teamTypeDto.Name;
            teamTypeDto.Apothicary = false;
            teamTypeDto.Necromancer = true;

            var expected = TeamTypeTestData.GetTeamTypeWithChildren();
            expected.Name = teamTypeDto.Name;
            expected.Apothicary = teamTypeDto.Apothicary;
            expected.Necromancer = teamTypeDto.Necromancer;

            // Act
            await teamTypesController.PutTeamType(teamTypeDto.RulesetId, teamTypeDto.Id, teamTypeDto);
            var result = await this.GetDBContext().TeamType
                .Include(teamType => teamType.PlayerTypes)
                    .ThenInclude(playerType => playerType.AvailableSkillCategories)
                .Include(teamType => teamType.PlayerTypes)
                    .ThenInclude(playerType => playerType.StartingSkills)
                .AsNoTracking()
                .FirstOrDefaultAsync(tt => tt.Id == expected.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected, opt => opt.IgnoringCyclicReferences());
        }

        [Fact]
        public async Task PutTeamType_WhenTeamTypeDtoHasRemovedPlayerType_ShouldRemovePlayerTypeFromContext()
        {
            // Arrange
            Seed();
            var teamTypesController = this.CreateTeamTypesController();

            TeamTypeDto teamTypeDto = TeamTypeTestData.GetTeamTypeDto();

            teamTypeDto.PlayerTypes = teamTypeDto.PlayerTypes.Skip(1).ToList();

            var expected = TeamTypeTestData.GetTeamTypeWithChildren();
            expected.PlayerTypes = expected.PlayerTypes.Skip(1).ToList();

            // Act
            await teamTypesController.PutTeamType(teamTypeDto.RulesetId, teamTypeDto.Id, teamTypeDto);
            var result = await this.GetDBContext().TeamType
                .Include(teamType => teamType.PlayerTypes)
                    .ThenInclude(playerType => playerType.AvailableSkillCategories)
                .Include(teamType => teamType.PlayerTypes)
                    .ThenInclude(playerType => playerType.StartingSkills)
                .AsNoTracking()
                .FirstOrDefaultAsync(tt => tt.Id == expected.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected, opt => opt.IgnoringCyclicReferences());
        }

        #endregion

        #region PostTeamType
        [Fact]
        public async Task PostTeamType_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var teamTypesController = this.CreateTeamTypesController();
            TeamTypeDto teamTypeDto = null;
            RulesetEnum rulesetId = default;

            // Act
            var result = await teamTypesController.PostTeamType(
                rulesetId,
                teamTypeDto);

            // Assert
            Assert.True(false);
            this._localizerMock.VerifyAll();
        }
        #endregion

        #region DeletePlayerType
        [Fact]
        public async Task DeletePlayerType_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var teamTypesController = this.CreateTeamTypesController();
            int id = 0;
            RulesetEnum rulesetId = default;

            // Act
            var result = await teamTypesController.DeletePlayerType(
                rulesetId,
                id);

            // Assert
            Assert.True(false);
            this._localizerMock.VerifyAll();
        }
        #endregion
    }
}

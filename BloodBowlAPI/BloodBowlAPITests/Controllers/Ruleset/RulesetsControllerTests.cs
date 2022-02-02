using AutoMapper;
using BloodBowlAPI.Controllers.Ruleset;
using BloodBowlAPI.DTOs.Rules;
using BloodBowlAPI.Resources;
using BloodBowlAPITests.Data;
using BloodBowlAPITests.Mocks;
using BloodBowlAPITests.TestingClass;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using Microsoft.Extensions.Localization;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BloodBowlAPITests.Controllers.Ruleset
{
    public class RulesetsControllerTests : DBContextTestBase<BloodBowlApiDbContext>
    {
        private readonly IMapper _mapper;
        private readonly LocalizerMock<Localization> _localizerMock;

        public RulesetsControllerTests(): base()
        {
            _localizerMock = new LocalizerMock<Localization>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RulesDtoProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        private void Seed()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.Ruleset.AddRange(RulesetTestData.GetRuleSets());

            bloodBowlAPIContext.SaveChanges();
        }

        private void SeedEmpty()
        {
            using BloodBowlApiDbContext bloodBowlAPIContext = GetDBContext();

            bloodBowlAPIContext.DoNotSeedData = true;
            bloodBowlAPIContext.Database.EnsureDeleted();
            bloodBowlAPIContext.Database.EnsureCreated();

            bloodBowlAPIContext.SaveChanges();
        }

        private RulesetsController CreateRulesetsController()
        {
            return new RulesetsController(GetDBContext(), this._mapper, this._localizerMock.Object);
        }

        [Fact]
        public async Task Get_WhenRulesetsDontExist_ShouldReturnEmptyList()
        {
            // Arrange
            SeedEmpty();
            var rulesetsController = this.CreateRulesetsController();

            // Act
            var result = await rulesetsController.Get();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<List<RulesetDto>>>();            
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            (okResult.Value as List<RulesetDto>).Should().BeEmpty();
        }

        [Fact]
        public async Task Get_WhenRulesetsExist_ShouldReturnRulesetDTOs()
        {
            // Arrange
            Seed();
            var rulesetsController = this.CreateRulesetsController();

            // Act
            var result = await rulesetsController.Get();

            // Assert
            result.Should().BeAssignableTo<ActionResult<List<RulesetDto>>>();
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>();

            var okResult = result.Result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(RulesetTestData.GetRulesetDtos());
        }

        [Fact]
        public async Task Get_WhenRulesetDoesntExit_ShouldReturn404()
        {
            // Arrange
            SeedEmpty();
            var rulesetsController = this.CreateRulesetsController();
            RulesetEnum id = default;

            // Act
            var result = await rulesetsController.Get(id);

            // Assert
            result.Should().BeAssignableTo<ActionResult<RulesetDto>>();
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_WhenRulesetDoesExit_ShouldReturnRulesetDto()
        {
            // Arrange
            Seed();
            var rulesetsController = this.CreateRulesetsController();
            RulesetEnum id = RulesetEnum.BloodBowl2;

            // Act
            var result = await rulesetsController.Get(id);

            // Assert
            result.Should().BeAssignableTo<ActionResult<RulesetDto>>();
            result.Should().NotBeNull();
            result.Result.Should().BeOfType<OkObjectResult>();            

            var okResult = result.Result as OkObjectResult;
            (okResult.Value as RulesetDto).Should().BeEquivalentTo(RulesetTestData.GetRulesetDtos().First(dto => dto.Id == (int)id));
        }
    }
}

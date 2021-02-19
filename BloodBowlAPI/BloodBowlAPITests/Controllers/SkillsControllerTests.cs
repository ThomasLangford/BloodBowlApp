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

namespace BloodBowlAPITests.Controllers
{
    public class SkillsControllerTests
    {
        private MockRepository mockRepository;

        private Mock<BloodBowlAPIContext> mockBloodBowlAPIContext;

        private BloodBowlAPIContext bloodBowlAPIContext;
        private Mock<IMapper> mockMapper;

        public SkillsControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockBloodBowlAPIContext = this.mockRepository.Create<BloodBowlAPIContext>();
            this.mockMapper = this.mockRepository.Create<IMapper>();


            var optionsBuilder = new DbContextOptionsBuilder<BloodBowlAPIContext>()
                    .UseSqlite("Data Source=:memory:");

            this.bloodBowlAPIContext = new BloodBowlAPIContext(optionsBuilder.Options);
        }

        private SkillsController CreateSkillsController()
        {
            this.bloodBowlAPIContext.Database.EnsureDeleted();
            this.bloodBowlAPIContext.Database.EnsureCreated();

            return new SkillsController(
                this.bloodBowlAPIContext,
                this.mockMapper.Object);
        }

        [Fact]
        public async Task GetSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();

            this.bloodBowlAPIContext.Database.EnsureDeleted();
            this.bloodBowlAPIContext.Database.EnsureCreated();

            // Act
            var result = await skillsController.GetSkill();

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeEmpty();
        }

        [Fact]
        public async Task GetSkill_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = 0;

            // Act
            var result = await skillsController.GetSkill(
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task PutSkill_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var skillsController = this.CreateSkillsController();
            int id = 0;
            SkillDTO skill = null;

            // Act
            var result = await skillsController.PutSkill(
                id,
                skill);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
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
            this.mockRepository.VerifyAll();
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
            this.mockRepository.VerifyAll();
        }
    }
}

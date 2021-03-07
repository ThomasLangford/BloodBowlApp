﻿// <auto-generated />
using System;
using BloodBowlData.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodBowlMigrations.Migrations
{
    [DbContext(typeof(BloodBowlAPIContext))]
    partial class BloodBowlAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloodBowlData.Models.LevelUpType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LevelUpType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Normal"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Doubles"
                        });
                });

            modelBuilder.Entity("BloodBowlData.Models.PlayerLevelUpType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LevelUpTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LevelUpTypeId1")
                        .HasColumnType("int");

                    b.Property<int>("PlayerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("SkillCategoryId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LevelUpTypeId1");

                    b.HasIndex("PlayerTypeId");

                    b.HasIndex("SkillCategoryId1");

                    b.ToTable("AvailableSkillCategory");
                });

            modelBuilder.Entity("BloodBowlData.Models.PlayerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("ArmourValue")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("MaximumAllowedOnTeam")
                        .HasColumnType("int");

                    b.Property<int>("Move")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("TeamTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamTypeId");

                    b.ToTable("PlayerType");
                });

            modelBuilder.Entity("BloodBowlData.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SKillTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SKillTypeId");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("BloodBowlData.Models.SkillCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("SkillCategory");
                });

            modelBuilder.Entity("BloodBowlData.Models.SkillType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailableToBuy")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SkillType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 10,
                            Description = "Skill",
                            IsAvailableToBuy = true
                        },
                        new
                        {
                            Id = 2,
                            Description = "Extraordinary Skill",
                            IsAvailableToBuy = false
                        },
                        new
                        {
                            Id = 3,
                            Cost = 30,
                            Description = "Minor Stat-up",
                            IsAvailableToBuy = true
                        },
                        new
                        {
                            Id = 4,
                            Cost = 40,
                            Description = "Medium Stat-up",
                            IsAvailableToBuy = true
                        },
                        new
                        {
                            Id = 5,
                            Cost = 50,
                            Description = "Major Stat-up",
                            IsAvailableToBuy = true
                        });
                });

            modelBuilder.Entity("BloodBowlData.Models.StartingSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerTypeId");

                    b.HasIndex("SkillId");

                    b.ToTable("StartiingSkill");
                });

            modelBuilder.Entity("BloodBowlData.Models.TeamType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Apothicary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RerollCost")
                        .HasColumnType("int");

                    b.Property<int>("RerollMaximumCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TeamType");
                });

            modelBuilder.Entity("BloodBowlData.Models.PlayerLevelUpType", b =>
                {
                    b.HasOne("BloodBowlData.Models.LevelUpType", "LevelUpType")
                        .WithMany("AvailableSkillCategories")
                        .HasForeignKey("LevelUpTypeId1");

                    b.HasOne("BloodBowlData.Models.PlayerType", "PlayerType")
                        .WithMany("AvailableSkillCategories")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodBowlData.Models.SkillCategory", "SkillCategory")
                        .WithMany("AvailableSkillCategories")
                        .HasForeignKey("SkillCategoryId1");

                    b.Navigation("LevelUpType");

                    b.Navigation("PlayerType");

                    b.Navigation("SkillCategory");
                });

            modelBuilder.Entity("BloodBowlData.Models.PlayerType", b =>
                {
                    b.HasOne("BloodBowlData.Models.TeamType", "TeamType")
                        .WithMany("PlayerTypes")
                        .HasForeignKey("TeamTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamType");
                });

            modelBuilder.Entity("BloodBowlData.Models.Skill", b =>
                {
                    b.HasOne("BloodBowlData.Models.SkillType", "SkillType")
                        .WithMany("Skills")
                        .HasForeignKey("SKillTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodBowlData.Models.SkillCategory", "SkillCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SkillCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillCategory");

                    b.Navigation("SkillType");
                });

            modelBuilder.Entity("BloodBowlData.Models.StartingSkill", b =>
                {
                    b.HasOne("BloodBowlData.Models.PlayerType", "PlayerType")
                        .WithMany("StartingSkills")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodBowlData.Models.Skill", "Skill")
                        .WithMany("StartingSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerType");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("BloodBowlData.Models.LevelUpType", b =>
                {
                    b.Navigation("AvailableSkillCategories");
                });

            modelBuilder.Entity("BloodBowlData.Models.PlayerType", b =>
                {
                    b.Navigation("AvailableSkillCategories");

                    b.Navigation("StartingSkills");
                });

            modelBuilder.Entity("BloodBowlData.Models.Skill", b =>
                {
                    b.Navigation("StartingSkills");
                });

            modelBuilder.Entity("BloodBowlData.Models.SkillCategory", b =>
                {
                    b.Navigation("AvailableSkillCategories");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("BloodBowlData.Models.SkillType", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("BloodBowlData.Models.TeamType", b =>
                {
                    b.Navigation("PlayerTypes");
                });
#pragma warning restore 612, 618
        }
    }
}

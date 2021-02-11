﻿// <auto-generated />
using BloodbowlData.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodBowlMigrations.Migrations
{
    [DbContext(typeof(BloodBowlAPIContext))]
    [Migration("20210211034534_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("BloodbowlData.Models.AvailableSkillCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LevelUpTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LevelUpTypeId");

                    b.HasIndex("PlayerTypeId");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("AvailableSkillCategory");
                });

            modelBuilder.Entity("BloodbowlData.Models.LevelUpType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LevelUpType");
                });

            modelBuilder.Entity("BloodbowlData.Models.PlayerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

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
                        .HasColumnType("longtext");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("TeamTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamTypeId");

                    b.ToTable("PlayerType");
                });

            modelBuilder.Entity("BloodbowlData.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("SkillCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("BloodbowlData.Models.SkillCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.ToTable("SkillCategory");
                });

            modelBuilder.Entity("BloodbowlData.Models.StartingSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PlayerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerTypeId");

                    b.HasIndex("SkillId");

                    b.ToTable("StartiingSkill");
                });

            modelBuilder.Entity("BloodbowlData.Models.TeamType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Apothicary")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RerollCost")
                        .HasColumnType("int");

                    b.Property<int>("RerollMaximumCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TeamType");
                });

            modelBuilder.Entity("BloodbowlData.Models.AvailableSkillCategory", b =>
                {
                    b.HasOne("BloodbowlData.Models.LevelUpType", "LevelUpType")
                        .WithMany("AvailableSkillCategories")
                        .HasForeignKey("LevelUpTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodbowlData.Models.PlayerType", "PlayerType")
                        .WithMany("AvailableSkillCategories")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodbowlData.Models.SkillCategory", "SkillCategory")
                        .WithMany("AvailableSkillCategories")
                        .HasForeignKey("SkillCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LevelUpType");

                    b.Navigation("PlayerType");

                    b.Navigation("SkillCategory");
                });

            modelBuilder.Entity("BloodbowlData.Models.PlayerType", b =>
                {
                    b.HasOne("BloodbowlData.Models.TeamType", "TeamType")
                        .WithMany("PlayerTypes")
                        .HasForeignKey("TeamTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamType");
                });

            modelBuilder.Entity("BloodbowlData.Models.Skill", b =>
                {
                    b.HasOne("BloodbowlData.Models.SkillCategory", "SkillCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SkillCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillCategory");
                });

            modelBuilder.Entity("BloodbowlData.Models.StartingSkill", b =>
                {
                    b.HasOne("BloodbowlData.Models.PlayerType", "PlayerType")
                        .WithMany("StartingSkills")
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodbowlData.Models.Skill", "Skill")
                        .WithMany("StartingSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerType");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("BloodbowlData.Models.LevelUpType", b =>
                {
                    b.Navigation("AvailableSkillCategories");
                });

            modelBuilder.Entity("BloodbowlData.Models.PlayerType", b =>
                {
                    b.Navigation("AvailableSkillCategories");

                    b.Navigation("StartingSkills");
                });

            modelBuilder.Entity("BloodbowlData.Models.Skill", b =>
                {
                    b.Navigation("StartingSkills");
                });

            modelBuilder.Entity("BloodbowlData.Models.SkillCategory", b =>
                {
                    b.Navigation("AvailableSkillCategories");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("BloodbowlData.Models.TeamType", b =>
                {
                    b.Navigation("PlayerTypes");
                });
#pragma warning restore 612, 618
        }
    }
}

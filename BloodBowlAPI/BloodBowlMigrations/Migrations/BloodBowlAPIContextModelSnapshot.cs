﻿// <auto-generated />
using BloodbowlData.Contexts;
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

            modelBuilder.Entity("BloodbowlData.Models.AvailableSkillCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LevelUpType");
                });

            modelBuilder.Entity("BloodbowlData.Models.PlayerType", b =>
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

            modelBuilder.Entity("BloodbowlData.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("SkillCategory");
                });

            modelBuilder.Entity("BloodbowlData.Models.StartingSkill", b =>
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

            modelBuilder.Entity("BloodbowlData.Models.TeamType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Apothicary")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

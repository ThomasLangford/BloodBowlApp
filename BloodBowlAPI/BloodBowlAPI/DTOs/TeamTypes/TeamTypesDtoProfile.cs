﻿using AutoMapper;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Resources;
using BloodBowlData.Models.TeamTypes;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.TeamTypes
{
    public class TeamTypesDtoProfile : Profile
    {
        public TeamTypesDtoProfile()
        {
            IStringLocalizer<Localization> localizer = null;

            // Team Type
            CreateMap<TeamType, TeamTypeDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Name]));

            CreateMap<TeamTypeDto, TeamType>();

            // Player Type
            CreateMap<PlayerType, PlayerTypeDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Name]));

            CreateMap<PlayerTypeDto, PlayerType>();
                // .ForMember(d => d.StartingSkills, opt => opt.Ignore());

            // Available Skill Category
            CreateMap<AvailableSkillCategory, AvailableSkillCategoryDto>();
            CreateMap<AvailableSkillCategoryDto, AvailableSkillCategory>();

            CreateMap<LevelUpType, LevelUpTypeDto>().ReverseMap();

            // Starting Skill
            CreateMap<StartingSkill, SkillDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Skill.Id) )
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Skill.LocalizationName]))
                .ForMember(d => d.Description,opt => opt.MapFrom(s => localizer[s.Skill.LocalizationDescription]));

            CreateMap<SkillDto, StartingSkill>()
                .ForMember(d => d.SkillId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}

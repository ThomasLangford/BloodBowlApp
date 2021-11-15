using AutoMapper;
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

            // Available Skill Category
            CreateMap<AvailableSkillCategory, AvailableSkillCategoryDto>();
            CreateMap<AvailableSkillCategoryDto, AvailableSkillCategory>();

            // Starting Skill
            CreateMap<StartingSkill, SkillDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Skill.Id) )
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Skill.LocalizationName]))
                .ForMember(d => d.Description,opt => opt.MapFrom(s => localizer[s.Skill.LocalizationDescription]));
        }
    }
}

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
                .ForMember(d => d.RulesetName, opt => opt.MapFrom(s => localizer[s.RuleSet.LocalizationName]));
            // .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Name]));

            CreateMap<PlayerType, TeamTypeDto.TeamTypePlayerTypeDto>();
            // .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Name]));

            CreateMap<AvailableSkillCategory, TeamTypeDto.TeamTypePlayerTypeAvailableSkillCategoryDto>()
                .ForMember(d => d.SkillCategoryName, opt => opt.MapFrom(s => localizer[s.SkillCategory.LocalizationName]))
                .ForMember(d => d.SkillCategoryShortName, opt => opt.MapFrom(s => localizer[s.SkillCategory.LocalizationShortName]))
                .ForMember(d => d.LevelUpTypeName, opt => opt.MapFrom(s => localizer[s.LevelUpType.LocalizationName]));

            CreateMap<StartingSkill, TeamTypeDto.TeamTypePlayerTypeStartingSkillDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Skill.LocalizationName]))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => localizer[s.Skill.LocalizationDescription]));

            // Player Type
            CreateMap<PlayerType, PlayerTypeDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Name]));

            CreateMap<LevelUpType, LevelUpTypeDto>().ReverseMap();

            CreateMap<AvailableSkillCategory, AvailableSkillCategoryDto>().ReverseMap();
        }
    }
}

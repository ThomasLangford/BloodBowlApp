using AutoMapper;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlData.Models.TeamTypes;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBowlAPI.Resources;
using BloodBowlData.Models.Skills;

namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillsDtoProfile : Profile
    {
        public SkillsDtoProfile()
        {
            IStringLocalizer<Localization> localizer = null;
            CreateMap<Skill, SkillDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.LocalizationName]))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => localizer[s.LocalizationDescription]))
                .ForMember(d => d.SkillCategoryName, opt => opt.MapFrom(s => localizer[s.SkillCategory.LocalizationName]))
                .ForMember(d => d.SkillCategoryShortName, opt => opt.MapFrom(s => localizer[s.SkillCategory.LocalizationShortName]))
                .ForMember(d => d.RulesetName, opt => opt.MapFrom(s => localizer[s.RuleSet.LocalizationName]));

            CreateMap<Skill, SkillDtoSimple>()
                .ForMember(d => d.Name, opt => opt.MapFrom<TranslationResolver, string>(s => s.LocalizationName))
                .ForMember(d => d.Description, opt => opt.MapFrom<TranslationResolver, string>(s => s.LocalizationDescription));

            CreateMap<SkillCategory, SkillCategoryDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom<TranslationResolver, string>(s => s.LocalizationName))
                .ForMember(d => d.ShortName, opt => opt.MapFrom<TranslationResolver, string>(s => s.LocalizationShortName));
        }
    }
}

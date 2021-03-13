using AutoMapper;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPI.Models.Skills;
using BloodBowlAPI.Models.TeamTypes;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodBowlAPI.Resources;

namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillsDtoProfile : Profile
    {
        public SkillsDtoProfile()
        {
            IStringLocalizer<Localization> localizer = null;
            CreateMap<Skill, SkillDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.LocalizationName))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.LocalizationDescription))
                .ForMember(d => d.SkillCategoryName, opt => opt.MapFrom(s => s.SkillCategory.LocalizationName))
                .ForMember(d => d.SkillCategoryShortName, opt => opt.MapFrom(s => s.SkillCategory.LocalizationShortName))
                .AfterMap<SkillDtoTranslateAction>();

            CreateMap<SkillCategory, SkillCategoryDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.LocalizationName]))
                .ForMember(d => d.ShortName, opt => opt.MapFrom(s => localizer[s.LocalizationShortName]));
        }

        public class SkillDtoTranslateAction : IMappingAction<Skill, SkillDto>
        {
            private IStringLocalizer<Localization> _localization;

            public SkillDtoTranslateAction(IStringLocalizer<Localization> localization)
            {
                this._localization = localization;
            }
            public void Process(Skill source, SkillDto destination, ResolutionContext context)
            {
                destination.Name = _localization[source.LocalizationName];
                destination.Description = _localization[source.LocalizationDescription];
            }
        }
    }
}

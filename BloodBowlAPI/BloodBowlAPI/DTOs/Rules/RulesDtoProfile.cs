using AutoMapper;
using BloodBowlAPI.Resources;
using BloodBowlData.Models.Rules;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.Rules
{
    public class RulesDtoProfile : Profile
    {
        public RulesDtoProfile()
        {
            IStringLocalizer<Localization> localizer = null;
            CreateMap<Ruleset, RulesetDto>()
                .ForMember(d => d.Name , opt => opt.MapFrom(s => localizer[s.LocalizationName]));
        }
    }
}

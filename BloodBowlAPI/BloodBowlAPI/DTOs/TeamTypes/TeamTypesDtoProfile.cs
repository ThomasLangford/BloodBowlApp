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
            CreateMap<TeamType, TeamTypeDto>();
            // .ForMember(d => d.RulesetName, opt => opt.MapFrom(s => localizer[s.RuleSet.LocalizationName]));
            // .ForMember(d => d.Name, opt => opt.MapFrom(s => localizer[s.Name]));

            CreateMap<TeamTypeDto, TeamType>();
        }
    }
}

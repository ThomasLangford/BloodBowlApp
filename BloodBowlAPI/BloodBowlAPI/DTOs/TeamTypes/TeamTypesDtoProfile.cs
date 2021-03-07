using AutoMapper;
using BloodBowlData.Models.TeamTypes;
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
            CreateMap<PlayerType, PlayerTypeDto>().ReverseMap();
            CreateMap<TeamType, TeamTypeDto>().ReverseMap();
            CreateMap<LevelUpType, LevelUpTypeDto>().ReverseMap();
        }
    }
}

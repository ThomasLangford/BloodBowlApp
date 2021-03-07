using AutoMapper;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlData.Models.Skills;
using BloodBowlData.Models.TeamTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs.Skills
{
    public class SkillsDtoProfile : Profile
    {
        public SkillsDtoProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();

            CreateMap<SkillCategory, SkillCategoryDto>().ReverseMap();

            CreateMap<PlayerType, PlayerTypeDto>().ReverseMap();
            //CreateMap<PlayerTypeDTO, PlayerType>();

            CreateMap<TeamType, TeamTypeDto>().ReverseMap();
            //CreateMap<TeamTypeDTO, TeamType>();
            //
            CreateMap<LevelUpType, LevelUpTypeDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlAPI.Models.TeamTypes;
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
            CreateMap<PlayerType, PlayerTypeDto>();



            CreateMap<TeamType, TeamTypeDto>().ReverseMap();
            CreateMap<LevelUpType, LevelUpTypeDto>().ReverseMap();

            CreateMap<AvailableSkillCategory, AvailableSkillCategoryDto>().ReverseMap();

            CreateMap<StartingSkill, SkillDto>()
                .ConstructUsing((ct, crx) => crx.Mapper.Map<SkillDto>(ct.Skill));

            CreateMap<SkillDto, StartingSkill>()
                .ForMember(x => x.SkillId, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Skill, opt => opt.MapFrom(s => s));
        }
    }
}

using AutoMapper;
using BloodBowlData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Skill, SkillDto>().ReverseMap().ForPath(d => d.SkillCategory.Id, opt => opt.MapFrom(s => s.SkillCategoryId));

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

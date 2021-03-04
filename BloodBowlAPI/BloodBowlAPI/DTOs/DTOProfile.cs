using AutoMapper;
using BloodbowlData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.DTOs
{
    public class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<Skill, SkillDTO>().ReverseMap();

            CreateMap<SkillCategory, SkillCategoryDTO>().ReverseMap();

            CreateMap<PlayerType, PlayerTypeDTO>().ReverseMap();
            //CreateMap<PlayerTypeDTO, PlayerType>();

            CreateMap<TeamType, TeamTypeDTO>().ReverseMap();
            //CreateMap<TeamTypeDTO, TeamType>();            
        }
    }
}

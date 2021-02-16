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
            CreateMap<Skill, SkillDTO>();

            CreateMap<PlayerType, PlayerTypeDTO>();
            CreateMap<PlayerTypeDTO, PlayerType>();

            CreateMap<TeamType, TeamTypeDTO>();
            CreateMap<TeamTypeDTO, TeamType>();

            CreateMap<StartingSkill, SkillDTO>();
        }
    }
}

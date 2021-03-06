using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs;
using BloodBowlData.Contexts;
using BloodBowlData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeamTypesController : BasicCrudController<TeamType, TeamTypeDto>
    {
        public TeamTypesController(BloodBowlAPIContext context, IMapper mapper) : base (context, mapper)
        {
        }

        private IQueryable<TeamType> GetTeamTypeJoins()
        {
            return _context.TeamType
                .Include(team => team.PlayerTypes)
                .ThenInclude(player => player.AvailableSkillCategories)
                .ThenInclude(levelUpType => levelUpType.SkillCategory)
                .Include(team => team.PlayerTypes)
                .ThenInclude(player => player.StartingSkills)
                .ThenInclude(startingSkill => startingSkill.Skill);
        }

        protected override async Task<List<TeamTypeDto>> GetAllEntityDtos()
        {
            return await GetTeamTypeJoins()
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


        protected override async Task<bool> EntityExists(int id)
        {
            return await _context.TeamType.AnyAsync(e => e.Id == id);
        }

        protected override IQueryable<TeamType> FindEntityQueryable(int id)
        {
            return GetTeamTypeJoins().Where(s => s.Id == id);
        }

        protected override async Task<TeamType> FindEntity(int id)
        {
            return await FindEntityQueryable(id).FirstOrDefaultAsync();
        }

        protected override async Task<TeamTypeDto> FindEntityDto(int id)
        {
            return await FindEntityQueryable(id).ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider)
                                                    .FirstOrDefaultAsync();
        }
    }
}

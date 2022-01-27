using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPI.Resources;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using BloodBowlData.Models.TeamTypes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/Rulesets/{rulesetId}/[controller]")]
    [ApiController]
    public class TeamTypesController : ControllerBase
    {
        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Localization> _localization;

        public TeamTypesController(BloodBowlApiDbContext context, IMapper mapper, IStringLocalizer<Localization> localization)
        {
            _context = context;
            _mapper = mapper;
            _localization = localization;
        }

        [HttpGet]
        // GET: api/Rulesets/1/TeamTypes
        public async Task<ActionResult<IEnumerable<TeamTypeDto>>> GetTeamType(RulesetEnum rulesetId)
        {
            return await _context.TeamType.Where(teamType => teamType.RuleSetId == rulesetId)
                .AsNoTracking()
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .ToListAsync();
        }

        // GET: api/Rulesets/1/TeamTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamTypeDto>> GetTeamTypeById(RulesetEnum rulesetId, int id)
        {
            var teamType = await _context.TeamType.Where(teamType => teamType.Id == id && teamType.RuleSetId == rulesetId)
                .AsNoTracking()
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider, new { localizer = _localization }) // Project To Does The Includes                
                .SingleOrDefaultAsync();

            if (teamType == null)
            {
                return NotFound();
            }

            return teamType;
        }

        // PUT: api/Rulesets/1/TeamTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamType(int id, TeamTypeDto playerTypeDto)
        {
            var teamType = _mapper.Map<TeamType>(playerTypeDto);


            _context.SetModified(teamType);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await TeamTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlayerTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<PlayerTypeDto>> PostTeamType(TeamTypeDto teamTypeDto)
        {
            if (await TeamTypeExists(teamTypeDto.Id))
            {
                return Conflict();
            }

            var teamType = await MapTeamTypeDtoToTeamTypeAsync(teamTypeDto);

            _context.TeamType.Add(teamType);

            await _context.SaveChangesAsync();

            var newPlayerType = await FindTeamTypeDto(teamType.Id);

            return CreatedAtAction(nameof(GetTeamTypeById), new { rulesetId = newPlayerType.RulesetId, id = newPlayerType.Id }, newPlayerType);
        }

        // DELETE: api/PlayerTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerTypeDto>> DeletePlayerType(int id)
        {
            var teamType = await FindTeamType(id);
            if (teamType == null)
            {
                return NotFound();
            }

            _context.TeamType.Remove(teamType);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<TeamTypeDto>(teamType);

            return Ok(dto);
        }

        private async Task<TeamType> MapTeamTypeDtoToTeamTypeAsync(TeamTypeDto teamTypeDto)
        {
            var teamType = _mapper.Map<TeamType>(teamTypeDto);

            foreach(PlayerType playerType in teamType.PlayerTypes)
            {
                foreach(StartingSkill startingSkill in playerType.StartingSkills)
                {
                    startingSkill.PlayerType = playerType;
                    startingSkill.Skill = await _context.Skill.FirstAsync(skill => skill.Id == startingSkill.SkillId);
                }
            }

            return teamType;
        }

        private async Task<bool> TeamTypeExists(int id)
        {
            return await _context.TeamType.AnyAsync(e => e.Id == id);
        }

        private async Task<TeamTypeDto> FindTeamTypeDto(int id)
        {
            return await FindTeamTypeQueryable(id)
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .FirstOrDefaultAsync();
        }

        private Task<TeamType> FindTeamType(int id)
        {
            return FindTeamTypeQueryable(id).FirstOrDefaultAsync();
        }

        private IQueryable<TeamType> FindTeamTypeQueryable(int id)
        {
            return _context.TeamType
                .Where(s => s.Id == id)
                .Include(p => p.RuleSet)
                .Include(p => p.PlayerTypes);
        }
    }
}

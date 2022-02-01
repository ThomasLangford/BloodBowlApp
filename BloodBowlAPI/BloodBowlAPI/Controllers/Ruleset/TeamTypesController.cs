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
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET: api/Rulesets/1/TeamTypes
        public async Task<ActionResult<List<TeamTypeDto>>> GetTeamType(RulesetEnum rulesetId)
        {
            var result = await _context.TeamType.Where(teamType => teamType.RuleSetId == rulesetId)
                .AsNoTracking()
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .ToListAsync();

            return Ok(result);
        }

        // GET: api/Rulesets/1/TeamTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

            return Ok(teamType);
        }

        // PUT: api/Rulesets/1/TeamTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutTeamType(int id, TeamTypeDto teamTypeDto)
        {
            if (!await TeamTypeExists(id))
            {
                return NotFound();
            }

            var teamType = await MapTeamTypeDtoToTeamTypeAsync(teamTypeDto);

            var originalPlayerTypes = new List<PlayerType>(teamType.PlayerTypes);

            foreach (PlayerType playerType in teamType.PlayerTypes)
            {
                foreach(AvailableSkillCategory availableSkillCategory in playerType.AvailableSkillCategories)
                {
                    _context.Update(availableSkillCategory);
                    await _context.SaveChangesAsync();
                }

                var originalAvailableSkillCategories = new List<AvailableSkillCategory>(playerType.AvailableSkillCategories);

                var missingAvailableSkillCategories = (await _context.AvailableSkillCategory
                    .Where(asc => asc.PlayerTypeId == playerType.Id)
                    .ToArrayAsync())
                    .Except(originalAvailableSkillCategories);

                _context.AvailableSkillCategory.RemoveRange(missingAvailableSkillCategories);

                foreach(StartingSkill startingSkill in playerType.StartingSkills)
                {
                    _context.Update(startingSkill);
                    await _context.SaveChangesAsync();
                }

                var originalStartingSkills = new List<StartingSkill>(playerType.StartingSkills);

                var missingStartingSkills = (await _context.StartingSkill
                    .Where(ss => ss.PlayerTypeId == playerType.Id)
                    .ToArrayAsync())
                    .Except(originalStartingSkills);

                _context.StartingSkill.RemoveRange(missingStartingSkills);                

                _context.Update(playerType);
                await _context.SaveChangesAsync();
            }

            _context.Update(teamType);

            var missingStartingPlayerTypes = (await _context.PlayerType
                .Where(pt => pt.TeamTypeId == teamType.Id)
                .ToArrayAsync())
                .Except(originalPlayerTypes);

            _context.PlayerType.RemoveRange(missingStartingPlayerTypes);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await TeamTypeExistsNoTracking(id))
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
            if (await TeamTypeExistsNoTracking(teamTypeDto.Id))
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                playerType.TeamType = teamType;
                playerType.TeamTypeId = teamType.Id;

                foreach(StartingSkill startingSkill in playerType.StartingSkills)
                {
                    
                    startingSkill.PlayerType = playerType;
                    startingSkill.PlayerTypeId = playerType.Id;

                    startingSkill.Skill = await _context.Skill.AsNoTracking().FirstAsync(skill => skill.Id == startingSkill.SkillId);
                    startingSkill.SkillId = startingSkill.SkillId;
                }

                foreach(AvailableSkillCategory availableSkillCategory in playerType.AvailableSkillCategories)
                {
                    availableSkillCategory.PlayerType = playerType;
                    availableSkillCategory.PlayerTypeId = playerType.Id;

                    availableSkillCategory.LevelUpType = await _context.LevelUpType.AsNoTracking().FirstAsync(levelUpType => levelUpType.Id == availableSkillCategory.LevelUpTypeId);
                    availableSkillCategory.LevelUpTypeId = availableSkillCategory.LevelUpType.Id;

                    availableSkillCategory.SkillCategory = await _context.SkillCategory.AsNoTracking().FirstAsync(SkillCategory => SkillCategory.Id == availableSkillCategory.SkillCategoryId);
                    availableSkillCategory.SkillCategoryId = availableSkillCategory.SkillCategory.Id;
                }
            }

            return teamType;
        }

        private async Task<bool> TeamTypeExists(int id)
        {
            return await _context.TeamType.AnyAsync(e => e.Id == id);
        }

        private async Task<bool> TeamTypeExistsNoTracking(int id)
        {
            return await _context.TeamType.AsNoTracking().AnyAsync(e => e.Id == id);
        }

        private async Task<TeamTypeDto> FindTeamTypeDto(int id)
        {
            return await FindTeamTypeQueryable(id)
                .AsNoTracking()
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

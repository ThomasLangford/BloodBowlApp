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
        public async Task<IActionResult> PutTeamType(RulesetEnum rulesetId, int id, TeamTypeDto teamTypeDto)
        {
            if (teamTypeDto == null || rulesetId != teamTypeDto.RulesetId || id != teamTypeDto.Id)
            {
                return BadRequest();
            }

            if (!await TeamTypeExists(id))
            {
                return NotFound();
            }

            var teamType = await MapTeamTypeDtoToTeamTypeAsync(teamTypeDto);

            try
            {
                await UpdateTeamType(teamType);
            }
            catch (DbUpdateConcurrencyException ex)
            {

                if (!await TeamTypeExistsNoTracking(id))
                {
                    return NotFound();
                }
                else
                {
                    foreach (var entry in ex.Entries)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        Console.WriteLine(entry);
                    }

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
        public async Task<ActionResult<PlayerTypeDto>> PostTeamType(RulesetEnum rulesetId, TeamTypeDto teamTypeDto)
        {
            if(rulesetId != teamTypeDto.RulesetId)
            {
                return BadRequest();
            }

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerTypeDto>> DeletePlayerType(RulesetEnum rulesetId, int id)
        {

            var teamType = await FindTeamType(id);
            if (teamType == null)
            {
                return NotFound();
            }

            if (rulesetId != teamType.RuleSetId)
            {
                return BadRequest();
            }

            _context.TeamType.Remove(teamType);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TeamTypeDto>(teamType));
        }

        private async Task<TeamType> MapTeamTypeDtoToTeamTypeAsync(TeamTypeDto teamTypeDto)
        {
            var teamType = _mapper.Map<TeamType>(teamTypeDto);

            foreach(PlayerType playerType in teamType.PlayerTypes)
            {
                playerType.TeamType = teamType;
                playerType.TeamTypeId = teamType.Id;

                var existingStartingSkills = await _context.StartingSkill.Where(ss => ss.PlayerTypeId == playerType.Id).ToListAsync();

                for (var i = 0; i < playerType.StartingSkills.Count; i++)
                {
                    var startingSkill = playerType.StartingSkills[i];
                    var existingStartingSkill = existingStartingSkills.FirstOrDefault(ss => ss.SkillId == startingSkill.SkillId);

                    if (existingStartingSkill != null)
                    {
                        existingStartingSkill.PlayerType = playerType;
                        playerType.StartingSkills[i] = existingStartingSkill;
                    }
                    else
                    {
                        startingSkill.Id = 0;
                        startingSkill.PlayerTypeId = playerType.Id;
                        startingSkill.PlayerType = playerType;
                        // startingSkill.Skill = await _context.Skill.FirstAsync(skill => skill.Id == startingSkill.SkillId);
                    }
                }

                for (var i = 0; i < playerType.AvailableSkillCategories.Count; i++)
                {
                    var availableSkillCategory = playerType.AvailableSkillCategories[i];
                    var existingAvailableSkillCategory = availableSkillCategory.Id > 0 ? await _context.AvailableSkillCategory.FirstOrDefaultAsync(asc => asc.Id == availableSkillCategory.Id) : null;

                    if (existingAvailableSkillCategory != null)
                    {
                        
                        existingAvailableSkillCategory.PlayerTypeId = playerType.Id;
                        existingAvailableSkillCategory.PlayerType = playerType;
                        existingAvailableSkillCategory.SkillCategoryId = availableSkillCategory.SkillCategoryId;
                        existingAvailableSkillCategory.LevelUpTypeId = availableSkillCategory.LevelUpTypeId;

                        playerType.AvailableSkillCategories[i] = existingAvailableSkillCategory;
                    }
                    else
                    {
                        availableSkillCategory.Id = 0;
                        availableSkillCategory.PlayerTypeId = playerType.Id;
                        availableSkillCategory.PlayerType = playerType;
                        //availableSkillCategory.LevelUpType = await _context.LevelUpType.FirstAsync(levelUpType => levelUpType.Id == availableSkillCategory.LevelUpTypeId);
                        //availableSkillCategory.SkillCategory = await _context.SkillCategory.FirstAsync(SkillCategory => SkillCategory.Id == availableSkillCategory.SkillCategoryId);
                    }
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

        private async Task<int> UpdateTeamType(TeamType teamType)
        {
            await UpdatePlayerTypes(teamType);

            _context.Update(teamType);
            
            return await _context.SaveChangesAsync();
        }

        private async Task<int> UpdatePlayerTypes(TeamType teamType)
        {
            var originalPlayerTypes = new List<PlayerType>(teamType.PlayerTypes);

            foreach (PlayerType playerType in teamType.PlayerTypes)
            {
                await UpdateAvailableSkillCategories(playerType);
                await UpdateStartingSkills(playerType);

                _context.Update(playerType);
                await _context.SaveChangesAsync();
            }

            var missingStartingPlayerTypes = (await _context.PlayerType
                .Where(pt => pt.TeamTypeId == teamType.Id)
                .ToArrayAsync())
                .Except(originalPlayerTypes);

            _context.PlayerType.RemoveRange(missingStartingPlayerTypes);

            return await _context.SaveChangesAsync();
        }

        private async Task<int> UpdateAvailableSkillCategories(PlayerType playerType)
        {
            foreach (AvailableSkillCategory availableSkillCategory in playerType.AvailableSkillCategories)
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

            return await _context.SaveChangesAsync();
        }

        private async Task<int> UpdateStartingSkills(PlayerType playerType)
        {

            foreach (StartingSkill startingSkill in playerType.StartingSkills)
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

            return await _context.SaveChangesAsync();
        }
    }
}

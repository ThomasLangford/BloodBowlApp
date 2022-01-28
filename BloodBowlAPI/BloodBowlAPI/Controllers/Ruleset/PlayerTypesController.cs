using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using BloodBowlData.Models.TeamTypes;

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTypesController : ControllerBase
    {
        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;

        //ToDo  1. Validate that the player has a valid ruleset id
        //      2. Validate that the player has skill categories and skills and belongs to a team in the same ruleset
        //      3. Refactor PutPlayerType to see what is nessisary
        //      4. Write unit tests



        public PlayerTypesController(BloodBowlApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PlayerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerTypeDto>>> GetPlayerType()
        {
            return await GetAllPlayerTypes();
        }

        // GET: api/PlayerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerTypeDto>> GetPlayerType(int id)
        {
            var PlayerType = await FindPlayerTypeDto(id);

            if (PlayerType == null)
            {
                return NotFound();
            }

            return PlayerType;
        }

        // PUT: api/PlayerTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerType(int id, PlayerTypeDto playerTypeDto)
        {
            if (!await PlayerTypeExists(id))
            {
                return NotFound();
            }

            if (id != playerTypeDto.Id || !await ValidatePlayerTypeDto(playerTypeDto))
            {
                return BadRequest();
            }

            var playerType = _mapper.Map<PlayerType>(playerTypeDto);


            _context.Update(playerType);

            var existingStaringSkills = await _context.StartingSkill.Where(c => c.PlayerTypeId == playerType.Id).ToListAsync();

            // Delete Existing StaringSkill Records
            foreach (var existingStartingSkill in existingStaringSkills)
            {
                if (!playerType.StartingSkills.Exists(s => s.SkillId == existingStartingSkill.SkillId))
                {
                    _context.StartingSkill.Remove(existingStartingSkill);
                }
            }

            // Add Or Update mew StartingSkill Records
            foreach (var startingSkill in playerType.StartingSkills)
            {
                var existingStartingSkill = await _context.StartingSkill.FindAsync(startingSkill.Id);

                if (existingStartingSkill == null)
                {
                    await _context.StartingSkill.AddAsync(existingStartingSkill);
                }
                else
                {
                    existingStartingSkill.PlayerTypeId = playerType.Id;
                    existingStartingSkill.SkillId = startingSkill.SkillId;

                    _context.Update(existingStartingSkill);
                }
            }

            var existingAvailableSkillCategories = await _context.AvailableSkillCategory.Where(c => c.PlayerTypeId == playerType.Id).ToListAsync();

            // Delete Existing AvailableSkill Records
            foreach (var existingAvailableSkillCategory in existingAvailableSkillCategories)
            {
                if (!playerType.AvailableSkillCategories.Exists(s => s.Id == existingAvailableSkillCategory.Id))
                {
                    _context.AvailableSkillCategory.Remove(existingAvailableSkillCategory);
                }
            }

            // Delete Existing AvailableSkill Records
            foreach (var availableSkillCatagory in playerType.AvailableSkillCategories)
            {
                var existingAvailableSkillCategory = await _context.AvailableSkillCategory.FindAsync(availableSkillCatagory.Id);

                if (existingAvailableSkillCategory == null)
                {
                    _context.AvailableSkillCategory.Add(existingAvailableSkillCategory);
                }
                else
                {
                    existingAvailableSkillCategory.PlayerTypeId = playerType.Id;
                    existingAvailableSkillCategory.LevelUpTypeId = availableSkillCatagory.LevelUpTypeId;
                    existingAvailableSkillCategory.SkillCategoryId = availableSkillCatagory.SkillCategoryId;

                    _context.Update(existingAvailableSkillCategory);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await PlayerTypeExists(id))
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
        public async Task<ActionResult<PlayerTypeDto>> PostPlayerType(PlayerTypeDto playerTypeDto)
        {
            if (await PlayerTypeExists(playerTypeDto.Id))
            {
                return Conflict();
            }

            if (!await ValidatePlayerTypeDto(playerTypeDto))
            {
                return BadRequest();
            }



            var playerType = _mapper.Map<PlayerType>(playerTypeDto);

            foreach (var availableSkillCategory in playerType.AvailableSkillCategories)
            {
                availableSkillCategory.Id = 0;
            }

            foreach (var availableSkill in playerType.StartingSkills)
            {
                availableSkill.Id = 0;
            }

            _context.PlayerType.Add(playerType);

            await _context.SaveChangesAsync();

            var newPlayerType = await FindPlayerTypeDto(playerType.Id);

            return CreatedAtAction("GetPlayerType", new { id = newPlayerType.Id }, newPlayerType);
        }

        // DELETE: api/PlayerTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerTypeDto>> DeletePlayerType(int id)
        {
            var playerType = await FindPlayerType(id);
            if (playerType == null)
            {
                return NotFound();
            }

            _context.PlayerType.Remove(playerType);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<PlayerTypeDto>(playerType);

            return Ok(dto);
        }

        private async Task<List<PlayerTypeDto>> GetAllPlayerTypes()
        {
            return await _context.PlayerType
                .Include(p => p.StartingSkills)
                .Include(p => p.TeamType)
                .Include(p => p.AvailableSkillCategories)
                .ProjectTo<PlayerTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<bool> PlayerTypeExists(int id)
        {
            return await _context.PlayerType.AnyAsync(e => e.Id == id);
        }

        private IQueryable<PlayerType> FindPlayerTypeQueryable(int id)
        {
            return _context.PlayerType
                .Where(s => s.Id == id)
                .Include(p => p.StartingSkills)
                .Include(p => p.TeamType)
                .Include(p => p.AvailableSkillCategories);
        }

        private async Task<PlayerType> FindPlayerType(int id)
        {
            return await FindPlayerTypeQueryable(id).FirstOrDefaultAsync();
        }

        private async Task<PlayerTypeDto> FindPlayerTypeDto(int id)
        {
            return await FindPlayerTypeQueryable(id)
                .ProjectTo<PlayerTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> ValidatePlayerTypeDto(PlayerTypeDto playerTypeDto)
        {
            return ValidateAvailableSkillCategoryDtos(playerTypeDto.AvailableSkillCategories)
                && await ValidateSkillDtos(playerTypeDto.StartingSkills);
        }

        private static bool ValidateAvailableSkillCategoryDtos(List<AvailableSkillCategoryDto> availableSkillCategories)
        {
            foreach (var skillCategoryDto in availableSkillCategories)
            {
                // Check that they are valid enums
                if (!Enum.IsDefined(typeof(LevelUpTypeEnum), skillCategoryDto.LevelUpTypeId) || !Enum.IsDefined(typeof(SkillCategoryEnum), skillCategoryDto.SkillCategoryId))
                {
                    return false;
                }

                // Check that there are not duplicate skill categories
                if (availableSkillCategories.Where(x => x.SkillCategoryId == skillCategoryDto.SkillCategoryId).Count() > 1)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> ValidateSkillDtos(List<SkillDto> skillDtos)
        {
            foreach (var skillDto in skillDtos)
            {
                // Check Skill Exists
                if (!await _context.Skill.AnyAsync(s => s.Id == skillDto.Id))
                {
                    return false;
                }

                // Check Skill Isnt Duplicated
                if (skillDtos.Exists(s => s.Id == skillDto.Id && s != skillDto))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

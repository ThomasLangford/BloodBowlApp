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
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using BloodBowlData.Models.TeamTypes;

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/Rulesets/{rulesetId}/[controller]")]
    [ApiController]
    public class LevelUpTypesController : ControllerBase
    {
        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;

        public LevelUpTypesController(BloodBowlApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelUpTypeDto>>> GetLevelUpType()
        {
            return await GetLevelUpTypeDTOs();
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelUpTypeDto>> GetLevelUpType(LevelUpTypeEnum id)
        {
            var Skill = await GetLevelUpTypeDTO(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private async Task<List<LevelUpTypeDto>> GetLevelUpTypeDTOs()
        {
            return await _context.LevelUpType
                .AsNoTracking()
                .ProjectTo<LevelUpTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<LevelUpTypeDto> GetLevelUpTypeDTO(LevelUpTypeEnum id)
        {
            return await _context.LevelUpType
                .Where(s => s.Id == id)
                .AsNoTracking()
                .ProjectTo<LevelUpTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}

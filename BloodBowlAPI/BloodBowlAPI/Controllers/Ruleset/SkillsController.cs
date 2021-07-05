using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs.Skills;
using Microsoft.Extensions.Localization;
using BloodBowlAPI.Resources;
using BloodBowlData.Contexts;
using BloodBowlData.Models.Skills;
using BloodBowlData.Enums;

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/Rulesets/{rulesetId}/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Localization> _localization;

        public SkillsController(BloodBowlApiDbContext context, IMapper mapper, IStringLocalizer<Localization> localization)
        {
            _context = context;
            _mapper = mapper;
            _localization = localization;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkill(RulesetEnum rulesetId)
        {
            return await GetAllSkillDtos(rulesetId);
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto>> GetSkill(int id, RulesetEnum rulesetId)
        {
            var Skill = await FindSkillDto(id, rulesetId);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private async Task<List<SkillDto>> GetAllSkillDtos(RulesetEnum rulesetId)
        {
            return await _context.Skill
                //.Include(s => s.SkillCategory)
                //.Include(s => s.RuleSet)
                .Where(s => s.RuleSetId == rulesetId)
                .AsNoTracking()
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider, new { localizer = _localization }) // Project To Does The Includes
                .ToListAsync();
        }

        private async Task<SkillDto> FindSkillDto(int id, RulesetEnum rulesetId)
        {
            return await _context.Skill
                .Where(s => s.Id == id && s.RuleSetId == rulesetId)
                .AsNoTracking()
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .SingleOrDefaultAsync();
        }
    }
}

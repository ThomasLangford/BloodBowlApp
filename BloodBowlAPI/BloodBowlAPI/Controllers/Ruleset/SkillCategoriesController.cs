using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs.Skills;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using BloodBowlData.Models.Skills;
using Microsoft.Extensions.Localization;
using BloodBowlAPI.Resources;

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/Rulesets/{rulesetId}/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;

        public SkillCategoriesController(BloodBowlApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillCategoryDto>>> GetSkillCategory(RulesetEnum rulesetId)
        {
            return await GetSkillCategoryDTOs(rulesetId);
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillCategoryDto>> GetSkillCategory(RulesetEnum rulesetId, SkillCategoryEnum id)
        {
            var Skill = await GetSkillCategoryDTO(id, rulesetId);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private IQueryable<SkillCategory> GetSkillCatagoryQueryable(RulesetEnum rulesetId)
        {
            return _context.SkillCategory
                .Include(c => c.Skills.Where(s => s.RuleSetId == rulesetId))
                .AsNoTracking();
        }
        private async Task<List<SkillCategoryDto>> GetSkillCategoryDTOs(RulesetEnum rulesetId)
        {
            var categories = await GetSkillCatagoryQueryable(rulesetId)
                //.ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .ToListAsync();


            return categories.Select(c => _mapper.Map<SkillCategoryDto>(c)).ToList();
        }

        private async Task<SkillCategoryDto> GetSkillCategoryDTO(SkillCategoryEnum id, RulesetEnum rulesetId)
        {
            var category = await GetSkillCatagoryQueryable(rulesetId)
                .Where(c => c.Id == id)
                //.ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .FirstOrDefaultAsync();

            return _mapper.Map<SkillCategoryDto>(category);
        }
    }
}

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
using Microsoft.AspNetCore.Http;

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/Rulesets/{rulesetId}/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Localization> _localization;

        public SkillCategoriesController(BloodBowlApiDbContext context, IMapper mapper, IStringLocalizer<Localization> localization)
        {
            _context = context;
            _mapper = mapper;
            _localization = localization;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SkillCategoryDto>>> GetSkillCategory(RulesetEnum rulesetId)
        {
            return await GetSkillCategoryDTOs(rulesetId);
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                .Where(c => c.Skills.Any(s => s.RuleSetId == rulesetId))
                .AsNoTracking();
        }
        private async Task<List<SkillCategoryDto>> GetSkillCategoryDTOs(RulesetEnum rulesetId)
        {
            var categories = await GetSkillCatagoryQueryable(rulesetId)
                .ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider, new { localizer = _localization, rulset = rulesetId })
                .ToListAsync();


            return categories.Select(c => _mapper.Map<SkillCategoryDto>(c)).ToList();
        }

        private async Task<SkillCategoryDto> GetSkillCategoryDTO(SkillCategoryEnum id, RulesetEnum rulesetId)
        {
            var res = GetSkillCatagoryQueryable(rulesetId);

            var category = await res
                .Where(c => c.Id == id)
                .ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider, new { localizer = _localization, rulset = rulesetId })
                .FirstOrDefaultAsync();

            return _mapper.Map<SkillCategoryDto>(category);
        }
    }
}

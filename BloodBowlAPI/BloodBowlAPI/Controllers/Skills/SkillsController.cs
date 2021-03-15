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

namespace BloodBowlAPI.Controllers.Skills
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Localization> _localization;

        public SkillsController(BloodBowlAPIContext context, IMapper mapper, IStringLocalizer<Localization> localization)
        {
            _context = context;
            _mapper = mapper;
            _localization = localization;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkill()
        {
            return await GetAllSkillDtos();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto>> GetSkill(int id)
        {
            var Skill = await FindSkillDto(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private async Task<List<SkillDto>> GetAllSkillDtos()
        {
            return await _context.Skill
                .Include(s => s.SkillCategory)
                .Include(s => s.RuleSet)
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .ToListAsync();
        }

        private async Task<bool> SkillExists(int id)
        {
            return await _context.Skill.AnyAsync(e => e.Id == id);
        }

        private IQueryable<Skill> FindSkillQueryable(int id)
        {
            return _context.Skill
                .Where(s => s.Id == id)
                .Include(s => s.SkillCategory)
                .Include(s => s.RuleSet);
        }

        private async Task<SkillDto> FindSkillDto(int id)
        {
            return await FindSkillQueryable(id)
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .FirstOrDefaultAsync();
        }
    }
}

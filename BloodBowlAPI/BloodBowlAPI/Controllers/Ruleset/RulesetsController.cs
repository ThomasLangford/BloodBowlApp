using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs.Rules;
using BloodBowlAPI.Resources;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodBowlAPI.Controllers.Ruleset
{
    [Route("api/Rulesets")]
    [ApiController]
    public class RulesetsController : ControllerBase
    {

        private readonly BloodBowlApiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Localization> _localization;

        public RulesetsController(BloodBowlApiDbContext context, IMapper mapper, IStringLocalizer<Localization> localization)
        {
            _context = context;
            _mapper = mapper;
            _localization = localization;
        }

        // GET: api/<rulesets>
        [HttpGet]
        public async Task<ActionResult<List<RulesetDto>>> Get()
        {
            var rulesets = await _context.Ruleset.ProjectTo<RulesetDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .ToListAsync();

            return Ok(rulesets);
        }

        // GET api/rulesets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RulesetDto>> Get(RulesetEnum id)
        {
            var ruleset = await _context.Ruleset
                .Where(r => r.Id == id)
                .ProjectTo<RulesetDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .SingleOrDefaultAsync();

            if(ruleset == null)
            {
                return NotFound();
            }

            return Ok(ruleset);
        }
    }
}

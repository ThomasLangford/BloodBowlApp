using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs.TeamTypes;
using BloodBowlAPI.Resources;
using BloodBowlData.Contexts;
using BloodBowlData.Enums;
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
        public async Task<ActionResult<IEnumerable<TeamTypeDto>>> GetTeamType(RulesetEnum rulesetId)
        {
            return await _context.TeamType.Where(teamType => teamType.RuleSetId == rulesetId)
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider, new { localizer = _localization })
                .ToListAsync();
        }

        // GET: api/Rulesets/1/TeamTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamTypeDto>> GetTeamType(RulesetEnum rulesetId, int id)
        {
            var teamType = await _context.TeamType.Where(teamType => teamType.Id == id && teamType.RuleSetId == rulesetId)
                .ProjectTo<TeamTypeDto>(_mapper.ConfigurationProvider, new { localizer = _localization }) // Project To Does The Includes                
                .SingleOrDefaultAsync();

            if (teamType == null)
            {
                return NotFound();
            }

            return teamType;
        }
    }
}

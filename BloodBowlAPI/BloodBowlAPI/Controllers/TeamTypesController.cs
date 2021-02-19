using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodbowlData.Contexts;
using BloodbowlData.Models;
using BloodBowlAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BloodBowlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamTypesController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public TeamTypesController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TeamTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamTypeDTO>>> GetTeamType()
        {
            return await _context.TeamType.ProjectTo<TeamTypeDTO>(_mapper.ConfigurationProvider)
                                          .ToListAsync();
        }

        // GET: api/TeamTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamTypeDTO>> GetTeamType(int id)
        {
            var teamType = await _context.TeamType.Where(teamType => teamType.Id == id)
                                                  .ProjectTo<TeamTypeDTO>(_mapper.ConfigurationProvider)
                                                  .FirstOrDefaultAsync();

            if (teamType == null)
            {
                return NotFound();
            }

            return teamType;
        }

        // PUT: api/TeamTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamType(int id, TeamTypeDTO teamType)
        {
            if (id != teamType.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await TeamTypeExists(id))
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

        // POST: api/TeamTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TeamTypeDTO>> PostTeamType(TeamTypeDTO teamType)
        {
            _context.TeamType.Add(_mapper.Map<TeamType>(teamType));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamType", new { id = teamType.Id }, teamType);
        }

        // DELETE: api/TeamTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeamTypeDTO>> DeleteTeamType(int id)
        {
            var teamType = await _context.TeamType.FindAsync(id);
            if (teamType == null)
            {
                return NotFound();
            }

            _context.TeamType.Remove(teamType);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TeamTypeDTO>(teamType));
        }

        private Task<bool> TeamTypeExists(int id)
        {
            return _context.TeamType.AnyAsync(e => e.Id == id);
        }
    }
}

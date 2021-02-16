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

namespace BloodbowlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public SkillsController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TeamTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetTeamType()
        {
            return await _context.Skill.ProjectTo<SkillDTO>(_mapper.ConfigurationProvider)
                                          .ToListAsync();
        }

        // GET: api/TeamTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDTO>> GetTeamType(int id)
        {
            var teamType = await _context.Skill.Where(teamType => teamType.Id == id)
                                                  .ProjectTo<SkillDTO>(_mapper.ConfigurationProvider)
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
        public async Task<IActionResult> PutTeamType(int id, SkillDTO skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await SkillExists(id))
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
        public async Task<ActionResult<SkillDTO>> PostTeamType(SkillDTO skill)
        {
            _context.Skill.Add(_mapper.Map<Skill>(skill));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamType", new { id = skill.Id }, skill);
        }

        // DELETE: api/TeamTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SkillDTO>> DeleteTeamType(int id)
        {
            var skill = await _context.Skill.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<SkillDTO>(skill));
        }

        private Task<bool> SkillExists(int id)
        {
            return _context.Skill.AnyAsync(e => e.Id == id);
        }
    }
}

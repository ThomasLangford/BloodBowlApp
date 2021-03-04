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
    public class SkillsController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public SkillsController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkill()
        {
            return await _context.Skill.ProjectTo<SkillDTO>(_mapper.ConfigurationProvider)
                                          .ToListAsync();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDTO>> GetSkill(int id)
        {
            var Skill = await _context.Skill.Where(Skill => Skill.Id == id)
                                                  .ProjectTo<SkillDTO>(_mapper.ConfigurationProvider)
                                                  .FirstOrDefaultAsync();

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, Skill skill)//SkillDTO skillDto)
        {
            //var skill = _mapper.Map<Skill>(skillDto); 

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

        // POST: api/Skills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SkillDTO>> PostSkill(SkillDTO skill)
        {
            _context.Skill.Add(_mapper.Map<Skill>(skill));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SkillDTO>> DeleteSkill(int id)
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

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
            var Skill = await FindSkillDto(id);

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
        public async Task<IActionResult> PutSkill(int id, SkillDTO skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto); 

            if (id != skill.Id)
            {
                return BadRequest();
            }

            _context.SetModified(skill);

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
        public async Task<ActionResult<SkillDTO>> PostSkill(SkillDTO skillDto)
        {
            if (await SkillExists(skillDto.Id)) 
            {
                return Conflict();
            }

            var skill = _mapper.Map<Skill>(skillDto);
            
            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();

            var newSkill = await FindSkillDto(skill.Id);

            return CreatedAtAction("GetSkill", new { id = newSkill.Id }, newSkill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SkillDTO>> DeleteSkill(int id)
        {
            var skill = await FindSkill(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<SkillDTO>(skill);

            return Ok(dto);
        }

        private Task<bool> SkillExists(int id)
        {
            return _context.Skill.AnyAsync(e => e.Id == id);
        }

        private IQueryable<Skill> FindSkillQueryable(int id)
        {
            return _context.Skill.Where(s => s.Id == id).Include(s => s.SkillCategory);
        } 

        private Task<Skill> FindSkill(int id)
        {
            return FindSkillQueryable(id).FirstOrDefaultAsync();
        }

        private Task<SkillDTO> FindSkillDto(int id)
        {
            return FindSkillQueryable(id).ProjectTo<SkillDTO>(_mapper.ConfigurationProvider)
                                                    .FirstOrDefaultAsync();
        }
    }
}

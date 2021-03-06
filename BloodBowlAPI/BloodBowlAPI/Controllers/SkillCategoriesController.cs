using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBowlData.Contexts;
using BloodBowlData.Models;
using BloodBowlAPI.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BloodBowlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public SkillCategoriesController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillCategoryDto>>> GetSkillCategory()
        {
            return await _context.SkillCategory.ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillCategoryDto>> GetSkillCategory(int id)
        {
            var Skill = await FindSkillCategoryDTO(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillCategory(int id, SkillDto skillDto)
        {
            var skill = _mapper.Map<SkillCategory>(skillDto); 

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

        [HttpPost]
        public async Task<ActionResult<SkillCategoryDto>> PostSkillCategory(SkillCategoryDto skillCategoryDTO)
        {
            if (await SkillExists(skillCategoryDTO.Id)) 
            {
                return Conflict();
            }

            var skillCategory = _mapper.Map<SkillCategory>(skillCategoryDTO);
            
            _context.SkillCategory.Add(skillCategory);
            await _context.SaveChangesAsync();

            var newSkill = await FindSkillCategoryDTO(skillCategory.Id);

            return CreatedAtAction("GetSkill", new { id = newSkill.Id }, newSkill);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SkillCategoryDto>> DeleteSkillCategory(int id)
        {
            var skill = await FindSkillCategory(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.SkillCategory.Remove(skill);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<SkillCategoryDto>(skill);

            return Ok(dto);
        }

        private Task<bool> SkillExists(int id)
        {
            return _context.Skill.AnyAsync(e => e.Id == id);
        }

        private IQueryable<SkillCategory> FindSkillQueryable(int id)
        {
            return _context.SkillCategory.Where(s => s.Id == id).Include(s => s.Skills);
        } 

        private Task<SkillCategory> FindSkillCategory(int id)
        {
            return FindSkillQueryable(id).FirstOrDefaultAsync();
        }

        private Task<SkillCategoryDto> FindSkillCategoryDTO(int id)
        {
            return FindSkillQueryable(id).ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider)
                                                    .FirstOrDefaultAsync();
        }
    }
}

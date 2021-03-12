using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodBowlData.Contexts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlData.Models.Skills;
using BloodBowlAPI.DTOs.Skills;

namespace BloodBowlAPI.Controllers.Skills
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCatagoriesController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public SkillCatagoriesController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillCategoryDto>>> GetSkillCategory()
        {
            return await GetSkillCategoryDTOs();
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillCategoryDto>> GetSkillCategory(int id)
        {
            var Skill = await GetSkillCategoryDTO(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private IQueryable<SkillCategory> GetSkillCatagoryQueryable()
        {
            return _context.SkillCategory
                .Include(s => s.Skills);
        }

        private IQueryable<SkillCategory> GetSkillCatagoryQueryable(BloodBowlData.Enums.SkillCategoryEnum id)
        {


            return _context.SkillCategory
                .Where(s => s.Id == id)
                .Include(s => s.Skills);
        }

        private async Task<List<SkillCategoryDto>> GetSkillCategoryDTOs()
        {
            return await GetSkillCatagoryQueryable()
                .ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<SkillCategoryDto> GetSkillCategoryDTO(int id)
        {
            if (!Enum.IsDefined(typeof(BloodBowlData.Enums.SkillCategoryEnum), id))
            {
                return null;
            }

            var enumId = (BloodBowlData.Enums.SkillCategoryEnum)id;

            return await GetSkillCatagoryQueryable(enumId)
                .ProjectTo<SkillCategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}

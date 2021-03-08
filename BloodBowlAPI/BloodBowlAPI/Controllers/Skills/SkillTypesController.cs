using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class SkillTypesController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public SkillTypesController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillTypeDto>>> GetSkillType()
        {
            return await GetSkillTypeDTOs();
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillTypeDto>> GetSkillType(int id)
        {
            var Skill = await GetSkillTypeDTO(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private IQueryable<SkillType> GetSkillCatagoryQueryable()
        {
            return _context.SkillType
                .Include(s => s.Skills);
        }

        private IQueryable<SkillType> GetSkillCatagoryQueryable(BloodBowlData.Enums.SkillTypeEnum id)
        {


            return _context.SkillType
                .Where(s => s.Id == id)
                .Include(s => s.Skills);
        }

        private async Task<List<SkillTypeDto>> GetSkillTypeDTOs()
        {
            return await GetSkillCatagoryQueryable()
                .ProjectTo<SkillTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<SkillTypeDto> GetSkillTypeDTO(int id)
        {
            if (!Enum.IsDefined(typeof(BloodBowlData.Enums.SkillTypeEnum), id))
            {
                return null;
            }

            var enumId = (BloodBowlData.Enums.SkillTypeEnum)id;

            return await GetSkillCatagoryQueryable(enumId)
                .ProjectTo<SkillTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
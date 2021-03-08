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
using BloodBowlData.Models.TeamTypes;
using BloodBowlAPI.DTOs.TeamTypes;

namespace BloodBowlAPI.Controllers.TeamTypes
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelUpTypesController : ControllerBase
    {
        private readonly BloodBowlAPIContext _context;
        private readonly IMapper _mapper;

        public LevelUpTypesController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelUpTypeDto>>> GetLevelUpType()
        {
            return await GetLevelUpTypeDTOs();
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelUpTypeDto>> GetLevelUpType(int id)
        {
            var Skill = await GetLevelUpTypeDTO(id);

            if (Skill == null)
            {
                return NotFound();
            }

            return Skill;
        }

        private IQueryable<LevelUpType> GetSkillCatagoryQueryable(BloodBowlData.Enums.LevelUpTypeEnum id)
        {
            return _context.LevelUpType
                .Where(s => s.Id == id);
        }

        private async Task<List<LevelUpTypeDto>> GetLevelUpTypeDTOs()
        {
            return await _context.LevelUpType
                .ProjectTo<LevelUpTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        private async Task<LevelUpTypeDto> GetLevelUpTypeDTO(int id)
        {
            if (!Enum.IsDefined(typeof(BloodBowlData.Enums.LevelUpTypeEnum), id))
            {
                return null;
            }

            var enumId = (BloodBowlData.Enums.LevelUpTypeEnum)id;

            return await GetSkillCatagoryQueryable(enumId)
                .ProjectTo<LevelUpTypeDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using BloodBowlAPI.DTOs;
using BloodBowlData.Contexts;
using BloodBowlData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBowlAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public abstract class BasicCrudController<TEntity, TDto> : ControllerBase where TEntity : class, IDbModel, new() where TDto : class, IDto, new()
    {
        protected readonly BloodBowlAPIContext _context;
        protected readonly IMapper _mapper;

        public BasicCrudController(BloodBowlAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetEntity()
        {
            return await GetAllEntityDtos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetEntity(int id)
        {
            var model = await FindEntityDto(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnttity(int id, TDto dto)
        {
            var model = _mapper.Map<TDto>(dto);

            if (id != model.Id)
            {
                return BadRequest();
            }

            _context.SetModified(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await EntityExists(id))
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
        public async Task<ActionResult<TDto>> PostEntity(TDto dto)
        {
            if (await EntityExists(dto.Id))
            {
                return Conflict();
            }

            var model = _mapper.Map<TEntity>(dto);

            GetDbSet().Add(model);
            await _context.SaveChangesAsync();

            var newSkill = await FindEntityDto(model.Id);

            return CreatedAtAction("GetSkill", new { id = newSkill.Id }, newSkill);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TDto>> DeleteSkillCategory(int id)
        {
            var entity = await FindEntity(id);
            if (entity == null)
            {
                return NotFound();
            }

            GetDbSet().Remove(entity);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<TDto>(entity);

            return Ok(dto);
        }

        protected virtual async Task<List<TDto>> GetAllEntityDtos()
        {
            return await GetDbSet()
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        protected virtual async Task<bool> EntityExists(int id)
        {
            return await GetDbSet().AnyAsync(e => e.Id == id);
        }

        protected virtual IQueryable<TEntity> FindEntityQueryable(int id)
        {
            return GetDbSet().Where(s => s.Id == id);
        }

        protected virtual async Task<TEntity> FindEntity(int id)
        {
            return await FindEntityQueryable(id).FirstOrDefaultAsync();
        }

        protected virtual async Task<TDto> FindEntityDto(int id)
        {
            return await FindEntityQueryable(id).ProjectTo<TDto>(_mapper.ConfigurationProvider)
                                                    .FirstOrDefaultAsync();
        }

        protected virtual DbSet<TEntity> GetDbSet()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception e)
            {
                throw new Exception($"Could not retrieve DbSet of type: {typeof(TEntity).Name}. Threw: {e.Message}");
            }
        }
    }
}

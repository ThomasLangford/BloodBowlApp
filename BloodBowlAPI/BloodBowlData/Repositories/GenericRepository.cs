using BloodBowlData.Contexts;
using BloodBowlData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: ModelBase, new()
    {
        private readonly BloodBowlAPIContext _context;

        public GenericRepository(BloodBowlAPIContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> FirstForDefaultAsync(int Id)
        {
            return await GetDbSet().FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> ToListAsync()
        {
            return await GetDbSet().ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), $"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();

                return model;
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (await FirstForDefaultAsync(model.Id) == null)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"{nameof(model)} could not be saved: {e.Message}");
                }               
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), $"{nameof(AddAsync)} entity must not be null");
            }

            _context.SetModified(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (await FirstForDefaultAsync(model.Id) == null)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"{nameof(model)} could not be saved: {e.Message}");
                }
            }

            return model;
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var model = await FirstForDefaultAsync(id);
            if (model == null)
            {
                return 0;
            }

            GetDbSet().Remove(model);
            return await _context.SaveChangesAsync();
        }

        public virtual DbSet<TEntity> GetDbSet()
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

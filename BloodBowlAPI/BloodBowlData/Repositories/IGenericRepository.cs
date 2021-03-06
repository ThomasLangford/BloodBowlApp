using BloodBowlData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBowlData.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<List<TEntity>> ToListAsync();
        Task<TEntity> FirstForDefaultAsync(int Id);

        Task<TEntity> UpdateAsync(TEntity model);
        Task<TEntity> AddAsync(TEntity model);
        Task<int> DeleteAsync(int id);
    }
}

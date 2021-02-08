using System.Linq;
using System.Threading.Tasks;

namespace SemearApi.Repository.Configuration
{
    public interface  IRepositoryBase<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
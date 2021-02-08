using System;
using System.Linq;
using System.Threading.Tasks;

namespace SemearApi.Repository.Configuration
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected readonly SemearAppContext SemearAppContext;

        public RepositoryBase(SemearAppContext semearAppContext)
        {
            SemearAppContext = semearAppContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return SemearAppContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar entidades: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entidade não deve ser nula");
            }

            try
            {
                await SemearAppContext.AddAsync(entity);
                await SemearAppContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} não pôde ser salvo: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entidade não deve ser nula ");
            }

            try
            {
                SemearAppContext.Update(entity);
                await SemearAppContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} não pôde ser atualizado: {ex.Message}");
            }
        }
    }
}
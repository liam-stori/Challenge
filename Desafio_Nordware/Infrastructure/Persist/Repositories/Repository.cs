using App.Core.Interfaces;
using NHibernate.Linq;

namespace App.Infrastructure.Persist.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _session.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _session.Query<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    await _session.SaveAsync(entity);
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task RemoveAsync(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    await _session.DeleteAsync(entity);
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    await _session.UpdateAsync(entity);
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}

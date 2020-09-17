using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WaCo.MyTasks.DataAccess.Interfaces.Base;

namespace WaCo.MyTasks.DataAccess.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext Context;
        private readonly ILogger _logger;

        protected Repository(TContext context, ILogger logger)
        {
            Context = context;
            _logger = logger;
        }

        public void Add(TEntity model)
        {
            Context.Set<TEntity>().Add(model);
            _logger.LogDebug("Entry added {0}", model);
        }

        public void Update(TEntity model)
        {
            Context.Set<TEntity>().Update(model);
            _logger.LogDebug("Entry updated {0}", model);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public void Remove(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
            _logger.LogDebug("Entry removed {0}", model);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
            _logger.LogDebug("Changes saved to DB");
            Context.DetachAllEntities();
        }
    }
}

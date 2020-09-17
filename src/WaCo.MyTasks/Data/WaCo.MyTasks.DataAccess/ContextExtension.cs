using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WaCo.MyTasks.DataAccess
{
    public static class ContextExtension
    {

        // https://github.com/dotnet/efcore/issues/9118
        // https://stackoverflow.com/questions/27423059/how-do-i-clear-tracked-entities-in-entity-framework
        public static void DetachAllEntities(this DbContext context)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Detached)
                .ToList();

            foreach (var entry in entries)
            {
                if (entry.Entity != null)
                {
                    entry.State = EntityState.Detached;
                }
            }
        }
    }
}

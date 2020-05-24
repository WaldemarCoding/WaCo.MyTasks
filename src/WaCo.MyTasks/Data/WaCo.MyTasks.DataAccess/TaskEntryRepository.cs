using System.Linq;
using Microsoft.Extensions.Logging;
using WaCo.MyTasks.DataAccess.Repositories;
using WaCo.MyTasks.Models;

namespace WaCo.MyTasks.DataAccess
{
    public class TaskEntryRepository : Repository<TaskEntry, TaskContext>, ITaskEntryRepository
    {
        public TaskEntryRepository(TaskContext context, ILogger logger) : base(context, logger)
        {
        }
        
        public IQueryable<TaskEntry> Query => Context.TaskEntries.AsQueryable();
    }
}

using WaCo.MyTasks.DataAccess.Repositories;
using WaCo.MyTasks.Models;

namespace WaCo.MyTasks.DataAccess
{
    public interface ITaskEntryRepository : IRepository<TaskEntry>, IQueryableRepository<TaskEntry>
    {
    }
}

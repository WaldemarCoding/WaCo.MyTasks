using WaCo.MyTasks.DataAccess.Interfaces.Base;
using WaCo.MyTasks.Models;

namespace WaCo.MyTasks.DataAccess.Interfaces
{
    public interface ITaskEntryRepository : IRepository<TaskEntry>, IQueryableRepository<TaskEntry>
    {
    }
}

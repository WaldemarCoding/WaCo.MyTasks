using System.Linq;
using WaCo.MyTasks.Models;

namespace WaCo.MyTasks.Services.Interfaces
{

    public interface ITaskEntryService
    {
        IQueryable<TaskEntry> GetOpenEntries();
    }
}
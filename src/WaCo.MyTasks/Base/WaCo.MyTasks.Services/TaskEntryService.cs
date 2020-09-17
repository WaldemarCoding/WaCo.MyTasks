using System.Linq;
using Microsoft.EntityFrameworkCore;
using WaCo.MyTasks.DataAccess.Interfaces;
using WaCo.MyTasks.Models;
using WaCo.MyTasks.Services.Interfaces;

namespace WaCo.MyTasks.Services
{
    public class TaskEntryService : ITaskEntryService
    {
        private readonly ITaskEntryRepository _repository;

        public TaskEntryService(ITaskEntryRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<TaskEntry> GetOpenEntries() => _repository.Query.Where(t => t.FinishedDate == null).AsNoTracking();
    }
}

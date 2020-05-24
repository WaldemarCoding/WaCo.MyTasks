using System.Linq;

namespace WaCo.MyTasks.DataAccess.Repositories
{
    public interface IQueryableRepository<T>
    {
        IQueryable<T> Query { get; }
    }
}

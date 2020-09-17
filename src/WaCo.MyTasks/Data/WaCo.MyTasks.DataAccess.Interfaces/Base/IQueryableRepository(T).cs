using System.Linq;

namespace WaCo.MyTasks.DataAccess.Interfaces.Base
{
    public interface IQueryableRepository<T>
    {
        IQueryable<T> Query { get; }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace WaCo.MyTasks.DataAccess.Interfaces.Base
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Gets all entries.
        /// </summary>
        /// <returns>List of <see cref="T"/></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets a <see cref="T"/> entry by <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id of entry.</param>
        /// <returns>Entry if found, null if not</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Save Changes to Database.
        /// </summary>
        Task SaveAsync();

        /// <summary>
        /// Checks if there are tracked changes.
        /// </summary>
        /// <returns>true if yes, false otherwise</returns>
        bool HasChanges();

        /// <summary>
        /// Adds a <see cref="T"/> entry.
        /// </summary>
        /// <param name="model">Entry to add.</param>
        void Add(T model);

        /// <summary>
        /// Removes the provided entry by <paramref name="model"/> of type <see cref="T"/>
        /// </summary>
        /// <param name="model">Entry to remove.</param>
        void Remove(T model);
    }
}
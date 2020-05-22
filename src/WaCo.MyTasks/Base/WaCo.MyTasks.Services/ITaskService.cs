using System.Collections.Generic;
using WaCo.MyTasks.Core;

namespace WaCo.MyTasks.DataAccess
{
    /// <summary>
    /// Service to for operations on <see cref="TaskEntry"/> entries.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Creates a <see cref="TaskEntry"/> entry.
        /// </summary>
        /// <param name="task">Entry to be added.</param>
        void AddTask(TaskEntry task);

        /// <summary>
        /// Gets a <see cref="TaskEntry"/> entry by <paramref name="taskId"/>
        /// </summary>
        /// <param name="taskId">Id of entry.</param>
        /// <returns>Entry if found, null if not</returns>
        TaskEntry GetTask(int taskId);

        /// <summary>
        /// Updates the given <see cref="TaskEntry"/> entry.
        /// </summary>
        /// <param name="task">Task to update</param>
        void UpdateTask(TaskEntry task);

        /// <summary>
        /// Deletes a <see cref="TaskEntry"/> entry by <paramref name="taskId"/>
        /// </summary>
        /// <param name="taskId">Id of entry.</param>
        void DeleteTask(int taskId);

        /// <summary>
        /// Gets all entries.
        /// </summary>
        /// <returns>List of <see cref="TaskEntry"/></returns>
        List<TaskEntry> GetAllEntries();
    }
}
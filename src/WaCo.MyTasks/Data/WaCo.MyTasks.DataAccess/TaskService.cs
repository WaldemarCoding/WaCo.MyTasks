using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WaCo.MyTasks.Core;

namespace WaCo.MyTasks.DataAccess
{
    public class TaskService : ITaskService
    {
        private readonly Func<TaskContext> _taskContextCreator;

        public TaskService(Func<TaskContext> taskContextCreator)
        {
            _taskContextCreator = taskContextCreator;
        }

        public void AddTask(TaskEntry task)
        {
            using (var ctx = _taskContextCreator())
            {
                ctx.TaskEntries.Add(task);
                ctx.SaveChanges();
            }
        }

        public TaskEntry GetTask(int taskId)
        {
            TaskEntry retVal;

            using (var ctx = _taskContextCreator())
            {
                retVal = ctx.TaskEntries.AsNoTracking().FirstOrDefault(t => t.Id == taskId);
            }

            return retVal;
        }

        public void UpdateTask(TaskEntry task)
        {
            using (var ctx = _taskContextCreator())
            {
                ctx.TaskEntries.Update(task);
                ctx.SaveChanges();
            }
        }

        public void DeleteTask(int taskId)
        {
            using (var ctx = _taskContextCreator())
            {
                var entry = ctx.TaskEntries.First(t => t.Id == taskId);
                ctx.TaskEntries.Remove(entry);
                ctx.SaveChanges();
            }
        }

        public List<TaskEntry> GetAllEntries()
        {
            using (var ctx = _taskContextCreator())
            {
                return ctx.TaskEntries.AsNoTracking().ToList();
            }
        }
    }
}

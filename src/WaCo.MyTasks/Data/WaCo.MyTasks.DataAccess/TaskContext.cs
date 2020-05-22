using Microsoft.EntityFrameworkCore;
using WaCo.MyTasks.Core;

namespace WaCo.MyTasks.DataAccess
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskEntry> TaskEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=WaCo.EFMyTasksDB.db");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WaCo.MyTasks.Models;

namespace WaCo.MyTasks.DataAccess
{
    public class TaskContext : DbContext
    {
        public static readonly ILoggerFactory WaCoLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Debug)
                .AddFile("Logs/logfile-{Date}.log", 
                    outputTemplate: "{Timestamp:o} {RequestId,13} [{Level:u3}] {Message:l} ({EventId:x8}){NewLine}{Exception}");
        });

        public DbSet<TaskEntry> TaskEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(WaCoLoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
                .UseSqlite("Data Source=WaCo.EFMyTasksDB.db");
        }
    }
}

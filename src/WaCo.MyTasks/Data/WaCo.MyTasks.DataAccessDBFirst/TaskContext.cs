using Microsoft.EntityFrameworkCore;

namespace WaCo.MyTasks.DataAccessDBFirst
{
    public partial class TaskContext : DbContext
    {
        public TaskContext()
        {
        }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskEntries> TaskEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite(@"Datasource=C:\DEV\PC183\WF\WaCo.MyTasks\src\WaCo.MyTasks\DataAccess\WaCo.MyTasks.DataAccessDBFirst\WaCo.EFMyTasksDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntries>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).IsRequired();

                entity.Property(e => e.DeadlineDate).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Priority).IsRequired();

                entity.Property(e => e.StartDate).IsRequired();

                entity.Property(e => e.Titel).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

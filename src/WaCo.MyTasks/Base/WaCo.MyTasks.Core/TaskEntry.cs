using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaCo.MyTasks.Core
{
    public class TaskEntry
    {
        public TaskEntry(string titel, string description, TaskPriority priority, DateTime startDate,
            DateTime deadlineDate)
        {
            Titel = titel;
            Description = description;
            Priority = priority.ToString();
            StartDate = startDate;
            DeadlineDate = deadlineDate;

            CreatedDate = DateTime.Now;
        }

        public TaskEntry()
        {

        }

        public int Id { get; set; }
        [Required] 
        public string Titel { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required] 
        public string Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadlineDate { get; set; }

        [NotMapped]
        public TaskPriority PriorityName => (TaskPriority)Enum.Parse(typeof(TaskPriority), Priority);
    }
}

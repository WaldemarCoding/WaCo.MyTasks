namespace WaCo.MyTasks.DataAccessDBFirst
{
    public partial class TaskEntries
    {
        public long Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string StartDate { get; set; }
        public string FinishedDate { get; set; }
        public string CreatedDate { get; set; }
        public string DeadlineDate { get; set; }
    }
}

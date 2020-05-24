using System;

namespace WaCo.MyTasks.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
    }
}

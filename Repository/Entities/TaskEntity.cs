using Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Task")]
    public class TaskEntity : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskEntityId { get; set; }
        public string TaskName { get; set; }
        public DateTime When { get; set; }
        public TaskStatus Status { get; set; }
    }
}

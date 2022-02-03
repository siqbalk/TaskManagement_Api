using System;
using System.Threading.Tasks;

namespace Common.DTO
{
    public  class TaskDto
    {
        public int TaskEntityId { get; set; }
        public string  TaskName { get; set; }
        public DateTime When { get; set; }
        public TaskStatus Status { get; set; }
    }
}

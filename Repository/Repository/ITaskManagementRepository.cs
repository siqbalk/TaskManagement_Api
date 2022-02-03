using Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface ITaskManagementRepository
    {
        Task<TaskDto> AddUpdateTask(TaskDto taskDto);
        Task<List<TaskDto>> GetAllTask();
        Task<TaskDto> GetTask(int? Id);
        Task DeleteTask(int id);
    }
}
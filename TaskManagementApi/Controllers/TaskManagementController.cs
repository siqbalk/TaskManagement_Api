using Common.DTO;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : BaseController
    {
        private ITaskManagementRepository _taskManagementRepository;

        public TaskManagementController(ITaskManagementRepository  taskManagementRepository)
        {
            _taskManagementRepository = taskManagementRepository;
        }


        [HttpPost("addUpdate")]
        public async Task<ApiResponseDto> AddUpdateTask(TaskDto  taskDto)
        {
            await _taskManagementRepository.AddUpdateTask(taskDto);
            return ApiOkResult($"Task ${(taskDto.TaskEntityId > 0 ? "updated" : "added")} successfully");
        }


        [HttpGet("taskList")]
        public async Task<ApiResponseDto> GetTasList()
        {
            return ApiOkResult(await _taskManagementRepository.GetAllTask());
        }

        [HttpGet("task")]
        public async Task<ApiResponseDto> GetTask(int id)
        {
            return ApiOkResult(await _taskManagementRepository.GetTask(id));
        }


        [HttpDelete("DeleteTask")]
        public async Task<ApiResponseDto> DeleteFolder(int Id)
        {
            await _taskManagementRepository.DeleteTask(Id);
            return ApiOkResult(true);
        }
    }
}

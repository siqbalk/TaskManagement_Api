using Common.DTO;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class TaskManagementRepository : ITaskManagementRepository

    {
        private IBaseRespository<TaskEntity> _respository;

        public TaskManagementRepository(IBaseRespository<TaskEntity> respository)
        {
            _respository = respository;
        }
        public async Task<TaskDto> AddUpdateTask(TaskDto taskDto)
        {
            if (taskDto.TaskEntityId == 0)
            {
                var _task = new TaskEntity
                {
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false,
                    TaskName = taskDto.TaskName,
                    When = DateTime.UtcNow,
                    Status = Common.Enums.TaskStatus.Active
                };
                _respository.Add(_task);
                return new TaskDto { TaskEntityId = _task.TaskEntityId, TaskName = taskDto.TaskName };
            }
            var task = await _respository.Get(taskDto.TaskEntityId);

            if (task != null)
            {
                task.UpdatedDate = DateTime.UtcNow;
                task.TaskName = taskDto.TaskName;
                task.Status = Common.Enums.TaskStatus.Active;
            }

            _respository.Update(task);
            return new TaskDto { TaskEntityId = task.TaskEntityId, TaskName = taskDto.TaskName };


        }
        public async Task<List<TaskDto>> GetAllTask()
        {
            return await _respository.GetAll().Select(x => new TaskDto
            {
                TaskEntityId = x.TaskEntityId,
                TaskName = x.TaskName,
                Status = (TaskStatus)x.Status,
                When = x.When

            }).ToListAsync();
        }

        public async Task<TaskDto> GetTask(int? Id)
        {
            var CaseResult = await _respository.GetAll().Where(x => x.TaskEntityId == Id).FirstOrDefaultAsync();
            if (CaseResult == null)
                return new TaskDto();

            TaskDto taskDto = new TaskDto()
            {
                TaskEntityId = CaseResult.TaskEntityId,
                TaskName = CaseResult.TaskName,
                Status = (TaskStatus)CaseResult.Status,
                When = CaseResult.When
            };

            return taskDto;
        }

        public async Task DeleteTask(int id)
        {
                await _respository.Delete(id);
        }


    }
}

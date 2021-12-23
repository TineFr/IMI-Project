using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        protected readonly IDailyTaskRepository _dailyTaskRepository;
        protected readonly ICageRepository _cageRepository;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository, 
                                ICageRepository cageRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
            _cageRepository = cageRepository;
            _cageRepository = cageRepository;
        }

        public async Task<DailyTaskResponseDto> GetDailyTaskByIdAsync(Guid id)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(id);
            if (task == null)
            {
                throw new BadRequestException($"Daily task with id {id} does not exist");
            }
            DailyTaskResponseDto result = task.MapToDto();
            return result;
        }

        public async Task<DailyTaskResponseDto> AddDailyTaskAsync(DailyTaskRequestDto dto)
        {
            await ValidateRequest(dto);
            var dailyTaskEntity = dto.MapToEntity();
            var result = await _dailyTaskRepository.AddAsync(dailyTaskEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task<DailyTaskResponseDto> UpdateDailyTaskAsync(Guid id, DailyTaskRequestDto dto)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(id);
            if (task == null)
            {
                throw new BadRequestException($"Bird with id {id} does not exist");
            }
            await ValidateRequest(dto);
            var updatedTaskEntity = task.Update(dto);
            var result = await _dailyTaskRepository.UpdateAsync(updatedTaskEntity);
            var resultDto = result.MapToDto();
            return resultDto;
        }

        public async Task DeleteDailyTaskAsync(Guid id)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(id);
            if (task == null)
            {
                throw new BadRequestException($"Task with id {id} does not exist");
            }
            await _dailyTaskRepository.DeleteAsync(task);
        }















        public async Task<IEnumerable<DailyTask>> GetDailyTasksByCageIdAsync(Guid id)
        {
            var tasks = await _dailyTaskRepository.GetByCageIdAsync(id);
            return tasks;
        }

        public async Task<IEnumerable<DailyTask>> ListAllDailyTasksAsync()
        {
            var tasks = await _dailyTaskRepository.ListAllAsync();
            return tasks;
        }





        private async Task ValidateRequest(DailyTaskRequestDto dto)
        {
            var cage = await _cageRepository.GetByIdAsync( dto.CageId);
            if (cage == null)
            {
                throw new ItemNotFoundException($"Cage with id {dto.CageId} does not exist");
            }
        }
    }
}

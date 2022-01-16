using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Entities.Pagination;
using Imi.Project.Api.Core.Exceptions;
using Imi.Project.Api.Core.Helper;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<DailyTaskResponseDto>> ListAllDailyTasksAsync(PaginationParameters parameters)
        {
            var tasks = await _dailyTaskRepository.ListAllAsync();
            if (tasks.Count() == 0)
            {
                throw new ItemNotFoundException($"No tasks were found");
            }
            var tasksPaginated = Pagination.AddPagination<DailyTask>(tasks, parameters);
            var result = tasksPaginated.MapToDtoList();
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
        public async Task<IEnumerable<DailyTaskResponseDto>> GetDailyTasksByCageIdAsync(Guid id, PaginationParameters parameters)
        {
            if (await _dailyTaskRepository.EntityExists<Cage>(id))
            {
                var tasks = await _dailyTaskRepository.GetByCageIdAsync(id);
                if (tasks.Count() == 0)
                {
                    throw new ItemNotFoundException($"No tasks were found for cage with id {id}");
                }
                var tasksPaginated = Pagination.AddPagination<DailyTask>(tasks, parameters);
                var result = tasksPaginated.MapToDtoList();
                return result;
            }
            else throw new ItemNotFoundException($"Cage with id {id} does not exist");
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

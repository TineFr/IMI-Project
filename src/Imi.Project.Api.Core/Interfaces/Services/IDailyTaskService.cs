﻿using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IDailyTaskService
    {
        Task<IEnumerable<DailyTask>> ListAllDailyTasksAsync();
        Task<DailyTaskResponseDto> GetDailyTaskByIdAsync(Guid id);
        Task<DailyTaskResponseDto> AddDailyTaskAsync(DailyTaskRequestDto dto);
        Task<DailyTaskResponseDto> UpdateDailyTaskAsync(Guid id, DailyTaskRequestDto dto);
        Task DeleteDailyTaskAsync(Guid id);
        Task<IEnumerable<DailyTask>> GetDailyTasksByCageIdAsync(Guid id);
    }
}

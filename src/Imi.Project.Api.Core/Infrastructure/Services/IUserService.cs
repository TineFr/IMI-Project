using Imi.Project.Api.Core.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> ListAllAsync();

    }
}

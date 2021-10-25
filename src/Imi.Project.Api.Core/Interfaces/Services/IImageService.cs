using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<string> AddOrUpdateImageAsync<T>(Guid entityId, IFormFile image);
    }
}

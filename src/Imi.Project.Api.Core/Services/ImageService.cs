using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _env;

        public ImageService(IHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> AddOrUpdateImageAsync<T>(Guid entityId, IFormFile image)
        {
            
            var pathForDatabase = Path.Combine("images", typeof(T).Name.ToLower() + "s"); 
            var folderPathForImages = Path.Combine( _env.ContentRootPath, "wwwroot", pathForDatabase);

            if (!Directory.Exists(folderPathForImages))
            {
                Directory.CreateDirectory(folderPathForImages);
            }

            var fileExtension = Path.GetExtension(image.FileName);

            var newFileName = $"{entityId}{fileExtension}";
            var fullFilePath = Path.Combine(folderPathForImages, newFileName);
            if (image.Length > 0)
            {
               using (var newfileStream = new FileStream(pathForDatabase, FileMode.Create))
               {
                    await image.CopyToAsync(newfileStream);
               }
            }

            var filePathForDatabase = Path.Combine(pathForDatabase, newFileName);
            return filePathForDatabase;
        }
    }
}

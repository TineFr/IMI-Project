using System.IO;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api.Interfaces
{
    public interface IImageService
    {
        Task<Stream> SelectImage();
    }
}

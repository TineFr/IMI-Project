using Imi.Project.Blazor.Models.Api;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api.Interfaces
{
    public interface IAuthApiService
    {
        Task<string> Authenticate(LoginRequestModel model);

        Task<string> Register(RegisterModel model);
        void LogOut();
    }
}

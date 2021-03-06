using Imi.Project.Mobile.Core.Models;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface IAuthApiService
    {
        Task<string> Authenticate(LoginRequestModel model);
        
        Task<string> Register(RegisterModel model);
        void LogOut();
    }
}

using Imi.Project.Mobile.Core.Models.Api.Authentication;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface IAuthApiService
    {
        Task<string> Authenticate(string email, string password);

        Task<string> Register(RegisterModel model);
        void LogOut();
    }
}

using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Interfaces
{
    public interface IAuthApiService
    {
        Task<string> Authenticate(string email, string password);
        void LogOut();
    }
}

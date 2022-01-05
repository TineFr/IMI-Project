using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Core.Interfaces
{
    public interface IAuthApiService
    {
        Task<string> Authenticate(string email, string password);
        void LogOut();
    }
}

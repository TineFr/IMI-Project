using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.WPF.Interfaces
{
    public interface IAuthApiService
    {
        void Authenticate(string email, string password);
    }
}

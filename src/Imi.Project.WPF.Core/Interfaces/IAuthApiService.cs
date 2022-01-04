using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.WPF.Core.Interfaces
{
    public interface IAuthApiService
    {
        void Authenticate(string email, string password);
    }
}

using Imi.Project.WPF.Models.Cages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Interfaces
{
    public interface ICageApiService
    {
        Task<IEnumerable<CageApiResponse>> GetCages();
    }
}

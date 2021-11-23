using Imi.Project.WPF.Models.Birds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<BirdApiResponse>> GetBirds();
    }
}

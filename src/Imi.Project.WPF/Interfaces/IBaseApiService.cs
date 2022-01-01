using System.Net.Http;

namespace Imi.Project.WPF.Interfaces
{
    public interface IBaseApiService
    {
        HttpClient GetClient();
        void SetHeader();
    }
}

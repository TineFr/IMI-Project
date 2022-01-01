using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Cages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Services
{
    public class CageApiService : BaseApiService, ICageApiService
    {
        public CageApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<IEnumerable<CageApiResponse>> GetCages()
        {
            SetHeader();
            var response = await GetClient().GetAsync("me/cages");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var cageresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<CageApiResponse>>(responseStream);
                return cageresponse;
            }
            else
            {
                return new List<CageApiResponse>();
            }
        }
    }
}

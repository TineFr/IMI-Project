using Imi.Project.WPF.Core.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Core.Services
{
    public class SpeciesApiService/* : BaseApiService, ISpeciesApiService*/
    {
        //public SpeciesApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        //{
        //}

        //public async Task<IEnumerable<SpeciesApiResponse>> GetSpecies()
        //{
        //    var response = await GetClient().GetAsync("species");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        var birdresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<SpeciesApiResponse>>(responseStream);
        //        return birdresponse;
        //    }
        //    else
        //    {
        //        return new List<SpeciesApiResponse>();
        //    }
        //}
    }
}

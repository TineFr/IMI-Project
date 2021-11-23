using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models;
using Imi.Project.WPF.Models.Birds;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Services
{
    public class ApiService : IApiService
    {

        private HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public async Task<IEnumerable<BirdApiResponse>> GetBirds()
        {
            var response = await _httpClient.GetAsync("birds");
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var birdresponse = await JsonSerializer.DeserializeAsync<IEnumerable<BirdApiResponse>>(responseStream);
            return birdresponse;
          
        }

    }
}

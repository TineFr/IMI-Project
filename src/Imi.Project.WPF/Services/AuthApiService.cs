using Imi.Project.Common.Dtos;
using Imi.Project.WPF.Models;
using System;
using System.Net.Http;

namespace Imi.Project.WPF.Services
{
    public class AuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private string token;

        public AuthApiService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public async void Authenticate(string email, string password)
        {
            LoginRequestDto dto = new LoginRequestDto
            {
                Email = email,
                Password = password
            };
            var response = _httpClient.PostAsJsonAsync("Auth/login", dto).Result;
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var loginresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<LogInApiResponse>(responseStream);
            token = loginresponse.JWT;

        }
    }
}

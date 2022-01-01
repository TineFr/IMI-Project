using Imi.Project.Common.Dtos;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models;
using System;
using System.Net.Http;

namespace Imi.Project.WPF.Services
{
    public class AuthApiService : BaseApiService, IAuthApiService
    {
        public AuthApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async void Authenticate(string email, string password)
        {
            LoginRequestDto dto = new LoginRequestDto
            {
                Email = email,
                Password = password
            };
            var response = GetClient().PostAsJsonAsync("Auth/login", dto).Result;
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var loginresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<LogInApiResponse>(responseStream);
            token = loginresponse.JWT;
        }
    }
}

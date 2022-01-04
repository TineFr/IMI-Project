using Imi.Project.Common.Dtos;
using Imi.Project.WPF.Constants;
using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Imi.Project.WPF.Core.Services
{
    public class AuthApiService : BaseApiService<LogInApiResponse, LogInApiResponse>, IAuthApiService
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
            var response = _httpClient.PostAsJsonAsync("Auth/login", dto).Result;

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var loginresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<LogInApiResponse>(responseStream);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginresponse.JWT);
                Token.JWT = loginresponse.JWT;
            }
        }
    }
}

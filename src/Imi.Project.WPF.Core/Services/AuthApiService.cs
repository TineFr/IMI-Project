using Imi.Project.Common.Dtos;
using Imi.Project.WPF.Constants;
using Imi.Project.WPF.Core.Interfaces;
using Imi.Project.WPF.Core.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Core.Services
{
    public class AuthApiService : BaseApiService<LogInApiResponse, LogInApiResponse>, IAuthApiService
    {
        public AuthApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<string> Authenticate(string email, string password)
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
                Token.JWT = loginresponse.JWT;
                return null;
            }
            else
            {
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public void LogOut()
        {
            Token.JWT = null;
        }
    }
}

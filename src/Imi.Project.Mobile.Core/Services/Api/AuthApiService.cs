using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Core.Constants;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Api
{
    public class AuthApiService : BaseApiService<LogInApiResponse, LogInApiResponse>, IAuthApiService
    {
        public AuthApiService() : base()
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
                var responseStream = await response.Content.ReadAsStreamAsync();
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

using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Core.Constants;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Core.Models.Api.Authentication;
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
            var response = await _httpClient.PostAsJsonAsync("Auth/login", dto);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var loginresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<LogInApiResponse>(responseStream);
                Token.JWT = loginresponse.JWT;
                return null;
            }
            else
            {
                return  response.Content.ReadAsStringAsync().Result;
            }
        }

        public async Task<string> Register(RegisterModel model)
        {
            //RegisterRequestDto dto = new RegisterRequestDto
            //{
            //    Email = model.Email,
            //    Password = model.Password,
            //    Name = model.Name, 
            //    ConfirmPassword = model.ConfirmPassword,    
            //    DateOfBirth = model.DateOfBirth,    
            //    FirstName =   model.FirstName   
            //};
            var response = _httpClient.PostAsJsonAsync("auth/register", model).Result;
            if (response.IsSuccessStatusCode) return null;
            else return await response.Content.ReadAsStringAsync();
        }

        public void LogOut()
        {
            Token.JWT = null;
        }
    }
}

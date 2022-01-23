using Imi.Project.Blazor.LocalStorage;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Api.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class AuthApiService : BaseApiService<LogInApiResponse, LogInApiResponse>, IAuthApiService
    {
        public AuthApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<string> Authenticate(LoginRequestModel model)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Auth/login", model);
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    var loginresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<LogInApiResponse>(responseStream);
                    Token.JWT = loginresponse.JWT;
                    return null;
                }
                else return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException)
            {
                return "Failed to connect to server";
            }
        }

        public async Task<string> Register(RegisterModel model)
        {
            try
            {
                var response = _httpClient.PostAsJsonAsync("auth/register", model).Result;

                if (response.IsSuccessStatusCode) return null;
                else return GetErrorMessage(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                return "Failed to connect to server";
            }
        }


        public override string GetErrorMessage(string message)
        {
            if (message.StartsWith("{\"DuplicateEmail"))
            {
                message = "This e-mail is already in use";
                return $"Something went wrong.\n{message}.";
            }
            else return base.GetErrorMessage(message);
        }


        public void LogOut()
        {
            Token.JWT = null;
        }
    }
}



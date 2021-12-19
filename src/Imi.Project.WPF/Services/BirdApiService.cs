using Imi.Project.Common.Dtos.Authentication.Login;
using Imi.Project.Common.Dtos.Birds;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models;
using Imi.Project.WPF.Models.Birds;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Services
{
    public class BirdApiService : BaseApiService, IBirdApiService
    {
        private string token;
        public BirdApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            //this.token = token;
        }

        public async void Authenticate(string email, string password)
        {
            LoginRequestDto dto = new LoginRequestDto
            {
                Email = email,
                Password = password
            };
            //var response = GetClient().PostAsJsonAsync("Auth/login", dto).Result;
            var response = _httpClient.PostAsJsonAsync("Auth/login", dto).Result;
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var loginresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<LogInApiResponse>(responseStream);
            token = loginresponse.JWT;

        }

        public async Task<IEnumerable<BirdApiResponse>> GetBirds()
        {
            SetHeader(token);
            var response = await GetClient().GetAsync("me/birds");

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var birdresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<BirdApiResponse>>(responseStream);
                return birdresponse;
            }
            else
            {
                return new List<BirdApiResponse>();
            }
        }

        //public async Task<IEnumerable<BirdApiResponse>> GetSpecies()
        //{
        //    SetHeader(token);
        //    var response = await GetClient().GetAsync("species");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        var birdresponse = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<BirdApiResponse>>(responseStream);
        //        return birdresponse;
        //    }
        //    else
        //    {
        //        return new List<BirdApiResponse>();
        //    }
        //}

        public async Task AddBird(Bird newBird)
        {
            SetHeader(token);
            using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StringContent(newBird.Name), "Name");
                    content.Add(new StringContent(newBird.Id.ToString("d")), "Id");
                    content.Add(new StringContent(newBird.UserId.ToString("d")), "UserId");
                    content.Add(new StringContent(newBird.UserId.ToString("d")), "CageId");
                    content.Add(new StringContent(newBird.SpeciesId.ToString("d")), "SpeciesId");
                    var action = await GetClient().PostAsync("birds", content);
                }
        }

        public async Task EditBird(Bird newBird)
        {
            SetHeader(token);
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(newBird.Name), "Name");
                content.Add(new StringContent(newBird.Id.ToString("d")), "Id");
                content.Add(new StringContent(newBird.UserId.ToString("d")), "UserId");
                content.Add(new StringContent(newBird.UserId.ToString("d")), "CageId");
                content.Add(new StringContent(newBird.SpeciesId.ToString("d")), "SpeciesId");
                var action = await GetClient().PostAsync("birds", content);
            }
        }

    }
}

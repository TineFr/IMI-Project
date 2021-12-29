using Imi.Project.Common.Dtos;
using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models;
using Imi.Project.WPF.Models.Birds;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Services
{
    public class BirdApiService : BaseApiService, IBirdApiService
    {

        public BirdApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public async Task<IEnumerable<BirdApiResponse>> GetBirds()
        {
            SetHeader();
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
        public async Task<string> AddBird(Bird newBird)
        {
            SetHeader();
            HttpResponseMessage action;
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(newBird.Name), "Name");
                content.Add(new StringContent(newBird.Food), "Food");
                content.Add(new StringContent(newBird.Gender.ToString()), "Gender");
                content.Add(new StringContent(newBird.HatchDate.ToString()), "HatchDate");
                content.Add(new StringContent(newBird.CageId.ToString("d")), "CageId");
                content.Add(new StringContent(newBird.SpeciesId.ToString("d")), "SpeciesId");
                action = await GetClient().PostAsync("birds", content);
            }

            return ValidateResponse(action);




        }

        public async Task EditBird(Bird newBird)
        {
            SetHeader();
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

        private string ValidateResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                return errorMessage;
            }
            return null;
        }

    }
}

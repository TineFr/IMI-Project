using Imi.Project.WPF.Interfaces;
using Imi.Project.WPF.Models.Birds;
using System;
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
                if (newBird.Image != null)
                {
                    content.Add(new StreamContent(newBird.Image), "Image", newBird.FileName);
                }
                action = await GetClient().PostAsync("birds", content);
            }
            return ValidateResponse(action);
        }

        public async Task<string> EditBird(Guid id, Bird editedBird)
        {
            SetHeader();
            HttpResponseMessage action;
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(editedBird.Name), "Name");
                content.Add(new StringContent(editedBird.Food), "Food");
                content.Add(new StringContent(editedBird.Gender.ToString()), "Gender");
                content.Add(new StringContent(editedBird.HatchDate.ToString()), "HatchDate");
                content.Add(new StringContent(editedBird.CageId.ToString("d")), "CageId");
                content.Add(new StringContent(editedBird.SpeciesId.ToString("d")), "SpeciesId");
                if (editedBird.Image != null)
                {
                    content.Add(new StreamContent(editedBird.Image), "Image", editedBird.FileName);
                }
                action = await GetClient().PutAsync($"birds/{id}", content);
            }
            return ValidateResponse(action);
        }

        public async Task<string> DeleteBird(Guid id)
        {
            SetHeader();
            HttpResponseMessage action = await GetClient().DeleteAsync($"birds/{id}");
            return ValidateResponse(action);
        }
        private string ValidateResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                if (errorMessage.StartsWith("{"))
                {
                   errorMessage =  errorMessage.Split(":[\"")[1].Split("\"]}}")[0] + ".";
                   return errorMessage;
                }
                return errorMessage;
            }
            return null;
        }

    }
}

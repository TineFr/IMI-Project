
using Imi.Project.WPF.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.WPF.Core.Services
{
    public class BirdApiService : BaseApiService<BirdRequestModel, BirdModel>
    {

        public BirdApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }

        public override async Task<BirdModel> AddAsync(string requestUri, BirdRequestModel model)
        {
            SetHeader();
            HttpResponseMessage action;
            action = await _httpClient.PostAsync(requestUri, GetBirdContent(model));
            return await ValidateResponse(action);
        }
        public override async Task<BirdModel> UpdateAsync(string requestUri, BirdRequestModel model)
        {
            SetHeader();
            HttpResponseMessage action;
            action = await _httpClient.PutAsync(requestUri, GetBirdContent(model));
            return await ValidateResponse(action);
        }

        private MultipartFormDataContent GetBirdContent(BirdRequestModel model)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(model.Name), "Name" },
                { new StringContent(model.Gender.ToString()), "Gender" },
                { new StringContent(model.HatchDate.ToString()), "HatchDate" },
            };
            if (model.Food is object) content.Add(new StringContent(model.Food), "Food");
            if (model.CageId is object) content.Add(new StringContent(model.CageId?.ToString("d")), "CageId");
            if (model.SpeciesId is object) content.Add(new StringContent(model.SpeciesId?.ToString("d")), "SpeciesId");
            if (model.ImageInfo != null) content.Add(new StreamContent(model.ImageInfo.Image), "Image", model.ImageInfo.FileName);
            return content;
        }

    }
}

using Imi.Project.Blazor.Models.Api;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
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
            var content = new MultipartFormDataContent
            {
                { new StringContent(model.Name), "Name" },
                { new StringContent(model.Gender), "Gender" },
                { new StringContent(model.HatchDate.ToString("dd/MM/yyyy HH:mm:ss")), "HatchDate" },
            };
            if (model.Food is object) content.Add(new StringContent(model.Food), "Food");
            if (model.CageId is object) content.Add(new StringContent(model.CageId), "CageId");
            if (model.SpeciesId is object) content.Add(new StringContent(model.SpeciesId), "SpeciesId");
            if (model.ImageInfo != null) content.Add(new StreamContent(model.ImageInfo.Image), "Image", model.ImageInfo.FileName);
            action = await _httpClient.PostAsync(requestUri, content);
            return await ValidateResponse(action);
        }
        public override async Task<BirdModel> UpdateAsync(string requestUri, BirdRequestModel model)
        {
            SetHeader();
            HttpResponseMessage action;
            var content = new MultipartFormDataContent
            {
                { new StringContent(model.Name), "Name" },
                { new StringContent(model.Gender.ToString()), "Gender" },
                { new StringContent(model.HatchDate.ToString("dd/MM/yyyy HH:mm:ss")), "HatchDate" },
            };
            if (model.Food is object) content.Add(new StringContent(model.Food), "Food");
            if (model.CageId is object) content.Add(new StringContent(model.CageId), "CageId");
            if (model.SpeciesId is object) content.Add(new StringContent(model.SpeciesId), "SpeciesId");
            if (model.ImageInfo != null) content.Add(new StreamContent(model.ImageInfo.Image), "Image", model.ImageInfo.FileName);
            action = await _httpClient.PutAsync(requestUri, content);
            return await ValidateResponse(action);
        }

    }
}

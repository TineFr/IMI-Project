
using Imi.Project.Blazor.Models.Api;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class CageApiService : BaseApiService<CageRequestModel, CageModel>
    {
        public CageApiService(IHttpClientFactory clientFactory) : base(clientFactory)
        {

        }
        public override async Task<CageModel> AddAsync(string requestUri, CageRequestModel model)
        {

            SetHeader();
            HttpResponseMessage action;
            var content = new MultipartFormDataContent
            {
                { new StringContent(model.Name), "Name" },
                { new StringContent(model.Location), "Location" }
            };

            if (model.ImageInfo != null)
            {
                content.Add(new StreamContent(model.ImageInfo.Image), "Image", model.ImageInfo.FileName);
            }
            action = await _httpClient.PostAsync(requestUri, content);
            return await ValidateResponse(action);
        }
        public override async Task<CageModel> UpdateAsync(string requestUri, CageRequestModel model)
        {
            SetHeader();
            HttpResponseMessage action;
            var content = new MultipartFormDataContent
            {
                { new StringContent(model.Name), "Name" },
                { new StringContent(model.Location), "Location" },
            };

            if (model.ImageInfo != null)
            {
                content.Add(new StreamContent(model.ImageInfo.Image), "Image", model.ImageInfo.FileName);
            }
            action = await _httpClient.PutAsync(requestUri, content);
            return await ValidateResponse(action);
        }
    }
}

using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Api
{
    public class CageApiService : BaseApiService<CageRequestModel, CageModel>
    {
        public CageApiService() : base()
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

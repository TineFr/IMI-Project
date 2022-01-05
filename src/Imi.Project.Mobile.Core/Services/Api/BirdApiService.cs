﻿using Imi.Project.Mobile.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services.Api
{
    public class BirdApiService : BaseApiService<BirdRequestModel, BirdModel>
    {

        public BirdApiService() : base()
        {

        }

        public override async Task<BirdModel> AddAsync(string requestUri, BirdRequestModel model)
        {
            SetHeader();
            HttpResponseMessage action;
            var content = new MultipartFormDataContent
            {
                { new StringContent(model.Name), "Name" },
                { new StringContent(model.Food), "Food" },
                { new StringContent(model.Gender.ToString()), "Gender" },
                { new StringContent(model.HatchDate.ToString()), "HatchDate" },
                { new StringContent(model.CageId.ToString("d")), "CageId" },
                { new StringContent(model.SpeciesId.ToString("d")), "SpeciesId" },
            };

            if (model.ImageInfo != null)
            {
                content.Add(new StreamContent(model.ImageInfo.Image), "Image", model.ImageInfo.FileName);
            }
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
                { new StringContent(model.Food), "Food" },
                { new StringContent(model.Gender.ToString()), "Gender" },
                { new StringContent(model.HatchDate.ToString()), "HatchDate" },
                { new StringContent(model.CageId.ToString("d")), "CageId" },
                { new StringContent(model.SpeciesId.ToString("d")), "SpeciesId" },
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

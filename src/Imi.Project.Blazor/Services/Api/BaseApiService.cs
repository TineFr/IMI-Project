using Imi.Project.Blazor.LocalStorage;
using Imi.Project.Blazor.Models;
using Imi.Project.Blazor.Models.Api;
using Imi.Project.Blazor.Services.Api.Interfaces;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services.Api
{
    public class BaseApiService<T, resp> : IBaseApiService<T, resp> where T : class where resp : BaseModel, new()
    {
        protected readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseApiService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }
        public async Task<IEnumerable<resp>> GetAllAsync(string requestUri)
        {
            SetHeader();
            HttpResponseMessage action = await _httpClient.GetAsync(requestUri);
            if (action.IsSuccessStatusCode)
            {
                IEnumerable<resp> returnedModel = await action.Content.ReadAsAsync<IEnumerable<resp>>();
                return returnedModel;
            }
            else
            {
                resp messagemodel = new resp
                {
                    ErrorMessage = GetErrorMessage(action.Content.ReadAsStringAsync().Result)
                };
                return new List<resp> { messagemodel };
            }
        }

        public async Task<resp> GetByIdAsync(string requestUri)
        {
            SetHeader();
            HttpResponseMessage action = await _httpClient.GetAsync(requestUri);
            if (action.IsSuccessStatusCode)
            {
                resp returnedModel = await action.Content.ReadAsAsync<resp>();
                return returnedModel;
            }
            else
            {
                resp messagemodel = new resp
                {
                    ErrorMessage = GetErrorMessage(action.Content.ReadAsStringAsync().Result)
                };
                return messagemodel;
            }
        }

        public async virtual Task<resp> AddAsync(string requestUri, T model)
        {
            SetHeader();
            HttpResponseMessage action = await _httpClient.PostAsJsonAsync(requestUri, model);
            return await ValidateResponse(action);
        }
        public async virtual Task<resp> UpdateAsync(string requestUri, T model)
        {
            SetHeader();
            HttpResponseMessage action = await _httpClient.PutAsJsonAsync(requestUri, model);
            return await ValidateResponse(action);
        }
        public async virtual Task<resp> DeleteAsync(string requestUri)
        {
            SetHeader();
            HttpResponseMessage action = await _httpClient.DeleteAsync(requestUri);
            if (action.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                resp model = new resp
                {
                    ErrorMessage = GetErrorMessage(action.Content.ReadAsStringAsync().Result)
                };
                return model;
            }
        }

        public async Task<resp> ValidateResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                resp returnedModel = await response.Content.ReadAsAsync<resp>();
                return returnedModel;
            }
            else
            {
                resp messagemodel = new resp
                {
                    ErrorMessage = GetErrorMessage(response.Content.ReadAsStringAsync().Result)
                };
                return messagemodel;
            }
        }
        public void SetHeader()
        {
            if (Token.JWT != null) _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.JWT);
        }


        public virtual string GetErrorMessage(string message)
        {
            return $"Something went wrong.\n{message}";
        }
    }

}

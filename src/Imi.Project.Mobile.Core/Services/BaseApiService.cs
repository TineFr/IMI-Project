using Imi.Project.Mobile.Core.Constants;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Core.Services
{
    public class BaseApiService<T, resp> : IBaseApiService<T, resp> where T : class where resp : BaseModel, new()
    {
        protected readonly HttpClient _httpClient;

        public BaseApiService()
        {
            _httpClient = HttpClientFactory.Create();
            _httpClient.BaseAddress = new Uri("http://192.168.0.131:5000/api/");
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

using Imi.Project.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Imi.Project.WPF.Services
{
    public class BaseApiService: IBaseApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseApiService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        //public void Authenticate(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public HttpClient GetClient()
        {
            return _httpClient;
        }

        public void SetHeader(string token)
        {
             GetClient().DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


    }
}

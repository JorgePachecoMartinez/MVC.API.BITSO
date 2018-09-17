using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiClient
{
    class BitsoClientBuilder : IClientBuilder
    {
        private ValuesClient _Client;

        public BitsoClientBuilder()
        {
            _Client = new BitsoClient();
        }

        public void BuildClient()
        {
            _Client.Client = new HttpClient();
            string URLBitso = ConfigurationManager.AppSettings["URLBitso"];
            _Client.Client.BaseAddress = new Uri(URLBitso);
            _Client.Client.DefaultRequestHeaders.Accept.Clear();
            _Client.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

     
        public async Task<ApiResponse> GetValues(string relativePath)
        {
          
            HttpResponseMessage apiResponse = _Client.Client.GetAsync(relativePath).Result;
            if (apiResponse.IsSuccessStatusCode)
            {
                string responseData = await apiResponse.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(responseData))
                {
                    _Client.ApiResponse = new ApiResponse();
                    _Client.ApiResponse.IsSuccessful = true;
                    _Client.ApiResponse.Data = responseData;
                }
            }
            else
            {
                _Client.ApiResponse.IsSuccessful = false;
            }

            return _Client.ApiResponse;
        }

        public ApiResponse apiResponse
        {
            get { return _Client.ApiResponse; }
        }
    }
}

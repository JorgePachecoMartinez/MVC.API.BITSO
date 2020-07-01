using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            HttpResponseMessage apiResponse = await _Client.Client.GetAsync(relativePath);
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

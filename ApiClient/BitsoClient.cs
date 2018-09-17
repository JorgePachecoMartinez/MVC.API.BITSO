using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class BitsoClient : ValuesClient
    {
        private HttpClient _Client = null;
        private ApiResponse _ApiResponse= null;

        public override HttpClient Client
        {
            get
            {
                return _Client;
            }
            set
            {
                _Client = value;
            }
        }

        public override ApiResponse ApiResponse
        {
            get
            {
                return _ApiResponse;
            }
            set
            {
                _ApiResponse = value;
            }
        }
    }

   
}

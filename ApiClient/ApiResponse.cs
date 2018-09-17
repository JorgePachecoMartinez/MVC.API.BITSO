using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    [Serializable]
    public class ApiResponse
    {
        private bool _successful;
        private string _data;

        public ApiResponse()
        {
            _data = string.Empty;
            _successful = false;
        }

        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public bool IsSuccessful
        {
            get
            {
                return _successful;
            }
            set
            {
                _successful = value;
            }
        }
    }
}

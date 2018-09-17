using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public interface IClientBuilder
    {
        void BuildClient();
        Task<ApiResponse> GetValues(string relativePath);

        ApiResponse apiResponse { get; }

    }
}

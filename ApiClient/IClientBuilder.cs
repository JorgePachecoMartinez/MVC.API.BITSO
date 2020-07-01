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

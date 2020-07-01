using System.Net.Http;

namespace ApiClient
{
    public abstract class ValuesClient
    {
        public virtual HttpClient Client { get; set; }

        public virtual ApiResponse ApiResponse { get; set; }
    }
}

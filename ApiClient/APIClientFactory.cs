namespace ApiClient
{
    public class APICLientFactory
    {
        public static ApiResponse CreateApiClient(string relativePath)
        {
            Director director = new Director();
            IClientBuilder builder;

            builder = new BitsoClientBuilder();
            director.Build(builder, relativePath);

            return builder.apiResponse;

        }
    }
}

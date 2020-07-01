namespace ApiClient
{
    public class Director
    {
        public void Build(IClientBuilder Builder, string relativePath)
        {
            Builder.BuildClient();
            var values = System.Threading.Tasks.Task.Run(() => Builder.GetValues(relativePath));
            values.Wait();
        }
    }
}

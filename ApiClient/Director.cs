using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class Director
    {
        public void Build(IClientBuilder Builder, string relativePath)
        {
            Builder.BuildClient();
            Builder.GetValues(relativePath);
        }
    }
}

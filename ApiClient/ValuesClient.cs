using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public abstract class ValuesClient
    {
        public virtual HttpClient Client { get; set; }

        public virtual ApiResponse ApiResponse { get; set; }
    }
}

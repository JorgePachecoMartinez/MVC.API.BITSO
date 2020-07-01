using Newtonsoft.Json;
using System;

namespace BitsoProyect.Models
{
    [JsonObject]
    public class Ticker
    {
        [JsonProperty("last")]
        public String UtlimoPrecio { get; set; }

        [JsonProperty("volume")]
        public String Volumen { get; set; }

        [JsonProperty("high")]
        public String Maximo { get; set; }

        [JsonProperty("low")]
        public String Minimo { get; set; }

        

    }
}
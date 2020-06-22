using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPCOVID.Models
{
    public class Triaje
    {

        [JsonProperty("test_id")]
        public int test_id { get; set; }

        [JsonProperty("hora_registro")]
        public string hora_registro { get; set; }

        [JsonProperty("ciudadano")]
        public string ciudadano { get; set; }

        [JsonProperty("estado")]
        public string estado { get; set; }

    }

    public class TriajeResponse
    {
       
        [JsonProperty("triajes")]
        public List<Triaje> triajes { get; set; }
    }
}
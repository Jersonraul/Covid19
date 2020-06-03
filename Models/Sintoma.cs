using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPCOVID.Models
{
    public class Sintoma
    {
        [JsonProperty("symptom_id")]
        public int symptom_id { get; set; }
        [JsonProperty("symptom_description")]
        public string symptom_description { get; set; }
    }

         public class SintomaResponse
    {
        //private List<Sintoma> response { get; set; }
        [JsonProperty("sintomas")]
        public List<Sintoma> sintomas { get; set; }
    }
}
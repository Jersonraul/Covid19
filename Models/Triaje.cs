using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APPCOVID.Models
{
    public class Triaje
    {

        [JsonProperty("test_id")]
        public int test_id { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }


        [JsonProperty("apellido")]
        public string apellido { get; set; }

        [JsonProperty("doc_type")]
        public string doc_type { get; set; }

        [JsonProperty("hora_registro")]
        public string hora_registro { get; set; }

        [JsonProperty("user_id")]
        public int user_id { get; set; }

        [JsonProperty("doc_number")]
        public int doc_number { get; set; }

        [JsonProperty("estado")]
        public string estado { get; set; }

        [JsonProperty("fecha_triaje")]
        public string fecha_triaje { get; set; }

        [JsonProperty("sexo")]
        public string sexo { get; set; }

        [JsonProperty("estados")]
        public IEnumerable<SelectListItem> estados { get; set; }

        [JsonProperty("sintomas")]
        public IList<string> sintomas { get; set; }

    }

   
    public class TriajeXId
    {

        [JsonProperty("test_id")]
        public int test_id { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }


        [JsonProperty("apellido")]
        public string apellido { get; set; }

        [JsonProperty("doc_type")]
        public string doc_type { get; set; }

        [JsonProperty("doc_number")]
        public int doc_number { get; set; }

        [JsonProperty("sexo")]
        public string sexo { get; set; }

        [JsonProperty("fecha_triaje")]
        public string fecha_triaje { get; set; }

        [JsonProperty("estado")]
        public string estado { get; set; }

        [JsonProperty("sintomas")]
        public List<string> sintomas { get; set; }



    }
    
    public class TriajeResponse
    {
       
        [JsonProperty("triajes")]
        public List<Triaje> triajes { get; set; }
    }

    public class TriajeResponseXid
    {

        [JsonProperty("triaje")]
        public TriajeXId triaje { get; set; }

        [JsonProperty("Estados")]
        public IEnumerable<SelectListItem> Estados { get; set; }
    }
}
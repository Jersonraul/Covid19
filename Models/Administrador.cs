using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APPCOVID.Models
{
    public class Administrador
    {
       
        public int IdAdmin { get; set; }
        
        public string Nombre { get; set; }

       
      
    }

    public class AdminSignup
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("lastname")]
        public string lastname { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("doctype")]
        public int doctype { get; set; }

        [JsonProperty("docnumber")]
        public string docnumber { get; set; }

        [JsonProperty("sex")]
        public string sex { get; set; }

        [JsonProperty("Tipos")]
        public IEnumerable<SelectListItem> Tipos { get; set; }
    }

    
    

}
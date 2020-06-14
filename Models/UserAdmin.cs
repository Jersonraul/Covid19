using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPCOVID.Models
{
    public class UserAdmin
    {

        [JsonProperty("id_user")]
        public int id_user { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }

        [JsonProperty("apellido")]
        public string apellido { get; set; }

        [JsonProperty("doc_tipo")]
        public string doc_tipo { get; set; }

        [JsonProperty("num_doc")]
        public int num_doc { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("sexo")]
        public string sexo { get; set; }

        [JsonProperty("fecha_registro")]
        public string fecha_registro { get; set; }

        [JsonProperty("fecha_nac")]
        public string fecha_nac { get; set; }

        [JsonProperty("direccion")]
        public string direccion { get; set; }

    }

    public class UserAdminResponse
    {
        [JsonProperty("users")]
        public List<UserAdmin> users { get; set; }
    }

    public class UserAdminResponseXId
    {
        [JsonProperty("usuario")]
        public List<UserAdmin> usuario { get; set; }
    }

    public class Admin
    {

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

       
    }

    public class AdminResponse
    {
        [JsonProperty("Admins")]
        public List<Admin> Admins { get; set; }
    }
}
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

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("sexo")]
        public string sexo { get; set; }

    }

    public class UserAdminResponse
    {
        [JsonProperty("UserAdmins")]
        public List<UserAdmin> UserAdmins { get; set; }
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
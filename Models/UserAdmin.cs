using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace APPCOVID.Models
{
    public class UserAdmin
    {

        [JsonProperty("id_user", NullValueHandling = NullValueHandling.Ignore)]
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

    public static class Authentication
    {
        static void SignIn(
            HttpContextBase context,
            string emailAddress,
            bool rememberMe,
            Admin user = null)
        {
            var cookie = FormsAuthentication.GetAuthCookie(
                emailAddress.ToLower(),
                rememberMe);
            var oldTicket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(
                oldTicket.Version,
                oldTicket.Name,
                oldTicket.IssueDate,
                oldTicket.Expiration,
                oldTicket.IsPersistent,
                JsonConvert.SerializeObject(user ?? new Admin()));

            cookie.Value = FormsAuthentication.Encrypt(newTicket);

            context.Response.Cookies.Add(cookie);
        }

        static void SignOut(HttpContextBase context)
        {
            FormsAuthentication.SignOut();
        }

        static Admin GetLoggedInUser()
        {
            if (HttpContext.Current.User?.Identity?.Name != null && HttpContext.Current.User?.Identity is FormsIdentity identity)
                return JsonConvert.DeserializeObject<Admin>(identity.Ticket.UserData);

            return new Admin();
        }
    }


}
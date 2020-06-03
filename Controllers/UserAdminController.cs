using APPCOVID.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace APPCOVID.Controllers
{
    public class UserAdminController : Controller
    {

        public ActionResult Lista()
        {

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/api/v1.0/");

            var request = clienteHttp.GetAsync("admin/user");
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var listado = JsonConvert.DeserializeObject<UserAdminResponse>(resultString);

            List<UserAdmin> listaAdmin = new List<UserAdmin>();
            foreach (var item in listado.UserAdmins)
            {
                UserAdmin obj = new UserAdmin()
                {
                    id_user = item.id_user,
                    nombre = item.nombre,
                    apellido = item.apellido,
                    email = item.email,
                    sexo = item.sexo,
                };
                listaAdmin.Add(obj);
            }

            ViewBag.sintomass = listaAdmin;

            return View();



        }
        // GET: UserAdmin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin user)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/api/v1.0/");

            var request = clienteHttp.PostAsync("admin/signin", user, new JsonMediaTypeFormatter());
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var registro = JsonConvert.DeserializeObject<AdminResponse>(resultString);

            List<Admin> listaAdmin = new List<Admin>();
            foreach (var item in registro.Admins)
            {
                Admin obj = new Admin()
                {
                    email = item.email,
                    password = item.password,
                   
                    
                };
                listaAdmin.Add(obj);
            }

            ViewBag.sintomass = listaAdmin;

            return View(listaAdmin);

           
        }
    }
}
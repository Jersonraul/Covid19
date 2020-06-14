using APPCOVID.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;

namespace APPCOVID.Controllers
{
    public class UserAdminController : Controller
    {
         public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGNpYmVyY292aWQuY29tIiwiaWF0IjoxNTkyMDc5OTc2fQ.Ja0QKww93_7MAMeewdoEB6CRyBBhf7R5zybpQB7iYM4";
        //public string token = "";

        
        public ActionResult Lista()
        {


            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");


            clienteHttp.DefaultRequestHeaders.Add("x-access-token", token);

            var request = clienteHttp.GetAsync("api/v1.0/admin/user");
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var listado = JsonConvert.DeserializeObject<UserAdminResponse>(resultString);

            List<UserAdmin> listaAdmin = new List<UserAdmin>();
            foreach (var item in listado.users)
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

        //lista por campo

        
           [HttpGet]
        public ActionResult ListaXSexo(int? cod)
        {
            ViewBag.id_user =cod;
            
            return View();
        }


        [HttpPost]
        public ActionResult ListaXSexoo(int id_user)
        {
           
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");
            clienteHttp.DefaultRequestHeaders.Add("x-access-token", token);
            var request = clienteHttp.GetAsync("api/v1.0/admin/user" +"/" +id_user);
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var informacion = JsonConvert.DeserializeObject<UserAdminResponseXId>(resultString);


        List<UserAdmin> listaAdmin = new List<UserAdmin>();
            foreach (var item in informacion.usuario)
            {
                UserAdmin obj = new UserAdmin()
                {
                   // id_user = item.id_user,
                    nombre = item.nombre,
                    apellido = item.apellido,
                    doc_tipo= item.doc_tipo,
                    num_doc = item.num_doc,
                    email = item.email,
                    sexo = item.sexo,
                    fecha_registro=item.fecha_registro
                };
                listaAdmin.Add(obj);
            }

            ViewBag.usersxid = listaAdmin;

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
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.PostAsync("api/v1.0/admin/signin", user, new JsonMediaTypeFormatter());
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
             token = resultString;
            
            ViewBag.TOKEN = token;

            //return token;
             //return View("Token");
           return RedirectToAction("Lista");
          
        }
        //REGSTRAR ADMIN

        [HttpGet]
        public ActionResult Nuevo()
        {
            AdminSignup admin = new AdminSignup();
            admin = new AdminSignup();
            admin.Tipos = new List<SelectListItem> {
            new SelectListItem { Value="1", Text="DNI" },
            new SelectListItem { Value ="2", Text="PASAPORTE" }


        };

            return PartialView("Nuevo", admin);
        }

        [HttpPost]
        public ActionResult Nuevo(AdminSignup admin)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");
            

            var request = clienteHttp.PostAsync("api/v1.0/signup", admin, new JsonMediaTypeFormatter());
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var registro = JsonConvert.DeserializeObject<string>(resultString);

            



            if (registro != null)
            {
                return RedirectToAction("Index");
            }

           /* List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "DNI", Value = "1" });
            lst.Add(new SelectListItem() { Text = "PASAPORTE", Value = "2" });
            ViewData.Model = lst;*/

            

            return View(admin);
        }

        

    }
}
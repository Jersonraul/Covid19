using APPCOVID.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace APPCOVID.Controllers
{
    public class UserAdminController : Controller
    {
        public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGNpYmVyY292aWQuY29tIiwiaWF0IjoxNTkyMDc5OTc2fQ.Ja0QKww93_7MAMeewdoEB6CRyBBhf7R5zybpQB7iYM4";
        //public string token = "";

        //    [Authorize(Roles = "Administrators")]
        public ActionResult Lista()
        {
            // FormsAuthentication.SetAuthCookie("admin@cibercovid.com", true);

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

            if (User != null && User.Identity.IsAuthenticated && Response.StatusCode == 401)
            {
                //Do whatever

                //In my case redirect to error page
                Response.RedirectToRoute("Default", new { controller = "Home", action = "ErrorUnauthorized" });
            }

            return View();



        }

        //lista por campo


        [HttpGet]
        public ActionResult ListaXId()
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
                    nombre = item.nombre,
                    apellido = item.apellido,
                    doc_tipo = item.doc_tipo,
                    num_doc = item.num_doc,
                    email = item.email,
                    sexo = item.sexo,
                    fecha_registro = item.fecha_registro
                };
                listaAdmin.Add(obj);
            }

            ViewBag.listaporcampo = listaAdmin;



            return View();
        }




        [HttpPost]
        public ActionResult ListaXId(int? id_user)
        {
            try
            {
                ViewBag.id = id_user;

                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");
                clienteHttp.DefaultRequestHeaders.Add("x-access-token", token);

                var request = clienteHttp.GetAsync("api/v1.0/admin/user/" + id_user);
                // request.Wait();
                var response = request.Result;

                var resultString = response.Content.ReadAsStringAsync().Result;
                var informacion = JsonConvert.DeserializeObject<UserAdminResponseXId>(resultString);
                string data = informacion.ToString();


                List<UserAdmin> lista = new List<UserAdmin>();
                List<UserAdmin> listaAdmin = new List<UserAdmin>();
                lista = informacion.usuario;

                if (lista.Count() > 0)
                {
                    foreach (var item in informacion.usuario)
                    {
                        UserAdmin obj = new UserAdmin()
                        {
                            // id_user = item.id_user,
                            nombre = item.nombre,
                            apellido = item.apellido,
                            doc_tipo = item.doc_tipo,
                            num_doc = item.num_doc,
                            email = item.email,
                            sexo = item.sexo,
                            fecha_registro = item.fecha_registro
                        };
                        listaAdmin.Add(obj);
                    }

                    ViewBag.listaporcampo = listaAdmin;

                  
                    return View();

                }
                else if(lista.Count()== 0)
                {
                    TempData["success"] = "Usuario no encontrado";
                }

            }
            catch (HttpRequestException e)
            {

            }
            return View("Lista");
        }


        //[HttpGet("[action]")]
        //public async Task<UserAdmin> MyMethod(int page)
        //{
        //    int perPage = 10;
        //    int start = (page - 1) * perPage;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("externalAPI");
        //        MediaTypeWithQualityHeaderValue contentType =
        //            new MediaTypeWithQualityHeaderValue("application/json");
        //        client.DefaultRequestHeaders.Accept.Add(contentType);
        //        HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
        //        string content = await response.Content.ReadAsStringAsync();
        //        IEnumerable<UserAdminResponse> data =
        //               JsonConvert.DeserializeObject<IEnumerable<UserAdminResponse>>(content);
        //        UserAdmin datasent = new UserAdmin
        //        {
        //            Count = data.Count(),
        //            UserAdminResponse = data.Skip(start).Take(perPage).ToList(),
        //        };
        //        return datasent;
        //    }
        //}


        //FormsAuthentication.SetAuthCookie("someUser", false);
        // GET: UserAdmin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Adminm admin)
        {
            /* FormsAuthentication.SetAuthCookie("admin@cibercovid.com", true);
            // try { 
             HttpClient clienteHttp = new HttpClient();
             clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

             var request = clienteHttp.PostAsync("api/v1.0/admin/signin", user, new JsonMediaTypeFormatter());
             request.Wait();
             var response = request.Result;

             var resultString = response.Content.ReadAsStringAsync().Result;
              token = resultString;

             ViewBag.TOKEN = token;


             return RedirectToAction("Lista");*/

            if (ModelState.IsValid)
            {
                if (Isvalid(admin.Email, admin.Password))
                {
                    FormsAuthentication.SetAuthCookie(admin.Email, false);
                    FormsAuthentication.SetAuthCookie(admin.Password, false);
                    return RedirectToAction("Lista", "UserAdmin");
                }
                else
                {
                    ModelState.AddModelError("", "Datos Incorrectos");
                   /* TempData["CustomError"] = "The item is removed from your cart";
                   
                        ModelState.AddModelError(string.Empty, TempData["CustomError"].ToString());*/
                    

                }
            }
            return View(admin);

        }


        private bool Isvalid(string Email, string password)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.GetAsync("api/v1.0/admin/signin");
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            //   var listado = JsonConvert.DeserializeObject<AdminResponse>(resultString);

            //////////////////

            bool Isvalid = false;
            // using (var db = new MainDbContext())
            {
                //  var user = db.SystemUsers.FirstOrDefault(u => u.Email == Email); //consultar el primer registro con los el email del usuario
                var user = "admin@cibercovid.com";
                var pass = "cibercovid123";

                user.Equals(Email);
                if (user != null)
                {
                    if (pass == password && user== Email) //Verificar 
                    {
                        Isvalid = true;
                    }
                }
            }
            return Isvalid;
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
           // return View("Nuevo");
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
          //  var registro = JsonConvert.DeserializeObject<string>(resultString);


            if (resultString != null)
            {
                return RedirectToAction("Lista");
            }

           /* List<SelectListItem> lst = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "DNI", Value = "1" });
            lst.Add(new SelectListItem() { Text = "PASAPORTE", Value = "2" });
            ViewData.Model = lst;*/

            

            return View(admin);
        }

        

    }
}
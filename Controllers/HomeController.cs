using APPCOVID.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace APPCOVID.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(string message = "")
        {
            ViewBag.Mesage = message;
            return View();
        }
        [HttpPost]
        public ActionResult Loginn(string nombre = "admin", string password = "admin")
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.GetAsync("api/symptom");
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var listado = JsonConvert.DeserializeObject<SintomaResponse>(resultString);

            ///////////////////////////////////////

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(password))
            {
                Sintoma ds = new Sintoma();
                var sinto = ds.symptom_description.Equals(nombre) && ds.symptom_description.Equals(password);
                //ds.symptom_id == nombre,ds.symptom_description == password

                if (sinto != null)
                {
                    FormsAuthentication.SetAuthCookie(ds.symptom_description, true);
                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return RedirectToAction("Login", new { message = "NO se encontraron tus datos" });
                }
            }
            else
            {
                return RedirectToAction("Login", new { message = "LLena los campos para iniciar sesion" });

            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}
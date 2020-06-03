using APPCOVID.Models;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace APPCOVID.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {

            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.GetAsync("api/symptom");
            request.Wait();
            var response = request.Result;

                var resultString = response.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<SintomaResponse>(resultString);

            List<Sintoma> listaSintoma = new List<Sintoma>();
            foreach (var item in listado.sintomas)
            {
                Sintoma obj = new Sintoma()
                {
                    symptom_id = item.symptom_id,
                    symptom_description = item.symptom_description
                };
                listaSintoma.Add(obj);
            }

            ViewBag.sintomass = listaSintoma;

               /* for (var i= 0;i<listado.sintomas.Count;i++)
                {
                    Console.WriteLine(listado);
                }

            ViewBag.sintomasa = listado;*/

                return View();

                

            

           
        }

        public ActionResult Login(string message = "")
        {
            ViewBag.Mesage = message;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string nombre = "admin", string password = "admin")
        {
            //HttpClient clienteHttp = new HttpClient();
            //clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            //var request = clienteHttp.GetAsync("api/symptom");
            //request.Wait();
            //var response = request.Result;

            //var resultString = response.Content.ReadAsStringAsync().Result;
            //var listado = JsonConvert.DeserializeObject<SintomaResponse>(resultString);

            ///////////////////////////////////////

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(password))
            {
                Sintoma ds = new Sintoma();
                var sinto = ds.symptom_description.Equals(nombre) && ds.symptom_description.Equals(password);
                //ds.symptom_id == nombre,ds.symptom_description == password

                if (sinto)
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
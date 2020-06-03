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
using System.Net.Http.Formatting;

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

            

            return View();






        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(Sintoma sintoma)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.PostAsync("api/symptom", sintoma, new JsonMediaTypeFormatter());
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var registro = JsonConvert.DeserializeObject<string>(resultString);
            if (registro!=null)
            {
                return RedirectToAction("Index");
            }
            return View(sintoma);
        }

        //actualizar

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.GetAsync("api/symptom?symptom_id=" + id);
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var informacion = JsonConvert.DeserializeObject<Sintoma>(resultString);

            return View(informacion);
        }



        [HttpPost]
        public ActionResult Actualizar(Sintoma sintoma)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.PutAsync("api/symptom", sintoma, new JsonMediaTypeFormatter());
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var registro = JsonConvert.DeserializeObject<string>(resultString);
            if (registro!=null)
            {
                return RedirectToAction("Index");
            }
            return View(sintoma);
        }

        //eliminar

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.DeleteAsync("api/symptom?symptom_id=" + id);
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var correcto = JsonConvert.DeserializeObject<bool>(resultString);
            if (correcto)
            {
                return RedirectToAction("Index");
            }
            return View(correcto);
        }

        //detalle

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

            var request = clienteHttp.GetAsync("api/symptom?symptom_id=" + id);
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var informacion = JsonConvert.DeserializeObject<Sintoma>(resultString);

            return View(informacion);
        }
        public ActionResult Login()
        {

            return View();
        }

        

        [HttpPost]
        public ActionResult Login2(string email, string password)
        {
            Console.WriteLine(email);
            Console.WriteLine(password);
            return View("loginn");
            
        }
    }


   
    
}
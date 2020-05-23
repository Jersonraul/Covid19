using APPCOVID.Models;
//using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Web.Mvc;

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

            if (response.IsSuccessStatusCode)
            {
                var resultString = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Debug");
                Debug.WriteLine(resultString);
                SintomaResponse respuestaJSON = JsonSerializer.Deserialize<SintomaResponse>(resultString);
                return View(respuestaJSON.ToString());
            }
            return null;
            //return View(new List<Administrador>());
        }

       

    }
}
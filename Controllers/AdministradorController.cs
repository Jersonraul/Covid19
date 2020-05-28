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
       
       

    }
}
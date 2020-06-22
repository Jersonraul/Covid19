using APPCOVID.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APPCOVID.Controllers
{
    public class TriajeController : Controller
    {
        // GET: Triaje
        public ActionResult Index()
        {
            return View();
        }

        public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGNpYmVyY292aWQuY29tIiwiaWF0IjoxNTkyMDc5OTc2fQ.Ja0QKww93_7MAMeewdoEB6CRyBBhf7R5zybpQB7iYM4";
        public ActionResult Lista()
        {


            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");


            clienteHttp.DefaultRequestHeaders.Add("x-access-token", token);

            var request = clienteHttp.GetAsync("api/v1.0/admin/test");
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
            var listado = JsonConvert.DeserializeObject<TriajeResponse>(resultString);

            List<Triaje> listaTriaje = new List<Triaje>();
            foreach (var item in listado.triajes)
            {
                Triaje obj = new Triaje()
                {
                    test_id = item.test_id,
                    hora_registro = item.hora_registro,
                    ciudadano = item.ciudadano,
                    estado = item.estado,
                   
                };
                listaTriaje.Add(obj);
            }

            ViewBag.triajes = listaTriaje;

            return View();



        }
    }
}
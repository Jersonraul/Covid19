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
                    user_id = item.user_id,
                    doc_number = item.doc_number,
                    estado = item.estado,
                   
                };
                listaTriaje.Add(obj);
            }

            ViewBag.triajes = listaTriaje;

            return View();



        }


        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");
            clienteHttp.DefaultRequestHeaders.Add("x-access-token", token);
            var request = clienteHttp.GetAsync("api/v1.0/admin/test/" + id);
            request.Wait();
            var response = request.Result;

            if (response.IsSuccessStatusCode) { 
            var resultString = response.Content.ReadAsStringAsync().Result;
                TriajeResponseXid informacion = JsonConvert.DeserializeObject<TriajeResponseXid>(resultString);

                
                TriajeResponseXid tri = new TriajeResponseXid();
            tri = new TriajeResponseXid();
            tri.Estados = new List<SelectListItem> {
            new SelectListItem { Value="1", Text="Pendiente" },
            new SelectListItem { Value ="2", Text="Positivo" },
            new SelectListItem { Value ="3", Text="Negativo" }
            };

               /* if (tri.Estados != null)
                {
                    return PartialView("Actualizar", tri);
                   
                }*/
               
                //ViewData.Model = tri.Estados;

              /*  HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(download);
                List<List<string>> table = html.DocumentNode.SelectSingleNode("//table")
                       .Descendants("tr")
                       .Skip(1)
                       .Where(tr => tr.Elements("td").Count() > 1)
                       .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                       .ToList();


                table.ForEach(Console.WriteLine);*/

               
                return View(informacion);

            }
            return View();
        }



        [HttpPost]
        public ActionResult Actualizar(TriajeResponseXid triaje)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");
           // clienteHttp.DefaultRequestHeaders.Add("x-access-token", token);
            var request = clienteHttp.PutAsync("api/v1.0/admin/test", triaje, new JsonMediaTypeFormatter());
            request.Wait();
            var response = request.Result;

            var resultString = response.Content.ReadAsStringAsync().Result;
           // var registro = JsonConvert.DeserializeObject<string>(resultString);
            if (resultString != null)
            {
                return RedirectToAction("Lista");
            }
            return View(triaje);
        }

    }
}
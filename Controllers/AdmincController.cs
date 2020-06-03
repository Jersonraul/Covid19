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
    public class AdmincController : Controller
    {
        // GET: Adminc
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult LogIn()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult LogIn(Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Isvalid(admin.Email, admin.Password))
        //        {
        //            FormsAuthentication.SetAuthCookie(admin.Email, false);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("","Datos Incorrectos");
        //        }
        //    }
        //    return View(admin);
        //}

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index","Home");
        //}

        //private bool Isvalid(string Email, string password)
        //{
        //    HttpClient clienteHttp = new HttpClient();
        //    clienteHttp.BaseAddress = new Uri("https://covid19-pit.herokuapp.com/");

        //    var request = clienteHttp.GetAsync("api/v1.0/admin/signin");
        //    request.Wait();
        //    var response = request.Result;

        //    var resultString = response.Content.ReadAsStringAsync().Result;
        //    var listado = JsonConvert.DeserializeObject<AdminResponse>(resultString);

        //    //////////////////

        //    bool Isvalid = false;
        //   // using (var db = new MainDbContext())
        //    {
        //        //  var user = db.SystemUsers.FirstOrDefault(u => u.Email == Email); //consultar el primer registro con los el email del usuario
        //        var user = "admin@cibercovid.com";
        //        var pass = "cibercovid123";

        //        user.Equals(Email);
        //        if (user != null)
        //        {
        //            if (pass == password) //Verificar password del usuario
        //            {
        //                Isvalid = true;
        //            }
        //        }
        //    }
        //    return Isvalid;
        //}
        //private bool Isvalid(string Email, string password)
        //{
        //    bool Isvalid = false;
        //    using (var db = new MainDbContext())
        //    {
        //        var user = db.SystemUsers.FirstOrDefault(u => u.Email == Email); //consultar el primer registro con los el email del usuario
        //        if (user != null)
        //        {
        //            if (user.Password == password) //Verificar password del usuario
        //            {
        //                Isvalid = true;
        //            }
        //        }
        //    }
        //    return Isvalid;
        //}
    }

}
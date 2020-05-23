using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPCOVID.Models
{
    public class Administrador
    {
       
        public int IdAdmin { get; set; }
        
        public string Nombre { get; set; }

        internal class Root
        {
        }
        /* public string Apeliido { get; set; }
public int Telefono { get; set; }
public string Correo { get; set; }
public int IdRol { get; set; }*/
    }

    

}
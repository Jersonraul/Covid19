using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APPCOVID.Models
{
    public class Adminm
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        //}
        //public class AdminResponsee
        //{
        //    [JsonProperty("admins")]
        //    public List<Admin> sintomas { get; set; }
        //}
    }
}
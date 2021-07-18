using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Pages.Account
{
    public class RegistroModel : PageModel
    {
        public void OnGet()
        {
            MODEL_PACIENTE = new PACIENTE
            {

            }; 
        }

        [BindProperty]
        public PACIENTE MODEL_PACIENTE { get; set; }

        public class PACIENTE : MODELO_PACIENTE
        {
            public IFormFile AvatarImage { get; set; }
            //[TempData]
            //public string ErrorMessage { get; set; }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public USUARIO MODEL_USUARIO { get; set; }

        public class USUARIO : MOD_USUARIO
        {

        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Pages.Account
{
    public class CIE10Model : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private LCie10 _lCIE10;

        public CIE10Model(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _lCIE10 = new LCie10(context);
        }

        public IEnumerable<MODELO_CIE10> CIE10L { get; set; }

        public void OnGet(int id) //Pasar el id a traves de la variable PAC_ID del Paciente para proceder a ver el detalle
        {
            var Data = _lCIE10.get_CIE10_Async(null, id);
            if (0 < Data.Count)
            {
                MODEL_CIE10 = new CIE10
                {
                    DataCIE10 = Data.ToList().Last(),
                };
            }
        }

        [BindProperty]
        public CIE10 MODEL_CIE10 { get; set; }

        public class CIE10
        {
            public MODELO_CIE10 DataCIE10 { get; set; }
        }
    }
}

using System.Linq;
using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Pages.Account
{
    [Authorize]
    public class DetalleModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private LTratamiento _ltratamiento;

        public DetalleModel(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _ltratamiento = new LTratamiento(context);
        }

        public void OnGet(int id) //Pasar el id a traves de la variable TRA_ID del Paciente para proceder a ver el detalle
        {
            var Data = _ltratamiento.get_Tratamiento_Async(null, id);
            if (0 < Data.Count)
            {
                MODEL_TRATAMIENTO = new TRATAMIENTO
                {
                    DataTratamiento = Data.ToList().Last(),
                };
            }
        }

        [BindProperty]
        public TRATAMIENTO MODEL_TRATAMIENTO { get; set; }

        public class TRATAMIENTO
        {
            public MODELO_TRATAMIENTO DataTratamiento { get; set; }
        }
    }
}

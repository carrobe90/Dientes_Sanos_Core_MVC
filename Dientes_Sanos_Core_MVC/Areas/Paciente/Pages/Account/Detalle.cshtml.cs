using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Pages.Account
{
    [Authorize]
    public class DetalleModel : PageModel
    {

        private SignInManager<IdentityUser> _signInManager;
        private LPaciente _lPaciente;

        public DetalleModel(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _lPaciente = new LPaciente(context);
        }

        public void OnGet(int id) //Pasar el id a traves de la variable PAC_ID del Paciente para proceder a ver el detalle
        {
            var Data = _lPaciente.get_Paciente_Async(null, id,2);
            if (0 < Data.Count)
            {
                MODEL_PACIENTE = new PACIENTE
                {
                    DataPaciente = Data.ToList().Last(),
                };
            }
        }

        [BindProperty]
        public PACIENTE MODEL_PACIENTE { get; set; }

        public class PACIENTE
        {
            public MODELO_PACIENTE DataPaciente { get; set; }
        }
    }
}

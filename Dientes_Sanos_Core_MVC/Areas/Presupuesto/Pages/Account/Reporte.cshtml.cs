using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ReporteModel : PageModel
    {
        private LPresupuesto _Presupuesto;
        private static int idPresupuesto = 0;
        private static string _errorMessage;
        private ApplicationDbContext _context;
        private static PRESUPUESTO _dataPresupuesto;
        private UserManager<IdentityUser> _userManager;

        public ReporteModel(
            UserManager<IdentityUser> userManager,
            ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _Presupuesto = new LPresupuesto(context);
        }
        public IActionResult OnGet(int id)
        {
            if (idPresupuesto == 0)
            {
                idPresupuesto = id;
            }
            else
            {
                if(idPresupuesto != id)
                {
                    idPresupuesto = 0;
                    return Redirect("/Tratamiento/Tratamiento?area=Presupuesto");
                }
            }
           // _dataPresupuesto = _Presupuesto.getTPresupuestoReporte(id);
            return Page();
        }

        [BindProperty]
        public PRESUPUESTO MODEL_PRESUPUESTO { get; set; }

        public class PRESUPUESTO 
        {
            [TempData]
            public string ErrorMessage { get; set; }
        }
    }
}

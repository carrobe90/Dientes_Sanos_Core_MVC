using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Controllers;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Controllers
{
    [Authorize]
    [Area("Presupuesto")]
    public class PresupuestoController : Controller
    {
        private LPresupuesto _lpresupuesto;
        private ApplicationDbContext _Context;
        private SignInManager<IdentityUser> _signInManager;
        private static Modelo_Paginador<MODELO_PRESUPUESTO> MOD_PRE;

        public PresupuestoController(
          ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _Context = context;
            _lpresupuesto = new LPresupuesto(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Presupuesto()
        {
            if (_signInManager.IsSignedIn(User))
            {
                MOD_PRE = new Modelo_Paginador<MODELO_PRESUPUESTO>
                {
                    Input = new MODELO_PRESUPUESTO()
                };
                return View(MOD_PRE);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpGet("Reg_Presup")]
        public String Paciente_Presupuesto(String pac_pre)
        {
            return pac_pre;
        }

        [HttpPost]
        public JsonResult Get_Pieza_Lista(String PIE_DENT)
        {
            Console.WriteLine("RESUL-->" + PIE_DENT);
            var piezalista = _Context.TBL_PIEZA.Where(x => x.PIE_DENT.Equals(PIE_DENT)).OrderBy(x => x.PIE_ID).ToList();
            return Json(piezalista);
        }

        //[HttpPost]
        //public String Get_Presupuesto(Modelo_Paginador<MODELO_PRESUPUESTO> MOD_PRE)
        //{
        //    if (MOD_PRE.Input.PRE_COD_PAC != null && MOD_PRE.Input.PRE_COD != null)
        //    {
        //        var data = _lpresupuesto.Guardar_Presupuesto(MOD_PRE.Input);
        //        return JsonConvert.SerializeObject(data);
        //    }
        //    else
        //    {
        //        return "Llene los campos requeridos";
        //    }
        //}

        public JsonResult Get_Valor_Tratamiento(String TRA_CONCEPTO)
        {
            Console.WriteLine("RESUL-->" + TRA_CONCEPTO);
            var valorlista = _Context.TBL_TRATAMIENTO.Where(x => x.TRA_CONCEPTO.Equals(TRA_CONCEPTO) && x.TRA_ESTADO.Equals("V")).ToList();
            return Json(valorlista);
        }

    }
}

using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Authorization;
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
        
        private ApplicationDbContext _Context;

        public PresupuestoController(
          ApplicationDbContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        public JsonResult Get_Valor_Tratamiento(String TRA_CONCEPTO)
        {
            Console.WriteLine("RESUL-->" + TRA_CONCEPTO);
            var valorlista = _Context.TBL_TRATAMIENTO.Where(x => x.TRA_CONCEPTO.Equals(TRA_CONCEPTO) && x.TRA_ESTADO.Equals("V")).ToList();
            return Json(valorlista);
        }

    }
}

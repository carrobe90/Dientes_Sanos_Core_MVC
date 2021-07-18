using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Controllers
{
    [Authorize]
    [Area("Paciente")]
    public class PacienteController : Controller
    {
        public IActionResult Paciente()
        {
            return View();
        }
    }
}

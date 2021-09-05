using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Controllers
{
    [Authorize]
    [Area("Paciente")]
    public class PacienteController : Controller
    {
        private LPaciente _paciente;
        private SignInManager<IdentityUser> _signInManager;
        private static Modelo_Paginador<MODELO_PACIENTE> models;

        public PacienteController(
           SignInManager<IdentityUser> signInManager,
           ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _paciente= new LPaciente(context);
        }

        // IActionResult #Nombre --> Nombre del Controlador

        public IActionResult Paciente(int id, String filtrar)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _paciente.get_Pacientes_Async(filtrar, 0);
                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<MODELO_PACIENTE>().Paginador(data,
                        id, 10, "Paciente", "Paciente", "Paciente", url);
                    //(data,id,10,Area,Controlador,Metodo de Accion,url)
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<MODELO_PACIENTE>();
                }
                models = new Modelo_Paginador<MODELO_PACIENTE>
                {
                    List = (List<MODELO_PACIENTE>)objects[2],
                    Pagi_info = (String)objects[0],
                    Pagi_navegacion = (String)objects[1],
                    Input = new MODELO_PACIENTE(),
                };
                return View(models);
            }
            else
            {
                return Redirect("/");
            }

        }
      
    }
}

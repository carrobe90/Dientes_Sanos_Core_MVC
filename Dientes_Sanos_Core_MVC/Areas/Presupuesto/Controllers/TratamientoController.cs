using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Controllers
{
    [Authorize]
    [Area("Presupuesto")]
    public class TratamientoController : Controller
    {

        private LTratamiento _tratamiento;
        private SignInManager<IdentityUser> _signInManager;
        private static Modelo_Paginador<MODELO_TRATAMIENTO> models;

        public TratamientoController(
           SignInManager<IdentityUser> signInManager,
           ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _tratamiento = new LTratamiento(context);
        }

        // IActionResult #Nombre --> Nombre del Controlador

        public IActionResult Tratamiento(int id, String filtrar)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _tratamiento.get_Tratamiento_Async(filtrar, 0);
                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<MODELO_TRATAMIENTO>().Paginador(data,
                        id, 30, "Presupuesto", "Tratamiento", "Tratamiento", url);
                    //(data,id,10,Area,Controlador,Metodo de Accion,url)
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<MODELO_TRATAMIENTO>();
                }
                models = new Modelo_Paginador<MODELO_TRATAMIENTO>
                {
                    List = (List<MODELO_TRATAMIENTO>)objects[2],
                    Pagi_info = (string)objects[0],
                    Pagi_navegacion = (string)objects[1],
                    Input = new MODELO_TRATAMIENTO(),
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

using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Controllers
{
    [Authorize]
    [Area("Paciente")]
    public class CIE10Controller : Controller
    {

        private LCie10 _CIE10;
        private SignInManager<IdentityUser> _signInManager;
        private static Modelo_Paginador<MODELO_CIE10> models;

        public CIE10Controller(
         SignInManager<IdentityUser> signInManager,
         ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _CIE10 = new LCie10(context);
        }

        public IActionResult CIE10(int id, String filtrar)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _CIE10.get_CIE10_Async(filtrar, 0);
                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<MODELO_CIE10>().Paginador(data,
                        id, 12, "Paciente", "CIE10", "CIE10", url);
                    //(data,id,10,Area,Controlador,Metodo de Accion,url)
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<MODELO_CIE10>();
                }
                models = new Modelo_Paginador<MODELO_CIE10>
                {
                    List = (List<MODELO_CIE10>)objects[2],
                    Pagi_info = (String)objects[0],
                    Pagi_navegacion = (String)objects[1],
                    Input = new MODELO_CIE10(),
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

using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {

        private SignInManager<IdentityUser> _signInManager;
        private LUser _user;
        private static Modelo_Paginador<MOD_USUARIO> models;

        public UsersController(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _user = new LUser(userManager,signInManager,roleManager,context);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users(int idbusq, String filtrar)
        {
            //if(_signInManager.IsSignedIn(User))
            //{
            Object[] Objeto = new object[3];
            var data = _user.get_Usuario_Async(filtrar, 0);
            if (0 < data.Result.Count)
            {
                var url = Request.Scheme + "://" + Request.Host.Value;
                Objeto = new LPaginador<MOD_USUARIO>().Paginador(data.Result, 
                    idbusq, 10, "Users", "Users", "Users", url);
            }
            else
            {
                Objeto[0] = "No Existen Datos";
                Objeto[1] = "No Existen Datos";
                Objeto[2] = new List<MOD_USUARIO>();
            }
            models = new Modelo_Paginador<MOD_USUARIO>
            {
                List = (List<MOD_USUARIO>)Objeto[2],
                Pagi_info = (String)Objeto[0],
                Pagi_navegacion = (String)Objeto[1],
                Input = new MOD_USUARIO(),
            }; return View(models);
            //}
            //else
            //{
            //    return Redirect("/");
            //}
        }
    }
}

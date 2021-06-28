using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //IServiceProvider _serviceProvider;

        //public HomeController(IServiceProvider serviceProvider)
        //{
        //    //_serviceProvider = serviceProvider;
        //}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public async Task<IActionResult> Index()
        //{
        //    //await Crear_Roles_Async(_serviceProvider);
        //    return View();
        //}

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task Crear_Roles_Async(IServiceProvider serviceProvider)
        {

            //SOLO SE USA PARA GENERAR LOS ROLES EN LA TABLA ASPNETROLES, POSTERIOR
            //A ESTO NO SERA USADO.
            var roles_Manager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            String[] roles_Nombre = { "ADMIN", "USER" };
            foreach (var item in roles_Nombre)
            {
                var rol_Existencia = await roles_Manager.RoleExistsAsync(item);
                if (!rol_Existencia)
                {
                    await roles_Manager.CreateAsync(new IdentityRole(item));
                }
            }
        }
    }
}

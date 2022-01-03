using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            //var dashboard = new DashboardViewModel
            return View();
        }
    }
}

using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dientes_Sanos_Core_MVC.Controllers
{
    public class OdontologoController : Controller
    {

        private readonly ApplicationDbContext _context;

        public OdontologoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Https Get Index
        public IActionResult Index()
        {
           IEnumerable<Clase_Modelo_Odontologo> list_odontologo = _context.Modelo_Odontologo;
            return View(list_odontologo);
        }
         
        //Http Get Create
        public IActionResult Create()
        {            
            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Clase_Modelo_Odontologo odontologo)
        {
            if(ModelState.IsValid)
            {
                _context.Modelo_Odontologo.Add(odontologo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

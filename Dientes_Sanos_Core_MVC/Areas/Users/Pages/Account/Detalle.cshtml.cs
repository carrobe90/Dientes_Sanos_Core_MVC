using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Pages.Account
{
    public class DetalleModel : PageModel
    {

        private SignInManager<IdentityUser> _signInManager;
        private LUser _lUser;

        public DetalleModel(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _lUser = new LUser(userManager, signInManager, roleManager, context);
        }

        public void OnGet(int id)
        {
            var Data = _lUser.get_Usuario_Async(null, id);
            if(0< Data.Result.Count)
            {
                MODEL_USUARIO = new USUARIO
                {
                    DataUser = Data.Result.ToList().Last(),
                };
            }
        }

        [BindProperty]
        public USUARIO MODEL_USUARIO { get; set; }

        public class USUARIO
        {
            public MOD_USUARIO DataUser { get; set; }
        }
    }
}

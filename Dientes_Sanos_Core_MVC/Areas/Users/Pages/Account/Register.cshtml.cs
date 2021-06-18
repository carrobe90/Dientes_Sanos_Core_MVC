using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LUserRoles _usersRole;

        public RegisterModel(
            SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _usersRole = new LUserRoles();
        }

        public void OnGet()
        {
            MODEL_USUARIO = new USUARIO
            {
                rolesLista = _usersRole.GetRoles(_roleManager)
            };
        }

        [BindProperty]
        public USUARIO MODEL_USUARIO { get; set; }

        public class USUARIO : MOD_USUARIO
        {
            public IFormFile AvatarImage { get; set; }

            [TempData]
            public string ErrorMessage { get; set; }

            public List<SelectListItem> rolesLista { get; set; }
        }
    }
}

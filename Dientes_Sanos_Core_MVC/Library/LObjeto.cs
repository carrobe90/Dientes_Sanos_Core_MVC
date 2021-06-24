using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LObjeto
    {
        public LUserRoles _userRoles;
        public IdentityError _identityError;
        public ApplicationDbContext _context;
        public IWebHostEnvironment _environment;
        public SignInManager<IdentityUser> _signInManager;
        public UserManager<IdentityUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
    }
}

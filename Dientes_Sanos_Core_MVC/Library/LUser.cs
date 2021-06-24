using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LUser: LObjeto
    {

        public LUser(
            UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _userRoles = new LUserRoles();
        }

        public async Task<List<MOD_USUARIO>> getUsuarioAsync (string valor,int id)
        {
            List<MOD_USUARIO> modelo_Usuario;
            List<SelectListItem> _listRoles;
            List<MOD_USUARIO> userLista = new List<MOD_USUARIO>();
            if(valor == null && id.Equals(0))
            {
                modelo_Usuario = _context.TBL_USUARIO.ToList();
            }
            else
            {
                if(id.Equals(0))
                {
                    modelo_Usuario = _context.TBL_USUARIO.Where(u => u.USER_RUT.StartsWith(valor) || u.USER_NOMBRE.StartsWith(valor)
                    || u.USER_APELLIDO.StartsWith(valor) || u.USER_EMAIL.StartsWith(valor)).ToList();
                }
                else
                {
                    modelo_Usuario = _context.TBL_USUARIO.Where(u => u.USER_ID.Equals(id)).ToList();
                }
            }
            if(!modelo_Usuario.Count.Equals(0))
            {
                foreach(var item in modelo_Usuario)
                {
                    _listRoles = await _userRoles.GetRoles(_userManager, _roleManager, item.USER_ID.ToString());
                    userLista.Add(new MOD_USUARIO
                    {
                        USER_ID = item.USER_ID,
                        USER_APELLIDO = item.USER_APELLIDO,
                        USER_NOMBRE = item.USER_NOMBRE,
                        USER_EMAIL = item.USER_EMAIL,
                        USER_CELULAR = item.USER_CELULAR,
                        USER_IMAGE = item.USER_IMAGE,
                        USER_ROL = _listRoles[0].Text,
                        USER_RUT = item.USER_RUT,
                        USER_PASS = item.USER_PASS
                    }); ;
                }
            }
        }

    }
}

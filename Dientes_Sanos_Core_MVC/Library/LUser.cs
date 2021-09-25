using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesSystem.Areas.Users.Models;
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

        public async Task<List<MOD_USUARIO>> get_Usuario_Async(String valor, int id)
        {
            List<MODELO_USUARIO> modelo_Usuario;
            List<SelectListItem> _lista_Roles;
            List<MOD_USUARIO> userLista = new List<MOD_USUARIO>();
            if (valor == null && id.Equals(0))
            {
                modelo_Usuario = _context.TBL_USUARIO.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    modelo_Usuario = _context.TBL_USUARIO.Where(u => u.USER_RUT.StartsWith(valor) || u.USER_NOMBRE.StartsWith(valor)
                    || u.USER_APELLIDO.StartsWith(valor) || u.USER_EMAIL.StartsWith(valor)).ToList();
                }
                else
                {
                    modelo_Usuario = _context.TBL_USUARIO.Where(u => u.USER_ID.Equals(id)).ToList();
                }
            }
            if (!modelo_Usuario.Count.Equals(0))
            {
                foreach (var item in modelo_Usuario)
                {
                    //METODO ASICRONO EN DONDE SELECCIONA LA VARIABLE DE TIPO STRING USER_ID_USER
                    _lista_Roles = await _userRoles.GetRoles(_userManager, _roleManager, item.USER_ID_USER);
                    var user = _context.Users.Where(u => u.Id.Equals(item.USER_ID_USER)).ToList().Last();
                    userLista.Add(new MOD_USUARIO
                    {
                        Id = item.USER_ID,
                        ID = item.USER_ID_USER,
                        NID = item.USER_RUT,
                        Name = item.USER_NOMBRE,
                        LastName = item.USER_APELLIDO,
                        Email = item.USER_EMAIL,
                        Role = _lista_Roles[0].Text,
                        Image = item.USER_IMAGE,
                        IdentityUser = user
                    });
                    _lista_Roles.Clear();
                }
            }
            return userLista;
        }

        internal async Task<SignInResult> Usuario_Login_Async(MOD_LOGIN model)
        {
            var resultado = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure:false);
            if(resultado.Succeeded)
            {

            }
            return resultado;
        }

    }
}

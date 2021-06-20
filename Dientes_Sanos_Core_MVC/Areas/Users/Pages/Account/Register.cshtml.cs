using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LUserRoles _usersRole;
        private static USUARIO _dataInput;
        private IWebHostEnvironment _environment;
        private LCargarImagen _lCargarImagen;
        private ApplicationDbContext _context;

        public RegisterModel(
            SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ApplicationDbContext context,
        IWebHostEnvironment environment
        )
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _usersRole = new LUserRoles();
            _lCargarImagen = new LCargarImagen();
        }

        public void OnGet()
        {
            if (_dataInput != null)
            {
                MODEL_USUARIO = _dataInput;
                MODEL_USUARIO.rolesLista = _usersRole.GetRoles(_roleManager);
                MODEL_USUARIO.AvatarImage = null;
            }
            else
            {
                MODEL_USUARIO = new USUARIO
                {
                    rolesLista = _usersRole.GetRoles(_roleManager)
                };
            }
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

        public async Task<ActionResult> OnPost()
        {
            if(await SaveAsync())
            {
                return Redirect("/Users/Users?=area=Users");
            }
            else
            {
                return Redirect("/Users/Register");
            }
        }

        private async Task<bool> SaveAsync()
        {
            _dataInput = MODEL_USUARIO;
            var valor = false;
            //if (ModelState.IsValid)
                if (!MODEL_USUARIO.USER_ROL.Equals("Seleccione un Rol"))
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(MODEL_USUARIO.USER_EMAIL)).ToList();
                if(userList.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy();
                    await strategy.ExecuteAsync(async() =>{
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                var user = new IdentityUser
                                {
                                    UserName = MODEL_USUARIO.USER_EMAIL,
                                    Email = MODEL_USUARIO.USER_EMAIL,
                                    PhoneNumber = MODEL_USUARIO.USER_CELULAR
                                };
                                var result = await _userManager.CreateAsync(user, MODEL_USUARIO.USER_PASS);
                                if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(user, MODEL_USUARIO.USER_ROL);
                                    var dataUser = _userManager.Users.Where(u => u.Email.Equals(MODEL_USUARIO.USER_EMAIL)).ToList().Last();
                                    var imagenByte = await _lCargarImagen.ByteAvatarImageAsync(MODEL_USUARIO.AvatarImage, _environment, "images/user_icon.png");
                                    var Nuevo_User = new MOD_USUARIO
                                    {
                                        USER_NOMBRE = _dataInput.USER_NOMBRE,
                                        USER_APELLIDO = _dataInput.USER_APELLIDO,
                                        USER_EMAIL = _dataInput.USER_EMAIL,
                                        USER_RUT = _dataInput.USER_RUT,
                                        USER_IMAGE = _dataInput.USER_IMAGE,
                                        USER_PASS = _dataInput.USER_PASS,
                                        USER_CELULAR = _dataInput.USER_CELULAR
                                    };
                                    await _context.AddAsync(Nuevo_User);
                                    _context.SaveChanges();
                                    transaction.Commit();
                                    _dataInput = null;
                                    valor = true;
                                }
                                else
                                {
                                    foreach(var item in result.Errors)
                                    {
                                        _dataInput.ErrorMessage = item.Description;
                                    }
                                    valor = false;
                                    transaction.Rollback();
                                }
                            }
                            catch (Exception ex)
                            {
                                _dataInput.ErrorMessage = ex.Message;
                                transaction.Rollback();
                                valor = false;  
                            }
                        }
                    });
                }
                else
                {
                    _dataInput.ErrorMessage = $"El {MODEL_USUARIO.USER_EMAIL} ya se encuentra Registrado";
                }
            }
            else
            {
                _dataInput.ErrorMessage = "Selecione un Rol Por Favor!";
                valor = false;
            }
            return valor;

        }
    }
}

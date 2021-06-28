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
using Newtonsoft.Json;
using SalesSystem.Areas.Users.Models;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LUserRoles _usersRole;
        private static USUARIO _dataInput;
        private static MOD_USUARIO _DataUser1, _DataUser2;
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
                MODEL_USUARIO.roles_Lista = _usersRole.GetRoles(_roleManager);
                MODEL_USUARIO.AvatarImage = null;
            }
            else
            {
                MODEL_USUARIO = new USUARIO
                {
                    roles_Lista = _usersRole.GetRoles(_roleManager)
                };
            }
            if (_DataUser1 != null)
            {
                MODEL_USUARIO = new USUARIO
                {
                    Name = _DataUser1.Name,
                    LastName = _DataUser1.LastName,
                    NID = _DataUser1.NID,
                    Email = _DataUser1.Email,
                    Image = _DataUser1.Image,
                    PhoneNumber = _DataUser1.IdentityUser.PhoneNumber,
                    roles_Lista = Get_Roles(_DataUser1.Role),
                };
            }
            _DataUser2 = _DataUser1;
            _DataUser1 = null;
        }

        [BindProperty]
        public USUARIO MODEL_USUARIO { get; set; }

        public class USUARIO : MOD_USUARIO
        {
            public IFormFile AvatarImage { get; set; }

            [TempData]
            public string ErrorMessage { get; set; }

            public List<SelectListItem> roles_Lista { get; set; }
        }

        public async Task<ActionResult> OnPost(String dataUsuario)
        {
            //variable "dataUsuario" debe ser estar declarada en el boton editar con el mismo nombre
            //en la varaible "name" caso contrario arrojara siempre un valor nulo.
            if (dataUsuario == null)
            {
                if (await Guardar_Usuario_Async())
                {
                    return Redirect("/Users/Users?area=Users");
                }
                else
                {
                    return Redirect("/Users/Registro");
                }
            }
            else
            {
                _DataUser1 = JsonConvert.DeserializeObject<MOD_USUARIO>(dataUsuario);
                return Redirect("/Users/Registro");
            }
        }

        private List<SelectListItem> Get_Roles(string rol)
        {
            List<SelectListItem> Lista_Roles = new List<SelectListItem>();
            Lista_Roles.Add(new SelectListItem
            {
                Text = rol
            });
            var Roles = _usersRole.GetRoles(_roleManager);
            Roles.ForEach(item =>
            {
                if (item.Text != rol)
                {
                    Lista_Roles.Add(new SelectListItem
                    {
                        Text = item.Text
                    });
                }
            });
            return Lista_Roles;

        }

        private async Task<bool> Actualizar_Usuario_Async()
        {
            var valor = false;
            byte[] imageByte = null;
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () => {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var identityUser = _userManager.Users.Where(u => u.Id.Equals(_DataUser2.ID)).ToList().Last();
                        identityUser.UserName = MODEL_USUARIO.Email;
                        identityUser.Email = MODEL_USUARIO.Email;
                        identityUser.PhoneNumber = MODEL_USUARIO.PhoneNumber;
                        _context.Update(identityUser);
                        await _context.SaveChangesAsync();

                        if (MODEL_USUARIO.AvatarImage == null)
                        {
                            imageByte = _DataUser2.Image;
                        }
                        else
                        {
                            imageByte = await _lCargarImagen.ByteAvatarImageAsync(MODEL_USUARIO.AvatarImage, _environment, "");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            });
            return valor;
        }

        private async Task<bool> Guardar_Usuario_Async()
        {
            _dataInput = MODEL_USUARIO;
            var valor = false;
            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(MODEL_USUARIO.Email)).ToList();
                if (userList.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy();
                    await strategy.ExecuteAsync(async () =>
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                var usuarioaspnet = new IdentityUser
                                {
                                    UserName = MODEL_USUARIO.Email,
                                    Email = MODEL_USUARIO.Email,
                                    PhoneNumber = MODEL_USUARIO.PhoneNumber
                                };
                                var result = await _userManager.CreateAsync(usuarioaspnet, MODEL_USUARIO.Password);
                                if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(usuarioaspnet, MODEL_USUARIO.Role);
                                    var dataUser = _userManager.Users.Where(u => u.Email.Equals(MODEL_USUARIO.Email)).ToList().Last();
                                    var imagenByte = await _lCargarImagen.ByteAvatarImageAsync(MODEL_USUARIO.AvatarImage, _environment, "images/user_icon.png");
                                    var Nuevo_Usuario = new MODELO_USUARIO
                                    {
                                        USER_NOMBRE = _dataInput.Name,
                                        USER_APELLIDO = _dataInput.LastName,
                                        USER_EMAIL = _dataInput.Email,
                                        USER_RUT = _dataInput.NID,
                                        USER_IMAGE = imagenByte,
                                        USER_PASS = _dataInput.Password,
                                        USER_ROL = _dataInput.Role,
                                        USER_ID_USER = dataUser.Id,
                                        USER_CELULAR = _dataInput.PhoneNumber
                                    };
                                    await _context.AddAsync(Nuevo_Usuario);
                                    _context.SaveChanges();
                                    transaction.Commit();
                                    _dataInput = null;
                                    valor = true;
                                }
                                else
                                {
                                    foreach (var item in result.Errors)
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
                    _dataInput.ErrorMessage = $"El {MODEL_USUARIO.Email} ya se encuentra Registrado";
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _dataInput.ErrorMessage += error.ErrorMessage;
                    }
                }
                valor = false;
            }
            return valor;

        }
    }
}

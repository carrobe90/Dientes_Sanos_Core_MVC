using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Authorization;
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

    [Area("Users")]
    [Authorize] //SOLO USUARIOS AUTENTICADOS TENDRAN ACCESO A LA OPCIONES DEL SISTEMA
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

        public void OnGet(int idActUsu)
        {
            _DataUser2 = null;
            if (idActUsu.Equals(0))
            {
                _DataUser2 = null;
            }
            if (_dataInput != null || _DataUser1!= null || _DataUser2!= null)
            {
                if (_dataInput != null)
                {
                    MODEL_USUARIO = _dataInput;
                    MODEL_USUARIO.roles_Lista = _usersRole.GetRoles(_roleManager);
                    MODEL_USUARIO.AvatarImage = null;
                }
                else
                {
                    if(_DataUser1 != null || _DataUser2 != null)
                    {
                        if (_DataUser2 != null)
                       
                            _DataUser1 = _DataUser2;
                            MODEL_USUARIO = new USUARIO
                            {
                                Id = _DataUser1.Id,
                                Name = _DataUser1.Name,
                                LastName = _DataUser1.LastName,
                                NID = _DataUser1.NID,
                                Email = _DataUser1.Email,
                                Image = _DataUser1.Image,
                                Password = _DataUser1.Password,
                                PhoneNumber = _DataUser1.IdentityUser.PhoneNumber,
                                roles_Lista = Get_Roles(_DataUser1.Role),
                            };
                        
                        if(_dataInput != null)
                        {
                            MODEL_USUARIO.ErrorMessage = _dataInput.ErrorMessage;
                        }
                    }
                }
            }
            else
            {
                MODEL_USUARIO = new USUARIO
                {
                    roles_Lista = _usersRole.GetRoles(_roleManager)
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
            //[TempData]
            //public string ErrorMessage { get; set; }

            public List<SelectListItem> roles_Lista { get; set; }
        }

        public async Task<IActionResult> OnPost(String dataUsuario)
        {
            //variable "dataUsuario" debe ser estar declarada en el boton editar con el mismo nombre
            //en la varaible "name" caso contrario arrojara siempre un valor nulo.
            if (dataUsuario == null)
            {
                if (_DataUser2 == null)
                {
                    if (User.IsInRole("ADMIN"))
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
                        return Redirect("/Users/Users?area=Users");
                    }
                }
                else
                {
                    if (User.IsInRole("ADMIN"))
                    {
                        if (await Actualizar_Usuario_Async())
                        {
                            var url = $"/Users/Account/Detalle?idActUsu={_DataUser2.Id}";
                            _DataUser2 = null;
                            return Redirect(url);
                        }
                        else
                        {
                            return Redirect("/Users/Registro");
                        }
                    }
                    else
                    {
                        return Redirect("/Users/Users?area=Users");
                    }
                }
            }
            else
            {
                _DataUser1 = JsonConvert.DeserializeObject<MOD_USUARIO>(dataUsuario);
                return Redirect("/Users/Registro?idActUsu=1");
                //el parametro que pasa en la url --> idActUsu debe ser el mismo de la
                //variable que hace la verificacion en el metodo OnGet
            }
            //if (dataUsuario == null) // CONDICIION PARA REGISTRAR USUARIOS SIN VALIDACION EN EL SISTEMA
            //{
            //    if (await Guardar_Usuario_Async())
            //    {
            //        return Redirect("/Users/Users?area=Users");
            //    }
            //}
            //else
            //{ }
            //return Redirect("/Users/Registro?idActUsu=1");
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

        //[Authorize(Roles = "ADMIN")] // Solo administradores podrán guardar información
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
                       
                        var ds_user = new MODELO_USUARIO
                        {
                            USER_ID = _DataUser2.Id,
                            USER_NOMBRE = MODEL_USUARIO.Name,
                            USER_APELLIDO = MODEL_USUARIO.LastName,
                            USER_RUT = MODEL_USUARIO.NID,
                            USER_CELULAR = MODEL_USUARIO.PhoneNumber,
                            USER_EMAIL = MODEL_USUARIO.Email,
                            USER_ID_USER = _DataUser2.ID,
                            USER_PASS = MODEL_USUARIO.Password,
                            USER_IMAGE = imageByte,
                        };
                        var usuario_pass = await _userManager.FindByIdAsync(_DataUser2.ID);
                        var code = await _userManager.GeneratePasswordResetTokenAsync(usuario_pass);
                        var resultado = await _userManager.ResetPasswordAsync(usuario_pass, code, MODEL_USUARIO.Password);
                        _context.Update(ds_user);
                        _context.SaveChanges();
                        if(_DataUser2.Role!= MODEL_USUARIO.Role)
                        {
                            await _userManager.RemoveFromRoleAsync(identityUser, _DataUser2.Role);
                            await _userManager.AddToRoleAsync(identityUser, MODEL_USUARIO.Role);
                        }
                        transaction.Commit();
                        valor = true;
                    }
                    catch (Exception ex)
                    {
                        _dataInput.ErrorMessage = ex.Message;
                        transaction.Rollback();
                        valor = false;
                    }
                }
            });
            return valor;
        }

        //[Authorize(Roles = "ADMIN")] // Solo administradores podrán guardar información
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
                    _dataInput.ErrorMessage = $"El Correo {MODEL_USUARIO.Email} ya se encuentra Registrado";
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

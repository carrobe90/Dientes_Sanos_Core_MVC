using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
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

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Pages.Account
{
    [Authorize]
    [Area("Paciente")]
    public class RegistroModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LPacienteGen _lPacienteGen;
        private LOdontologo _lOdontologo;
        private LComuna _lComuna;
        private static PACIENTE _dataInput;
        private static MODELO_PACIENTE _DataPac1, _DataPac2;
        private IWebHostEnvironment _environment;
        private LCargarImagen _lCargarImagen;
        private ApplicationDbContext _context;

        public RegistroModel(
             SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
         ApplicationDbContext context,
        IWebHostEnvironment environment
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
            _roleManager = roleManager;
            _context = context;
            _lComuna = new LComuna();
            _lOdontologo = new LOdontologo();
            _lPacienteGen = new LPacienteGen();
            _lCargarImagen = new LCargarImagen();
        }


        public void OnGet(int idActPac)
        {
            var Cod_Pac = 0;
            String TempCodPac = null;
            var Ultimo_Paciente = (from t in _context.TBL_PACIENTE
                                   orderby t.PAC_CODIGO
                                   select t).LastOrDefault();
            if (Ultimo_Paciente != null)
            {
                Cod_Pac = (Ultimo_Paciente.PAC_CODIGO != null) ?
                       Convert.ToInt32(Ultimo_Paciente.PAC_CODIGO) + 1 :
                       1;
                if (Cod_Pac < 10)
                {
                    TempCodPac = String.Concat("0000", Convert.ToString(Cod_Pac));
                }
                else if (Cod_Pac > 10 && Cod_Pac < 100)
                {
                    TempCodPac = String.Concat("000", Convert.ToString(Cod_Pac));
                }
                else if (Cod_Pac > 100 && Cod_Pac < 1000)
                {
                    TempCodPac = String.Concat("00", Convert.ToString(Cod_Pac));
                }
                else if (Cod_Pac > 1000 && Cod_Pac < 10000)
                {
                    TempCodPac = String.Concat("0", Convert.ToString(Cod_Pac));
                }
            }
            MODEL_PACIENTE = new PACIENTE
            {
                PAC_CODIGO = TempCodPac,
                Genero_Lista = _lPacienteGen.GetGenero(_context),
                Comuna_Lista = _lComuna.GetComuna(_context),
                Odontologo_Lista = _lOdontologo.GetOdontologo(_context),
                PAC_COD_ODONT = "00000"
        };
        }

        public async Task<ActionResult> OnPost(String dataPaciente)
        {
            //variable "dataPaciente" debe ser estar declarada en el boton editar con el mismo nombre
            //en la variable "name" caso contrario arrojara siempre un valor nulo.
            if (dataPaciente == null)
            {
                if (_DataPac2 == null)
                {
                    if (User.IsInRole("ADMIN"))
                    {
                        if (await Guardar_Paciente_Async())
                        {
                            return Redirect("/Paciente/Paciente?area=Paciente");
                        }
                        else
                        {
                            return Redirect("/Paciente/Registro");
                        }
                    }
                    else
                    {
                        return Redirect("/Paciente/Paciente?area=Paciente");

                    }
                }
                else
                {
                    if (User.IsInRole("ADMIN"))
                    {
                        //if (await Actualizar_Paciente_Async())
                        //{
                        //    var url = $"/Paciente/Account/Detalle?idActPac={_DataPac2.PAC_ID}";
                        //    _DataPac2 = null;
                        //    return Redirect(url);
                        //}
                        //else
                        //{
                        //    return Redirect("/Users/Registro");
                        //}
                    }
                    else
                    {
                        return Redirect("/Paciente/Paciente?area=Paciente");
                    }
                }
            }
            else
            {
                _DataPac1 = JsonConvert.DeserializeObject<MODELO_PACIENTE>(dataPaciente);
                return Redirect("/Paciente/Registro?idActPac=1");
                //el parametro que pasa en la url --> idActPac debe ser el mismo de la
                //variable que hace la verificacion en el metodo OnGet
            }
            return Redirect("/Paciente/Registro?idActPac=1");
        }

        private async Task<bool> Guardar_Paciente_Async()
        {
            _dataInput = MODEL_PACIENTE;
            var valor = false;
            if (ModelState.IsValid)
            {
                var PacLista = _context.TBL_PACIENTE.Where(u => u.PAC_RUT.Equals(MODEL_PACIENTE.PAC_RUT)).ToList();
                if (PacLista.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy();
                    await strategy.ExecuteAsync(async () =>
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                var imagenByte = await _lCargarImagen.ByteAvatarImageAsync(MODEL_PACIENTE.AvatarImage, _environment, "images/user_icon.png");
                                string TmpCodPac = _dataInput.PAC_COD_ODONT;
                                String vfCodPac = TmpCodPac.Substring(0, 4);
                                var Nuevo_Paciente = new MODELO_PACIENTE
                                {
                                    PAC_CODIGO = _dataInput.PAC_CODIGO,
                                    PAC_NOMBRE = _dataInput.PAC_NOMBRE.ToUpper(),
                                    PAC_APELLIDO = _dataInput.PAC_APELLIDO.ToUpper(),
                                    PAC_SEXO = _dataInput.PAC_SEXO,
                                    PAC_RUT = _dataInput.PAC_RUT,
                                    PAC_FECHA_NAC = _dataInput.PAC_FECHA_NAC,
                                    PAC_EDAD = _dataInput.PAC_EDAD,
                                    PAC_REPRESENTANTE = _dataInput.PAC_REPRESENTANTE.ToUpper(),
                                    PAC_DIRECCION = _dataInput.PAC_DIRECCION.ToUpper(),
                                    PAC_COMUNA = _dataInput.PAC_COMUNA,
                                    PAC_OTRAS_COMUNAS = _dataInput.PAC_OTRAS_COMUNAS.ToUpper(),
                                    PAC_TELEFONO = _dataInput.PAC_TELEFONO,
                                    PAC_CORREO = _dataInput.PAC_CORREO,
                                    PAC_CONVENIO = _dataInput.PAC_CONVENIO.ToUpper(),
                                    PAC_PREVISIONES = _dataInput.PAC_PREVISIONES.ToUpper(),
                                    PAC_OBSERVACIONES = _dataInput.PAC_OBSERVACIONES.ToUpper(),
                                    PAC_COD_ODONT = vfCodPac,
                                    PAC_IMAGEN = imagenByte,
                                    PAC_FEC_REG = DateTime.Now,
                                    PAC_FEC_ACT = DateTime.Now

                                };
                                await _context.AddAsync(Nuevo_Paciente);
                                _context.SaveChanges();
                                transaction.Commit();
                                _dataInput = null;
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
                }
                else
                {
                    _dataInput.ErrorMessage = $"El RUT {MODEL_PACIENTE.PAC_RUT} ya se encuentra Registrado";
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

         

        [BindProperty]
        public PACIENTE MODEL_PACIENTE { get; set; }

        public class PACIENTE : MODELO_PACIENTE
        {
            public IFormFile AvatarImage { get; set; }
            //[TempData]
            //public string ErrorMessage { get; set; }
            public List<SelectListItem> Genero_Lista { get; set; }
            public List<SelectListItem> Comuna_Lista { get; set; }
            public List<SelectListItem> Odontologo_Lista { get; set; }
        }




    }
}

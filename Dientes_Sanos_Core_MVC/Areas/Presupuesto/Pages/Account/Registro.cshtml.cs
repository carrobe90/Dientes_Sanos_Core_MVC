using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Dientes_Sanos_Core_MVC.Areas.Presupuesto.Pages.Account.DetalleModel;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Pages.Account
{
    [Authorize]
    [Area("Presupuesto")]
    public class RegistroModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private static TRATAMIENTO _dataInput;
        private static MODELO_TRATAMIENTO _DataTrat1, _DataTrat2;
        private IWebHostEnvironment _environment;
        private LTratamiento _lTratamiento;
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
            _lTratamiento = new LTratamiento(context);
        }


        public void OnGet(int idActTrat)
        {
            //_DataTrat2 = null;
            if (idActTrat.Equals(0))
            {
                _DataTrat2 = null;
            }
            if (idActTrat.Equals(1))
            {
                _dataInput = null;
            }
            if (_dataInput != null || _DataTrat1 != null || _DataTrat2 != null)
            {
                if (_dataInput != null)
                {  //IF PARA SABER SI _DATAINPUT CONTIENE DATOS. SI CONTIENE SE PROSIGUE CON LAS CARGAS DE LOS COMBOBOX EN EL CASO DE TENER EN TU FORM
                    MODEL_TRATAMIENTO = _dataInput;
                }
                else
                {
                    if (_DataTrat1 != null || _DataTrat2 != null)
                    {
                        if (_DataTrat2 != null)

                            _DataTrat1 = _DataTrat2;
                        MODEL_TRATAMIENTO = new TRATAMIENTO
                        {
                            TRA_ID = _DataTrat1.TRA_ID,
                            TRA_CONCEPTO = _DataTrat1.TRA_CONCEPTO,
                            TRA_VALOR = Convert.ToInt32(_DataTrat1.TRA_VALOR),
                            TRA_ESTADO = _DataTrat1.TRA_ESTADO,
                            TRA_TOTAL = Convert.ToInt32(_DataTrat1.TRA_TOTAL),
                            TRA_POR_DESC = Convert.ToInt32(_DataTrat1.TRA_POR_DESC),
                            TRA_DESC = Convert.ToInt32(_DataTrat1.TRA_DESC)
                        };
                        if (_dataInput != null)
                        {
                            MODEL_TRATAMIENTO.ErrorMessage = _dataInput.ErrorMessage;
                        }
                    }
                }
            }
            else
            {
                MODEL_TRATAMIENTO = new TRATAMIENTO
                {
                   
                };
            }
            if (_DataTrat2 == null)
            {
                _DataTrat2 = _DataTrat1;
            }
            _DataTrat1 = null;
        }


        public async Task<IActionResult> OnPost(String dataTratamiento)
        {
            //variable "dataTratamiento" debe ser estar declarada en el boton editar con el mismo nombre
            //en la variable "name" caso contrario arrojara siempre un valor nulo.
            if (dataTratamiento == null)
            {
                if (_DataTrat2 == null)
                {
                    if (User.IsInRole("ADMIN"))
                    {
                        if (await Guardar_Tratamiento_Async())
                        {
                            _DataTrat1 = null;
                            _dataInput = null;
                            _DataTrat2 = null;
                            return Redirect("/Tratamiento/Tratamiento?area=Presupuesto");
                        }
                        else
                        {
                            return Redirect("/Presupuesto/Registro");
                        }
                    }
                    else
                    {
                        return Redirect("/Tratamiento/Tratamiento?area=Presupuesto");
                    }
                }
                else
                {
                    if (User.IsInRole("ADMIN"))
                    {
                        if (await Actualizar_Tratamiento_Async())
                        {
                            var url = "/Tratamiento/Tratamiento?area=Presupuesto";
                            _DataTrat1 = null;
                            _dataInput = null;
                            _DataTrat2 = null;
                            return Redirect(url);
                        }
                        else
                        {
                            return Redirect("/Presupuesto/Registro");
                        }
                    }
                    else
                    {
                        return Redirect("/Tratamiento/Tratamiento?area=Presupuesto");
                    }
                }
            }
            else
            {
                _DataTrat1 = JsonConvert.DeserializeObject<MODELO_TRATAMIENTO>(dataTratamiento);
                return Redirect("/Presupuesto/Registro?idActTrat=1");
                //el parametro que pasa en la url --> idActTrat debe ser el mismo de la
                //variable que hace la verificacion en el metodo OnGet
            }
        }

            private async Task<bool> Guardar_Tratamiento_Async()
            {
                _dataInput = MODEL_TRATAMIENTO;
                var valor = false;
                if (ModelState.IsValid)
                {
                    var TratLista = _context.TBL_TRATAMIENTO.Where(u => u.TRA_CONCEPTO.Equals(MODEL_TRATAMIENTO.TRA_CONCEPTO)).ToList();
                    if (TratLista.Count.Equals(0))
                    {
                        var strategy = _context.Database.CreateExecutionStrategy();
                        await strategy.ExecuteAsync(async () =>
                        {
                            using (var transaction = _context.Database.BeginTransaction())
                            {
                                try
                                {
                                    var Nuevo_Tratamiento = new MODELO_TRATAMIENTO
                                    {
                                        TRA_CONCEPTO = _dataInput.TRA_CONCEPTO.ToUpper(),
                                        TRA_VALOR = _dataInput.TRA_VALOR,
                                        TRA_POR_DESC = _dataInput.TRA_POR_DESC,
                                        TRA_DESC = _dataInput.TRA_DESC,
                                        TRA_TOTAL = _dataInput.TRA_TOTAL,
                                        TRA_ESTADO = _dataInput.TRA_ESTADO

                                    };
                                    await _context.AddAsync(Nuevo_Tratamiento);
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
                        _dataInput.ErrorMessage = $"El Tratamiento {MODEL_TRATAMIENTO.TRA_CONCEPTO} ya se encuentra Registrado";
                        valor = false;
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
        public TRATAMIENTO MODEL_TRATAMIENTO { get; set; }

        public class TRATAMIENTO : MODELO_TRATAMIENTO
        {
        }

        private async Task<bool> Actualizar_Tratamiento_Async()
        {
            _dataInput = MODEL_TRATAMIENTO;
            var valor = false;
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async() =>{
                    //if (ModelState.IsValid)
                    //{
                    using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var idCodTratamiento = _context.TBL_TRATAMIENTO.Where(u => u.TRA_ID.Equals(_DataTrat2.TRA_ID) && u.TRA_ESTADO.Equals("V"));

                            //if (idCodPaciente[0].PAC_ID.Equals(_DataTrat2.PAC_ID))
                            //{
                            var Actualizar_Tratamiento = new MODELO_TRATAMIENTO
                        {
                            TRA_ID = _DataTrat2.TRA_ID,
                            TRA_CONCEPTO = _dataInput.TRA_CONCEPTO.ToUpper(),
                            TRA_VALOR = _dataInput.TRA_VALOR,
                            TRA_DESC = _dataInput.TRA_DESC,
                            TRA_POR_DESC = _dataInput.TRA_POR_DESC,
                            TRA_TOTAL = _dataInput.TRA_TOTAL,
                            TRA_ESTADO = _dataInput.TRA_ESTADO.ToUpper()
                        };
                        _context.Update(Actualizar_Tratamiento);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        valor = true;
                            //}
                            //else
                            //{
                            //    _dataInput.ErrorMessage = $"El {MODEL_PACIENTE.PAC_CODIGO} ya esta Registrado";
                            //    valor = false;
                            //}
                        }
                    catch (Exception ex)
                    {
                        _dataInput.ErrorMessage = ex.Message;
                        transaction.Rollback();
                        valor = false;
                    }
                }
                    //}
                    //else
                    //{
                    //    valor = false;
                    //}
                });
            return valor;
        }


    }
}

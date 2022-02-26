using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Pages.Account
{
    [Area("Presupuesto")]
    [Authorize]
    public class Reg_PresupModel : PageModel
    {

        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private static PRESUPUESTO _dataInput;
        private static MODELO_PRESUPUESTO _DataPres1, _DataPres2;
        private LPresupuesto _lPresupuesto;
        private LOdontologo _lOdontologo;
        private LDentadura _lDentadura;
        private LPieza _lPieza;
        private LLTratamiento _lTratamiento;
        private ApplicationDbContext _context;

        public Reg_PresupModel(
             SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
         ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _lOdontologo = new LOdontologo();
            _lDentadura = new LDentadura();
            _lPieza = new LPieza();
            _lTratamiento = new LLTratamiento();
            _lPresupuesto = new LPresupuesto(context);
        }
        public void OnGet(int idActPres)
        {
            //_DataTrat2 = null;
            if (idActPres.Equals(0))
            {
                _DataPres2 = null;
            }
            if (idActPres.Equals(1))
            {
                _dataInput = null;
            }
            if (_dataInput != null || _DataPres1 != null || _DataPres2 != null)
            {
                if (_dataInput != null)
                {  //IF PARA SABER SI _DATAINPUT CONTIENE DATOS. SI CONTIENE SE PROSIGUE CON LAS CARGAS DE LOS COMBOBOX EN EL CASO DE TENER EN TU FORM
                    MODEL_PRESUPUESTO = _dataInput;
                }
                else
                {
                    if (_DataPres1 != null || _DataPres2 != null)
                    {
                        if (_DataPres2 != null)

                            _DataPres1 = _DataPres2;
                        MODEL_PRESUPUESTO = new PRESUPUESTO
                        {
                            PRE_ID = _DataPres1.PRE_ID,
                            PRE_COD = _DataPres1.PRE_COD,
                            PRE_COD_PAC = _DataPres1.PRE_COD_PAC,
                            PRE_NOM_PAC = _DataPres1.PRE_NOM_PAC,
                            PRE_COD_ODON = _DataPres1.PRE_COD_ODON,
                            PRE_NOM_ODON = _DataPres1.PRE_NOM_ODON,
                            PRE_RUT = _DataPres1.PRE_RUT,
                            PRE_DEN_PAC = _DataPres1.PRE_DEN_PAC,
                            PRE_PIE_DEN = _DataPres1.PRE_PIE_DEN,
                            PRE_TRA_PAC = _DataPres1.PRE_TRA_PAC,
                            PRE_VAL_PRE = _DataPres1.PRE_VAL_PRE,
                            PRE_VAL_POR = _DataPres1.PRE_VAL_POR,
                            PRE_VAL_DES = _DataPres1.PRE_VAL_DES,
                            PRE_VAL_SUB = _DataPres1.PRE_VAL_SUB,
                            PRE_VAL_POR_DSC_SUB = _DataPres1.PRE_VAL_POR_DSC_SUB,
                            PRE_VAL_TOT_DSC_SUB = _DataPres1.PRE_VAL_TOT_DSC_SUB,
                            PRE_VAL_POR_TAR_SUB = _DataPres1.PRE_VAL_POR_TAR_SUB,
                            PRE_VAL_TOT_TAR_SUB = _DataPres1.PRE_VAL_TOT_TAR_SUB,
                            PRE_VAL_TOT = _DataPres1.PRE_VAL_TOT,
                            PRE_ELA_PRE = _DataPres1.PRE_ELA_PRE,
                            PRE_ELA_ACT = _DataPres1.PRE_ELA_ACT,
                            PRE_EST_ELI = _DataPres1.PRE_EST_ELI,
                            PRE_EST_REA = _DataPres1.PRE_EST_REA,
                            Odontologo_Lista = _lOdontologo.GetOdontologo(_context),
                            Dentadura_Lista = _lDentadura.GetDentadura(_context),
                            Tratamiento_Lista = _lTratamiento.GetTratamiento(_context)
                        };

                        if (_dataInput != null)
                        {
                            MODEL_PRESUPUESTO.ErrorMessage = _dataInput.ErrorMessage;
                        }
                    }
                }
            }
            else
            {
                var Cod_Pre = 0;
                String TempCodPre = null;
                var Ultimo_Presupuesto = (from t in _context.TBL_PRESUPUESTO
                                          orderby t.PRE_COD
                                          select t).LastOrDefault();
                if (Ultimo_Presupuesto == null)
                {
                    TempCodPre = "00001";
                }
                else if (Ultimo_Presupuesto != null)
                {
                    Cod_Pre = (Ultimo_Presupuesto.PRE_COD != null) ?
                           Convert.ToInt32(Ultimo_Presupuesto.PRE_COD) + 1 :
                           1;
                    if (Cod_Pre < 10)
                    {
                        TempCodPre = String.Concat("0000", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre >= 10 && Cod_Pre <= 11)
                    {
                        TempCodPre = String.Concat("000", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre > 10 && Cod_Pre < 100)
                    {
                        TempCodPre = String.Concat("000", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre >= 100 && Cod_Pre <= 101)
                    {
                        TempCodPre = String.Concat("00", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre > 100 && Cod_Pre < 1000)
                    {
                        TempCodPre = String.Concat("00", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre >= 1000 && Cod_Pre <= 1001)
                    {
                        TempCodPre = String.Concat("0", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre > 1000 && Cod_Pre <= 9999)
                    {
                        TempCodPre = String.Concat("0", Convert.ToString(Cod_Pre));
                    }
                    else if (Cod_Pre > 9999 && Cod_Pre < 99999)
                    {
                        TempCodPre = String.Concat("", Convert.ToString(Cod_Pre));
                    }
                }
                MODEL_PRESUPUESTO = new PRESUPUESTO
                {
                    PRE_COD = TempCodPre,
                    Odontologo_Lista = _lOdontologo.GetOdontologo(_context),
                    Dentadura_Lista = _lDentadura.GetDentadura(_context),
                    Tratamiento_Lista = _lTratamiento.GetTratamiento(_context)
                };
            }
            if (_DataPres2 == null)
            {
                _DataPres2 = _DataPres1;
            }
            _DataPres1 = null;
        }

       
        private async Task<bool> Guardar_Presupuesto_Async()
        {
            _dataInput = MODEL_PRESUPUESTO;
            var valor = false;
            if (ModelState.IsValid)
            {
                var TratLista = _context.TBL_PRESUPUESTO.Where(u => u.PRE_COD.Equals(MODEL_PRESUPUESTO.PRE_COD)).ToList();
                if (TratLista.Count.Equals(0))
                {
                    var strategy = _context.Database.CreateExecutionStrategy();
                    await strategy.ExecuteAsync(async () =>
                    {
                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                var Nuevo_Presupuesto = new MODELO_PRESUPUESTO
                                {
                                    PRE_COD = _dataInput.PRE_COD,
                                    PRE_COD_PAC = _dataInput.PRE_COD_PAC,
                                    PRE_NOM_PAC = _dataInput.PRE_NOM_PAC,
                                    PRE_COD_ODON = _dataInput.PRE_COD_ODON,
                                    PRE_NOM_ODON = _dataInput.PRE_NOM_ODON,
                                    PRE_RUT = _dataInput.PRE_RUT,
                                    PRE_DEN_PAC = _dataInput.PRE_DEN_PAC,
                                    PRE_PIE_DEN = _dataInput.PRE_PIE_DEN,
                                    PRE_TRA_PAC = _dataInput.PRE_TRA_PAC,
                                    PRE_VAL_PRE = _dataInput.PRE_VAL_PRE,
                                    PRE_VAL_POR = _dataInput.PRE_VAL_POR,
                                    PRE_VAL_DES = _dataInput.PRE_VAL_DES,
                                    PRE_VAL_SUB = _dataInput.PRE_VAL_SUB,
                                    PRE_VAL_POR_DSC_SUB = _dataInput.PRE_VAL_POR_DSC_SUB,
                                    PRE_VAL_TOT_DSC_SUB = _dataInput.PRE_VAL_TOT_DSC_SUB,
                                    PRE_VAL_POR_TAR_SUB = _dataInput.PRE_VAL_POR_TAR_SUB,
                                    PRE_VAL_TOT_TAR_SUB = _dataInput.PRE_VAL_TOT_TAR_SUB,
                                    PRE_VAL_TOT = _dataInput.PRE_VAL_TOT,
                                    PRE_ELA_PRE = _dataInput.PRE_ELA_PRE,
                                    PRE_ELA_ACT = _dataInput.PRE_ELA_ACT,
                                    PRE_EST_ELI = _dataInput.PRE_EST_ELI,
                                    PRE_EST_REA = _dataInput.PRE_EST_REA
                                };
                                await _context.AddAsync(Nuevo_Presupuesto); _context.SaveChanges(); transaction.Commit(); _dataInput = null; valor = true;
                            }
                            catch (Exception ex)
                            { _dataInput.ErrorMessage = ex.Message; transaction.Rollback(); valor = false; }
                        }
                    });
                }
                else
                { _dataInput.ErrorMessage = $"El Presupuesto {MODEL_PRESUPUESTO.PRE_COD} ya se encuentra Registrado"; valor = false; }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    { _dataInput.ErrorMessage += error.ErrorMessage; }
                }
                valor = false;
            }
            return valor;
        }



        public async Task<IActionResult> OnPost(String dataPresupuesto)
        {
            //variable "dataPresupuesto" debe ser estar declarada en el boton editar con el mismo nombre
            //en la variable "name" caso contrario arrojara siempre un valor nulo.
            if (dataPresupuesto == null)
            {
                if (_DataPres2 == null)
                {
                    if (User.IsInRole("ADMIN"))
                    {
                        if (await Guardar_Presupuesto_Async())
                        {
                            _DataPres1 = null;
                            _dataInput = null;
                            _DataPres2 = null;
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
                        if (await Actualizar_Presupuesto_Async())
                        {
                            var url = "/Tratamiento/Tratamiento?area=Presupuesto";
                            _DataPres1 = null;
                            _dataInput = null;
                            _DataPres2 = null;
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
                _DataPres1 = JsonConvert.DeserializeObject<MODELO_PRESUPUESTO>(dataPresupuesto);
                return Redirect("/Presupuesto/Registro?idActPres=1");
                //el parametro que pasa en la url --> idActPres debe ser el mismo de la
                //variable que hace la verificacion en el metodo OnGet
            }
        }

        private async Task<bool> Actualizar_Presupuesto_Async()
        {
            _dataInput = MODEL_PRESUPUESTO;
            var valor = false;
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                if (ModelState.IsValid)
                {
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            var idCodTratamiento = _context.TBL_PRESUPUESTO.Where(u => u.PRE_ID.Equals(_DataPres2.PRE_ID) && u.PRE_EST_ELI.Equals("F"));

                            //if (idCodPaciente[0].PAC_ID.Equals(_DataTrat2.PAC_ID))
                            //{
                            var Actualizar_Presupuesto = new MODELO_PRESUPUESTO
                            {
                                PRE_ID = _DataPres2.PRE_ID,
                                PRE_COD = _dataInput.PRE_COD,
                                PRE_COD_PAC = _dataInput.PRE_COD_PAC,
                                PRE_NOM_PAC = _dataInput.PRE_NOM_PAC,
                                PRE_COD_ODON = _dataInput.PRE_COD_ODON,
                                PRE_NOM_ODON = _dataInput.PRE_NOM_ODON,
                                PRE_RUT = _dataInput.PRE_RUT,
                                PRE_DEN_PAC = _dataInput.PRE_DEN_PAC,
                                PRE_PIE_DEN = _dataInput.PRE_PIE_DEN,
                                PRE_TRA_PAC = _dataInput.PRE_TRA_PAC,
                                PRE_VAL_PRE = _dataInput.PRE_VAL_PRE,
                                PRE_VAL_POR = _dataInput.PRE_VAL_POR,
                                PRE_VAL_DES = _dataInput.PRE_VAL_DES,
                                PRE_VAL_SUB = _dataInput.PRE_VAL_SUB,
                                PRE_VAL_POR_DSC_SUB = _dataInput.PRE_VAL_POR_DSC_SUB,
                                PRE_VAL_TOT_DSC_SUB = _dataInput.PRE_VAL_TOT_DSC_SUB,
                                PRE_VAL_POR_TAR_SUB = _dataInput.PRE_VAL_POR_TAR_SUB,
                                PRE_VAL_TOT_TAR_SUB = _dataInput.PRE_VAL_TOT_TAR_SUB,
                                PRE_VAL_TOT = _dataInput.PRE_VAL_TOT,
                                PRE_ELA_PRE = _dataInput.PRE_ELA_PRE,
                                PRE_ELA_ACT = _dataInput.PRE_ELA_ACT,
                                PRE_EST_ELI = _dataInput.PRE_EST_ELI,
                                PRE_EST_REA = _dataInput.PRE_EST_REA
                            };
                            _context.Update(Actualizar_Presupuesto);
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
                }
                else
                {
                    valor = false;
                }
            });
            return valor;
        }

        [BindProperty]
        public PRESUPUESTO MODEL_PRESUPUESTO { get; set; }

        public class PRESUPUESTO : MODELO_PRESUPUESTO
        {
            public List<SelectListItem> Odontologo_Lista { get; set; }
            public List<SelectListItem> Dentadura_Lista { get; set; }
            public List<SelectListItem> Pieza_Lista { get; set; }
            public List<SelectListItem> Tratamiento_Lista { get; set; }
        }
    }
}

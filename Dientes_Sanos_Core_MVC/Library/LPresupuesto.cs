using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LPresupuesto : LObjeto
    {

        public LPresupuesto(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MODELO_PRESUPUESTO> get_Prespuesto_Async(String valor, int id)
        {
            List<MODELO_PRESUPUESTO> ListaTPresupuesto;
            var PresupuestoLista = new List<MODELO_PRESUPUESTO>();
            if (valor == null && id.Equals(0))
            {
                ListaTPresupuesto = _context.TBL_PRESUPUESTO.OrderBy(u => u.PRE_COD).ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    ListaTPresupuesto = _context.TBL_PRESUPUESTO.Where(u => u.PRE_COD.StartsWith(valor)).ToList();
                }
                else
                {
                    ListaTPresupuesto = _context.TBL_PRESUPUESTO.Where(u => u.PRE_ID.Equals(id)).ToList();
                }
            }
            if (!ListaTPresupuesto.Count.Equals(0))
            {
                foreach (var item in ListaTPresupuesto)
                {
                    PresupuestoLista.Add(new MODELO_PRESUPUESTO
                    {
                        PRE_ID = item.PRE_ID,
                        PRE_COD = item.PRE_COD,
                        PRE_COD_PAC = item.PRE_COD_PAC,
                        PRE_COD_ODON = item.PRE_COD_ODON,
                        PRE_NOM_ODON = item.PRE_NOM_ODON,
                        PRE_RUT = item.PRE_RUT,
                        PRE_DEN_PAC = item.PRE_DEN_PAC,
                        PRE_PIE_DEN = item.PRE_PIE_DEN,
                        PRE_TRA_PAC = item.PRE_TRA_PAC,
                        PRE_VAL_PRE = item.PRE_VAL_PRE,
                        PRE_VAL_POR = item.PRE_VAL_POR,
                        PRE_VAL_DES = item.PRE_VAL_DES,
                        PRE_VAL_SUB = item.PRE_VAL_SUB,
                        PRE_VAL_POR_DSC_SUB = item.PRE_VAL_POR_DSC_SUB,
                        PRE_VAL_TOT_DSC_SUB = item.PRE_VAL_TOT_DSC_SUB,
                        PRE_VAL_POR_TAR_SUB = item.PRE_VAL_POR_TAR_SUB,
                        PRE_VAL_TOT_TAR_SUB = item.PRE_VAL_TOT_TAR_SUB,
                        PRE_VAL_TOT = item.PRE_VAL_TOT,
                        PRE_ELA_PRE = item.PRE_ELA_PRE,
                        PRE_ELA_ACT = item.PRE_ELA_ACT,
                        PRE_EST_ELI = item.PRE_EST_ELI,
                        PRE_EST_REA = item.PRE_EST_REA
                    });
                }
            }
            return PresupuestoLista;
        }


        public MODELO_PRESUPUESTO getTPresupuestoReporte(int id)
        {
            var dataPresupuesto = new MODELO_PRESUPUESTO();
            using (var dbContext = new ApplicationDbContext())
            {
                var query = dbContext.TBL_PRESUPUESTO.Where(c => c.PRE_ID.Equals(id)).ToList();
                if (!query.Count.Equals(0))
                {
                    var data = query.ToList().Last();
                    dataPresupuesto = new MODELO_PRESUPUESTO
                    {
                        PRE_ID = data.PRE_ID,
                        PRE_COD = data.PRE_COD,
                        PRE_COD_PAC = data.PRE_COD_PAC,
                        PRE_NOM_PAC = data.PRE_NOM_PAC,
                        PRE_COD_ODON = data.PRE_COD_ODON,
                        PRE_NOM_ODON = data.PRE_NOM_ODON,
                        PRE_RUT = data.PRE_RUT,
                        PRE_DEN_PAC = data.PRE_DEN_PAC,
                        PRE_PIE_DEN = data.PRE_PIE_DEN,
                        PRE_TRA_PAC = data.PRE_TRA_PAC,
                        PRE_VAL_PRE = data.PRE_VAL_PRE,
                        PRE_VAL_POR = data.PRE_VAL_POR,
                        PRE_VAL_DES = data.PRE_VAL_DES,
                        PRE_VAL_SUB = data.PRE_VAL_SUB,
                        PRE_VAL_POR_DSC_SUB = data.PRE_VAL_POR_DSC_SUB,
                        PRE_VAL_TOT_DSC_SUB = data.PRE_VAL_TOT_DSC_SUB,
                        PRE_VAL_POR_TAR_SUB = data.PRE_VAL_POR_TAR_SUB,
                        PRE_VAL_TOT_TAR_SUB = data.PRE_VAL_TOT_TAR_SUB,
                        PRE_VAL_TOT = data.PRE_VAL_TOT,
                        PRE_ELA_PRE = data.PRE_ELA_PRE,
                        PRE_ELA_ACT = data.PRE_ELA_ACT,
                        PRE_EST_ELI = data.PRE_EST_ELI,
                        PRE_EST_REA = data.PRE_EST_REA
                    };
                }
            }
            return dataPresupuesto;
        }
    }

}

using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
using Dientes_Sanos_Core_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LTratamiento : LObjeto
    {

        public LTratamiento(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MODELO_TRATAMIENTO> get_Tratamiento_Async(string valor, int id)
        {
            List<MODELO_TRATAMIENTO> ListaTTratamiento;
            var TratamientoLista = new List<MODELO_TRATAMIENTO>();
            if (valor == null && id.Equals(0))
            {
                ListaTTratamiento = _context.TBL_TRATAMIENTO.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    ListaTTratamiento = _context.TBL_TRATAMIENTO.Where(u => u.TRA_CONCEPTO.StartsWith(valor) || u.TRA_ESTADO.StartsWith(valor)).ToList();
                }
                else
                {
                    ListaTTratamiento = _context.TBL_TRATAMIENTO.Where(u => u.TRA_ID.Equals(id)).ToList();
                }
            }
            if (!ListaTTratamiento.Count.Equals(0))
            {
                foreach (var item in ListaTTratamiento)
                {
                    TratamientoLista.Add(new MODELO_TRATAMIENTO
                    {
                        TRA_ID = item.TRA_ID,
                        TRA_CONCEPTO = item.TRA_CONCEPTO,
                        TRA_DESC = item.TRA_DESC,
                        TRA_ESTADO = item.TRA_ESTADO,
                        TRA_POR_DESC = item.TRA_POR_DESC,
                        TRA_TOTAL = item.TRA_TOTAL,
                        TRA_VALOR = item.TRA_VALOR
                    }
);
                }
            }
            return TratamientoLista;
        }
    }
}

using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LCie10 : LObjeto
    {

         public LCie10(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetCIE10(ApplicationDbContext context)
        {
            List<SelectListItem> selectListItems = null;
            try
            {
                selectListItems = new List<SelectListItem>();
                context.TBL_CIE10.ToList().ForEach(item =>
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = item.CIE_CODIGO.ToString(),
                        Text = item.CIE_CONCEPTO
                    });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
            return selectListItems;

        }

        public List<MODELO_CIE10> get_CIE10_Async(String valor, int id)
        {
            List<MODELO_CIE10> ListaTCIE10;
            var CIE10Lista = new List<MODELO_CIE10>();
            if (valor == null && id.Equals(0))
            {
                ListaTCIE10 = _context.TBL_CIE10.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    ListaTCIE10 = _context.TBL_CIE10.Where(u => u.CIE_CONCEPTO.StartsWith(valor) || u.CIE_CODIGO.StartsWith(valor)).ToList();
                }
                else
                {
                    ListaTCIE10 = _context.TBL_CIE10.Where(u => u.CIE_ID.Equals(id)).ToList();
                 
                }
            }
            if (!ListaTCIE10.Count.Equals(0))
            {
                foreach (var item in ListaTCIE10)
                {
                    CIE10Lista.Add(new MODELO_CIE10
                    {
                        CIE_ID = item.CIE_ID,
                        CIE_CODIGO = item.CIE_CODIGO,
                        CIE_CONCEPTO = item.CIE_CONCEPTO,
                     
                    });
                }
            }
            return CIE10Lista;
        }


    }
}

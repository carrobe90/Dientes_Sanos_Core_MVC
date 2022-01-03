using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LLTratamiento: LObjeto
    {

        public List<SelectListItem> GetTratamiento(ApplicationDbContext context)
        {
            List<SelectListItem> selectListItems = null;
            try
            {
                selectListItems = new List<SelectListItem>(); 
                //AL USAR WHERE SIEMPRE DEBES PONER ENTRE DOBLE COMILLAS SI QUIERES HACER UNA VALIDACION DE IGUALDAD
                context.TBL_TRATAMIENTO.Where(tra => tra.TRA_ESTADO.Equals("V")).OrderBy(tra => tra.TRA_ID).ToList().ForEach(item =>
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = item.TRA_ID.ToString(),
                        Text = item.TRA_CONCEPTO
                    });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: '{ex}'");
            }
            return selectListItems;

        }

    }
}

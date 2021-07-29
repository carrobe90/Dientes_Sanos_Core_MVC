using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LPacienteGen
    {
        public List<SelectListItem> GetGenero(ApplicationDbContext context)
        {
            //List<SelectListItem> selectListItems = null;
            //try
            //{
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            context.TBL_GENERO.ToList().ForEach(item =>
            {
                selectListItems.Add(new SelectListItem
                {
                    Value = item.GENERO_ID.ToString(),
                    Text = item.GENERO_NOMBRE
                });
            });
            //}
            //catch (Exception ex)
            //{
            //   Console.WriteLine($"Error: '{ex}'");
            //}
            return selectListItems;

        }

    }
}

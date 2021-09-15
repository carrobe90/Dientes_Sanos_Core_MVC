using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LOdontologo
    {

        public List<SelectListItem> GetOdontologo(ApplicationDbContext context)
        {
            List<SelectListItem> selectListItems = null;
            try
            {
                selectListItems = new List<SelectListItem>();
                context.TBL_ODONTOLOGO.ToList().ForEach(item =>
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = item.ODONT_ID.ToString(),
                       // Text = item.ODONT_CODIGO
    
                        Text = item.ODONT_CODIGO + '-' + item.ODONT_APELLIDO + ' ' + item.ODONT_NOMBRE
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

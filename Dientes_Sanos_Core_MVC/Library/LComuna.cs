using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LComuna
    {

        public List<SelectListItem> GetComuna(ApplicationDbContext context)
        {
            List<SelectListItem> selectListItems = null;
            try
            {
                selectListItems = new List<SelectListItem>();
                context.TBL_PROVINCIA.ToList().ForEach(item =>
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = item.PROV_ID.ToString(),
                        Text = item.PROV_NOMBRE
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

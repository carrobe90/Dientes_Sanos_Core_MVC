using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LDentadura
    {

        public List<SelectListItem> GetDentadura(ApplicationDbContext context)
        {
            List<SelectListItem> selectListItems = null;
            try
            {
                selectListItems = new List<SelectListItem>();
                context.TBL_DENTADURA.ToList().ForEach(item =>
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = item.DENT_ID.ToString(),
                        Text = item.DENT_NOM
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

using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LPieza
    {

        public List<SelectListItem> GetPieza(ApplicationDbContext context, String tmp)
        {
            List<SelectListItem> selectListItems = null;
            try
            {
                selectListItems = new List<SelectListItem>();
                if (tmp.Equals("DENTADURA TEMPORAL"))
                    context.TBL_PIEZA.Where(pie => pie.PIE_DENT.Equals("TEMPORAL")).OrderBy(pie => pie.PIE_ID).ToList().ForEach(item =>
                    {
                        selectListItems.Add(new SelectListItem
                        {
                            Value = item.PIE_ID.ToString(),
                            Text = item.PIE_PIEZA
                        });
                    });
                else if (tmp.Equals("DENTADURA ADULTA"))
                    context.TBL_PIEZA.Where(pie => pie.PIE_DENT.Equals("ADULTA")).OrderBy(pie => pie.PIE_ID).ToList().ForEach(item =>
                    {
                        selectListItems.Add(new SelectListItem
                        {
                            Value = item.PIE_ID.ToString(),
                            Text = item.PIE_PIEZA
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

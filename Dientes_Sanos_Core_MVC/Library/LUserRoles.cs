using Dientes_Sanos_Core_MVC.Data;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LUserRoles
    {

        public List<SelectListItem> GetRoles(ApplicationDbContext context)
        {
            //List<SelectListItem> selectListItems = null;
            //try
            //{
            List<SelectListItem> _selectListItems = new List<SelectListItem>();
                context.TBL_ROL.ToList().ForEach(item =>
                {
                    _selectListItems.Add(new SelectListItem
                    {
                        Value = item.USER_ID.ToString(),
                        Text = item.USER_ROL
                    });
                });
            //}
            //catch (Exception ex)
            //{
            //   Console.WriteLine($"Error: '{ex}'");
            //}
            return _selectListItems;

        }
    }
}

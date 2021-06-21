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

        public List<SelectListItem> GetRoles(RoleManager<IdentityRole> roleManager)
        {
            //List<SelectListItem> selectListItems = null;
            //try
            //{
            List<SelectListItem> selectListItems = new List<SelectListItem>();
                var rol = roleManager.Roles.ToList();
                rol.ForEach(item =>
                {
                    selectListItems.Add(new SelectListItem
                    {
                        Value = item.Id,
                        Text = item.Name
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

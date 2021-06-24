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

        public async Task<List<SelectListItem>> GetRoles(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            String ID)
        {
            List<SelectListItem> _selectListItems = new List<SelectListItem>();
            var Usuario = await userManager.FindByIdAsync(ID);
            var Roles = await userManager.GetRolesAsync(Usuario);
            if(Roles.Count.Equals(0))
            {
                _selectListItems.Add(new SelectListItem
                {
                    Value = "0",
                    Text ="No hay Rol"
                });
            }
            else
            {
                var RoleUser = roleManager.Roles.Where(m => m.Name.Equals(Roles[0]));
                foreach(var Data in RoleUser)
                {
                    _selectListItems.Add(new SelectListItem
                    {
                        Value = Data.Id,
                        Text = Data.Name,
                    });
                }
            }
            return _selectListItems;
        }
    }
}

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

        public List<SelectListItem> GetRoles(RoleManager<IdentityRole> rol_Manager)
        {
            List<SelectListItem> _selectListItem = new List<SelectListItem>();
            var roles = rol_Manager.Roles.ToList();
            roles.ForEach(item => {
                _selectListItem.Add(new SelectListItem
                {
                    Value = item.Id,
                    Text = item.Name
                });
            });
            return _selectListItem;

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

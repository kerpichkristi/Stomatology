using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Administration.Roles
{
    [Authorize(Roles= "Administrator")]
    public class AllRolesModel : PageModel
    {

        RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AllRolesModel> _logger;

        public AllRolesModel(RoleManager<IdentityRole> roleManager, ILogger<AllRolesModel> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }
        public List<IdentityRole> RolesList { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            RolesList = await _roleManager.Roles.ToListAsync();
            
            return Page();
        }
        public async Task<ActionResult> OnGetDelete(string id) {
            
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
              
            }
            RolesList = await _roleManager.Roles.ToListAsync();
            return RedirectToPage("AllRoles");
        }
       
    }
}

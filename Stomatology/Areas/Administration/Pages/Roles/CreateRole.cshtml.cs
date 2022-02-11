using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Stomatology.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Administration.Roles
{
    [Authorize(Roles = "Administrator")]
    public class CreateRoleModel : PageModel
    {   
        [BindProperty]
        public string Name { get; set; }

        private readonly ILogger<CreateRoleModel> _logger;
        RoleManager<IdentityRole> _roleManager;
        

        public CreateRoleModel(ILogger<CreateRoleModel> 
            logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }
        public void OnGet() { }
        public  async Task<ActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(Name));
                if (result.Succeeded)
                {
                    return RedirectToPage("AllRoles");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return RedirectToPage("AllRoles");
        }
    }    
}

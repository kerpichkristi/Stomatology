using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stomatology.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Administration.Users
{
    [Authorize(Roles = "Administrator")]
    public class AllUsersModel : PageModel
    {
        public UserManager<ApplicationUser> _userManager { get; set; }
        public List<ApplicationUser> UsersList { get; set; }

        private readonly ILogger<AllUsersModel> _logger;
        public AllUsersModel(ILogger<AllUsersModel> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UsersList = await _userManager.Users.ToListAsync();
            return Page();
        }
        public async Task<ActionResult> OnGetDelete(string id)
        {
            var role = await _userManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(role);

            }
            UsersList = await _userManager.Users.ToListAsync();
            return RedirectToPage("AllUsers");
        }
    }
   
}


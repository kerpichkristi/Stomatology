using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Stomatology.Areas.Moderator.Models;
using Stomatology.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Moderator
{
    [Authorize(Roles = "Moderator")]
    public class CreateDentistModel : PageModel
    {
        
        StomatologyDbContext _context;
        [BindProperty]
        public Dentist Dentist { get; set; }
        private readonly ILogger<CreateDentistModel> _logger;
        public CreateDentistModel(ILogger<CreateDentistModel> logger, StomatologyDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public void OnGet() { }
        public ActionResult OnPost()
        {
            var dentist = Dentist;
            if (!ModelState.IsValid)
                return Page();

            dentist.DentistID = 0;
            var result = _context.Add(dentist);
            _context.SaveChanges();

            return RedirectToPage("AllDentists");


        }
    }
}

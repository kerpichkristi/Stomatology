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
    [BindProperties(SupportsGet = true)]
    public class AllDentistsModel : PageModel
    {
        StomatologyDbContext _context;
        private readonly ILogger<AllDentistsModel> _logger;
        public List<Dentist> DentistList { get; set; }
        public AllDentistsModel(ILogger<AllDentistsModel> logger, StomatologyDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public void OnGet() {
            var data = (from Dentistlist in _context.DentistsTB
                        select Dentistlist).ToList();

            DentistList = data;
        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from dentist in _context.DentistsTB
                            where dentist.DentistID == id
                            select dentist).SingleOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("AllDentists");
        }
    }
}

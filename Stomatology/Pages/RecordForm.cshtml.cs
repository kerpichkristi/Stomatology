using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Stomatology.Data;
using Stomatology.Areas.Moderator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stomatology.Pages
{
    
    public class RecordFormModel : PageModel
    {
        StomatologyDbContext _context;
        public Record Record { get; set; }
        private readonly ILogger<RecordFormModel> _logger;

        public RecordFormModel(ILogger<RecordFormModel> logger, StomatologyDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public void OnGet() { }
        public ActionResult OnPost()
        {
            var record = Record;
            if (!ModelState.IsValid)
                return Page();

            record.RecordID = 0;
            var result = _context.Add(record);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

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
    public class AllRecordsModel : PageModel
    {
        StomatologyDbContext _context;
        private readonly ILogger<AllRecordsModel> _logger;
        public List<Record> RecordList { get; set; }
        public AllRecordsModel(ILogger<AllRecordsModel> logger, StomatologyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
            var data = (from RecordList in _context.RecordsTB
                        select RecordList).ToList();

            RecordList = data;
        }
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from RecordList in _context.RecordsTB
                            where RecordList.RecordID == id
                            select RecordList).SingleOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToPage("AllRecords");
        }
    }

}

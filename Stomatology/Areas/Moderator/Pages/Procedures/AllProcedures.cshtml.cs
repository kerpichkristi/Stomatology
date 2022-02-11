using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Moderator
{
    [Authorize(Roles = "Moderator")]
    public class AllProceduresModel : PageModel
    {
        private readonly ILogger<AllProceduresModel> _logger;
        public AllProceduresModel(ILogger<AllProceduresModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}

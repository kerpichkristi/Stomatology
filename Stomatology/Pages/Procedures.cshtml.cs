using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Pages
{
    public class ProceduresModel: PageModel
    {
        private readonly ILogger<ProceduresModel> _logger;

        public ProceduresModel(ILogger<ProceduresModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}


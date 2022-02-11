using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Areas.Moderator
{
    [Authorize(Roles = "Moderator")]
    public class CreateProcedureModel : PageModel 
    {
        
    }
}

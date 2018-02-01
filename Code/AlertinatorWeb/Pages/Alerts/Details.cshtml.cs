using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlertinatorWeb.Data;

namespace AlertinatorWeb.Pages.Alerts
{
    public class DetailsModel : PageModel
    {
        private readonly AlertinatorWeb.Data.ApplicationDbContext _context;

        public DetailsModel(AlertinatorWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Alert Alert { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Alert = await _context.Alerts.SingleOrDefaultAsync(m => m.ID == id);

            if (Alert == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

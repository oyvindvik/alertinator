using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlertinatorWeb.Data;

namespace AlertinatorWeb.Pages.KeywordSubscriptions
{
    public class DeleteModel : PageModel
    {
        private readonly AlertinatorWeb.Data.ApplicationDbContext _context;

        public DeleteModel(AlertinatorWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KeywordSubscription KeywordSubscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentUserId = HttpContext.User.Identity.Name;
            KeywordSubscription = await _context.KeywordSubscription.SingleOrDefaultAsync(m => m.ID == id && m.UserID == currentUserId);

            if (KeywordSubscription == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KeywordSubscription = await _context.KeywordSubscription.FindAsync(id);

            if (KeywordSubscription != null)
            {
                _context.KeywordSubscription.Remove(KeywordSubscription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlertinatorWeb.Data;

namespace AlertinatorWeb.Pages.KeywordSubscriptions
{
    public class EditModel : PageModel
    {
        private readonly AlertinatorWeb.Data.ApplicationDbContext _context;

        public EditModel(AlertinatorWeb.Data.ApplicationDbContext context)
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

            KeywordSubscription = await _context.KeywordSubscription.SingleOrDefaultAsync(m => m.ID == id);

            if (KeywordSubscription == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KeywordSubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeywordSubscriptionExists(KeywordSubscription.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KeywordSubscriptionExists(int id)
        {
            return _context.KeywordSubscription.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlertinatorWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AlertinatorWeb.Pages.KeywordSubscriptions
{
    public class CreateModel : PageModel
    {
        private readonly AlertinatorWeb.Data.ApplicationDbContext _context;

        public CreateModel(AlertinatorWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public KeywordSubscription KeywordSubscription { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            KeywordSubscription.UserID = HttpContext.User.Identity.Name;
            _context.KeywordSubscription.Add(KeywordSubscription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
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
    public class IndexModel : PageModel
    {
        private readonly AlertinatorWeb.Data.ApplicationDbContext _context;

        public IndexModel(AlertinatorWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<KeywordSubscription> KeywordSubscription { get;set; }

        public async Task OnGetAsync()
        {
            var currentUserId = HttpContext.User.Identity.Name;
            KeywordSubscription = await _context.KeywordSubscription.Where(k => k.UserID == currentUserId).ToListAsync();
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly AlertinatorWeb.Data.ApplicationDbContext _context;

        public IndexModel(AlertinatorWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Alert> Alert { get;set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            int pageSize = 25;
            string currentUserId = HttpContext.User.Identity.Name;
            IQueryable<Alert> alertList = from a in _context.Alerts
                                           join k in _context.KeywordSubscription on a.Keyword equals k.Keyword
                                           where k.UserID.Equals(currentUserId)
                                           select a;
            int pageNumber = pageIndex ?? 1;
            Alert = await PaginatedList<Alert>.CreateAsync(alertList.AsNoTracking().OrderByDescending(s => s.DatePublished), pageNumber, pageSize);

            /*
                             .OrderByDescending(al => al.DatePublished).ToListAsync();
            Alert = await PaginatedList<Alert>.CreateAsync(alertList.AsNoTracking(), pageIndex ?? 1,pageSize);
    */        
    //Alert = await _context.Alerts.OrderByDescending(s => s.DatePublished).ToListAsync(); // TODO: Must join against your own selected keywords so that it only returns the ones you have yourself.
            

        }
        
    }
}

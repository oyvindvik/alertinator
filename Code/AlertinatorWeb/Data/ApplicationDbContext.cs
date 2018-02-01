using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlertinatorWeb.Data;

namespace AlertinatorWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<KeywordSubscription>();
            // Add index on Keyword and URL to prevent duplicate entries in the Alert table
            builder.Entity<Alert>()
                .HasIndex(a => new { a.Keyword, a.Url }).IsUnique();
        }

        public DbSet<AlertinatorWeb.Data.KeywordSubscription> KeywordSubscription { get; set; }
        public DbSet<AlertinatorWeb.Data.Alert> Alerts { get; set; }

    }
}

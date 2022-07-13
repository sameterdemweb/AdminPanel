using AdminPanel.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Identity
{
    public class AdminPanelContext:DbContext
    {
        public AdminPanelContext(DbContextOptions<AdminPanelContext> options):base(options)
        {

        }

        public DbSet<BlogKategorileri> BlogKategorileri { get; set; }
        public DbSet<Bloglar> Bloglar { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace CV_Site_MVC.Models
{
    public class SiteContext:DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options):base(options)
        {

        }


        //public DbSet<Project>
    }
}

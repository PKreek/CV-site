using Microsoft.EntityFrameworkCore;

namespace CV_Site_MVC.Models
{
    public class SiteContext:DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options):base(options)
        {

        }


        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "MIB",
                    Description = "Rymdvarelser och så",
                    StartDate = new System.DateTime(2022 / 12 / 16)
                }
                );
        }
    }
}

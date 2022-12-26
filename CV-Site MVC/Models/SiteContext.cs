using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CV_Site_MVC.Models
{
    public class SiteContext:IdentityDbContext<IdentityUser>
    {
        public SiteContext(DbContextOptions<SiteContext> options):base(options)
        {

        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<IdentityUser> Users { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<Message> Messages { get; set; }
     //   public DbSet<Work_CV> Work_CVs { get; set; }
     //   public DbSet<Project_User> Project_Users { get; set; }
        public DbSet<CV> cVs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project_User>().HasKey(pu => new { pu.UserID, pu.ProjektID });
            modelBuilder.Entity<Work_CV>().HasKey(wc => new { wc.WorkID, wc.CVID });
            


            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "MIB",
                    Description = "Rymdvarelser och så",
                    StartDate = new System.DateTime(2022 / 12 / 16)
                }
                );
          
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "1",
                    UserName = "Patte1337"
                    
                //    Description = "Rymdvarelser och så",
                //    StartDate = new System.DateTime(2022 / 12 / 16)
                }
                );
                modelBuilder.Entity<CV>().HasData(
               new CV
               {
                   ID = 2,
                   Utbildning = "Ekonomi"
               }
               );
        }
    }
}

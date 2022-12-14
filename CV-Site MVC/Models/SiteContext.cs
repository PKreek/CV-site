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
        public DbSet<Work_CV> Work_CVs { get; set; }
        public DbSet<Project_User> Project_Users { get; set; }
        public DbSet<CV> cVs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project_User>().HasKey(pu => new { pu.UserID, pu.ProjektID });

            modelBuilder.Entity<Work_CV>().HasKey(wc => new { wc.WorkID, wc.CVID });
            
            modelBuilder.Entity<Work_CV>()
                .HasOne(w => w.Work)
                .WithMany(wc => wc.Work_CV)
                .HasForeignKey(wi => wi.WorkID);

            modelBuilder.Entity<Work_CV>()
                .HasOne(c => c.Cv)
                .WithMany(wc => wc.Work_CV)
                .HasForeignKey(ci => ci.CVID);
        }
    }
}

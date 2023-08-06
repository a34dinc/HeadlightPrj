using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace HeadlightPrj.Data.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=AHMET-PC\\SQLEXPRESS;database=DbHeadLight; integrated security=true");
 
        }

        public DbSet<HeadLight> HeadLights { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}

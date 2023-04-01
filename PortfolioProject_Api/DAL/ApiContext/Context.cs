using Microsoft.EntityFrameworkCore;
using PortfolioProject_Api.DAL.Entity;

namespace PortfolioProject_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QAEGP1E\\SQLEXPRESS;database=PortfolioProjectDB2;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}

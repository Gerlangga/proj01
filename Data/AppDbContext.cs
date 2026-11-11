using Microsoft.EntityFrameworkCore;
using proj01.Models;

namespace proj01.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        public DbSet<KalkulatorModel> KalkulatorModel {get;set;}
    }
}
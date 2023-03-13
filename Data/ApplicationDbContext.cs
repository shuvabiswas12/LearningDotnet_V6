using LearningDotnet_V6.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningDotnet_V6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}

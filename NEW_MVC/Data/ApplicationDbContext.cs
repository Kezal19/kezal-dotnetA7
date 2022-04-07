using NEW_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace NEW_MVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        // public DbSet<Student> Student {get; set;}
         public DbSet<Teacher>? Teacher {get; set;}
    }
}

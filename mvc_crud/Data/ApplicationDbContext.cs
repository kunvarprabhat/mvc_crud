using Microsoft.EntityFrameworkCore;
using mvc_crud.Models;

namespace mvc_crud.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }

    }
    

}

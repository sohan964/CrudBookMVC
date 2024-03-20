using CrudBookWeb.Models;
using Microsoft.EntityFrameworkCore;

//it's called code first
namespace CrudBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Dbset for model or table inside the database
        public DbSet<Catagory> Catagories { get; set; }

    }
}

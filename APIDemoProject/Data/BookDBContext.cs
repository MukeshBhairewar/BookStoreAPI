using APIDemoProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace APIDemoProject.Data
{
    public class BookDBContext : IdentityDbContext<ApplicationUser>
    {
        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {

        }
        public DbSet<Books>Books { get; set; }
    }
}
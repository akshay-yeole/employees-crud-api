using EMS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}

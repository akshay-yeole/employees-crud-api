using Employees.Web.Api.models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Web.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}

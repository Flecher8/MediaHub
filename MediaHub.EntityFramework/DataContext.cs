using MediaHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediaHub.EntityFramewok
{
    public class DataContext : IdentityDbContext<User, Role, string>
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
    }
}

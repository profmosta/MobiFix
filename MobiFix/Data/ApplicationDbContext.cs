using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MobiFix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<FixStatus> FixStatuses { get; set; } = null!;
        public virtual DbSet<PaidStatus> PaidStatuses { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

    }
}
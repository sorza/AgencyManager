using AgencyManager.Core.Models.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace AgencyManager.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Agency> Agencies { get; set; } = null!;
        public DbSet<Cash> Cash { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<ContractService> Contracts { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Locality> Localities { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<VirtualSale> VirtualSales { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

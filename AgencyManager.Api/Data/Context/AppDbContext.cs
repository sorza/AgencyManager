using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgencyManager.Core.Models.Entities;
using System.Reflection;
using System;
using Flunt.Notifications;

namespace AgencyManager.Api.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public class ProcessCardContext : DbContext
    {
        public ProcessCardContext(DbContextOptions<ProcessCardContext> options) : base(options)
        {
        }

        public DbSet<ProcessCard> ProcessCards { get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<ProcessCardKey> ProcessCardKeys { get; set; }
        public DbSet<BlisProductsView> BlisProductsView { get; set; }
        public DbSet<BlisCoresView> BlisCoresView { get; set; }
        public DbSet<ProductAlert> ProductAlerts { get; set; }
        public DbSet<BlisCustomersView> BlisCustomersView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessCard>().HasMany(x => x.DataPoints).WithOne();
            modelBuilder.Entity<Approver>().HasMany(x => x.DataPoints).WithOne(y => y.Approver);
            modelBuilder.Entity<DataPoint>().HasOne(x => x.Approver).WithMany(y => y.DataPoints);
        }
    }
}
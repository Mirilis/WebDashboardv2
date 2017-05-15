using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebDashboardv2.Model
{
    public class DataPoint
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Key { get; set; }
        public string Value { get; set; }


        public int ApproverID { get; set; }

        [Required]
        public DateTime ApprovedDate { get; set; }

        [ForeignKey("ApproverID")] public virtual Approver Approver { get; set; }
        
        public string Type { get; set; }



    }
    public class Approver
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string WindowsName { get; set; }
        [Required]
        public string Email { get; set; }

        public string Title { get; set; }

        public ApproverAccess ValidAccess { get; set; }

        public virtual ICollection<DataPoint> DataPoints { get; set; }
        public Approver()
        {
            DataPoints = new List<DataPoint>();
        }
    }

    public class ProcessCardKey
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public ProcessCardClass ProcessCardClass { get; set; }
    }

    public enum ProcessCardClass
    {
        CoremakeCB22,
        Coremake321,
        CoremakeLaempe,
        Coremake106,
        CoreAssembly,
        MoldingOsborn,
        MoldingSinto,
        MeltingOsborn,
        MeltingSinto,
        CleaningOsborn,
        CleaningSinto,
        Finishing
    }

   public class BlisProductsView
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public string MoldCenter { get; set; }
        public string Impressions { get; set; }
        public string PourWeight { get; set; }
        public string CastingWeight { get; set; }
    }

    public class ProcessCard
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public ProcessCardClass ProcessCardClass { get; set; }

        [NotMapped]
        public string ProcessCardType { get => this.ProcessCardClass.ToString().ToSentenceCase(); }

        public virtual ICollection<DataPoint> DataPoints { get; set; }

        public ProcessCard()
        {
            DataPoints = new List<DataPoint>();
        }
    }
    [Flags]
    public enum ApproverAccess
    {
        CoremakeCB22 = 1,
        Coremake321 = 2 ,
        CoremakeLaempe = 4,
        Coremake106 =8,
        CoreAssembly = 16,
        MoldingOsborn = 32,
        MoldingSinto = 64,
        MeltingOsborn = 128,
        MeltingSinto = 256,
        CleaningOsborn = 512,
        CleaningSinto = 1024,
        Finishing = 2048
    }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessCard>().HasMany(x => x.DataPoints).WithOne();
            modelBuilder.Entity<Approver>().HasMany(x => x.DataPoints).WithOne(y => y.Approver);
            modelBuilder.Entity<DataPoint>().HasOne(x => x.Approver).WithMany(y => y.DataPoints);
        }
    }
  
}

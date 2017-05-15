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

    public class ProcessCardContext : DbContext
    {
        public ProcessCardContext(DbContextOptions<ProcessCardContext> options) : base(options)
        {

        }

        public DbSet<ProcessCard> ProcessCards { get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<ProcessCardKey> ProcessCardKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessCard>().HasMany(x => x.DataPoints).WithOne();
            modelBuilder.Entity<Approver>().HasMany(x => x.DataPoints).WithOne(y => y.Approver);
            modelBuilder.Entity<DataPoint>().HasOne(x => x.Approver).WithMany(y => y.DataPoints);
        }
    }
  
}

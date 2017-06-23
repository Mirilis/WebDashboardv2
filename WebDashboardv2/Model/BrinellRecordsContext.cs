using Microsoft.EntityFrameworkCore;

namespace WebDashboardv2.Model
{
    public class BrinellRecordsContext :DbContext
    {
        public BrinellRecordsContext(DbContextOptions<BrinellRecordsContext> options) : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<ProductionHardnessSummary> ProductionHardnessSummaries { get; set; }
       
        public DbSet<FileManagerHistory> FileManagerHistory { get; set; }
        public DbSet<SuspectRecord> SuspectRecords { get; set; }
        public DbSet<HistoricalRecord> HistoricalRecords { get; set; }
        public DbSet<RangeData> RangeData { get; set; }
    }
}
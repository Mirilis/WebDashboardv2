using Microsoft.EntityFrameworkCore;

namespace WebDashboardv2.Model
{
    public class BrinellRecordsContext :DbContext
    {
        public BrinellRecordsContext(DbContextOptions<BrinellRecordsContext> options) : base(options)
        {
        }

        public DbSet<BossRangeData> RangeData { get; set; }
        public DbSet<Records> Records { get; set; }
        public DbSet<ProductionHardness> ProductionHardnesses { get; set; }
    }
}
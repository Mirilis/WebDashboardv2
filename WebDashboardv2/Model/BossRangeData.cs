using System.ComponentModel.DataAnnotations;
namespace WebDashboardv2.Model
{
    public class BossRangeData
    {
        public string Product { get; set; }
        [Key]
        public int ID { get; set; }
        public string Specification { get; set; }
        public double RangeLow { get; set; }
        public double RangeHigh { get; set; }
    }
}
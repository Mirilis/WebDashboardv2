using System.ComponentModel.DataAnnotations;

namespace WebDashboardv2.Model
{
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
        public string ActiveStatus { get; set; }
        public int CustomerNumber { get; set; }
    }
  
}

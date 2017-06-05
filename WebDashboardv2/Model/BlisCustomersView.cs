using System.ComponentModel.DataAnnotations;

namespace WebDashboardv2.Model
{
    public class BlisCustomersView
    {
        [Key]
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string AddressL1 { get; set; }
        public string AddressL2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
  
}

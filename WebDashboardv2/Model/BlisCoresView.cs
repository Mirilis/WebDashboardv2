using System.ComponentModel.DataAnnotations;

namespace WebDashboardv2.Model
{
    public class BlisCoresView
    {
        [Key]
        [StringLength(15)]
        public string ID { get; set; }
        public string BaseCoreNumber { get; set; }
        public string ProductNumber { get; set; }
        public string CoreWeightPerCavityOrFamilySet { get; set; }
        public string Box { get; set; }
        public string CoresPerFamily { get; set; }
        public string MachineType { get; set; }
        public string ActiveStatus { get; set; }


                

        

    }
  
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebDashboardv2.Model
{
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
  
}

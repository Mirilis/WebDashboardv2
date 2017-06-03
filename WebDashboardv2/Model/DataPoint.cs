using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
  
}

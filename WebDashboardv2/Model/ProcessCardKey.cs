using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebDashboardv2.Model
{
    public class ProcessCardKey
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public ProcessCardClass ProcessCardClass { get; set; }
    }
  
}

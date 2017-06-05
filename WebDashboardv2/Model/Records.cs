using System;
using System.ComponentModel.DataAnnotations;

namespace WebDashboardv2.Model
{
    public class Records
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public float BHNReading { get; set; }
        public string Product { get; set; }
        public String CastDate { get; set; }
        public DateTime DateCast { get; set; }
    }
}
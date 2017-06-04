using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public class ProductAlert
    {
        [Key]
        public int ID { get; set; }
        public string Product { get; set; }
        public string Title { get; set; }
        public string Customer { get; set; }
        public string Comments { get; set; }
        public string ActionRequired { get; set; }
        public DateTime AlertDate { get; set; }
        public int Quantity { get; set; }
        public string AuthorizedBy { get; set; }
        public string Image1Path { get; set; }
        public string Image2Path { get; set; }
        public string Image3Path { get; set; }
        public string Image4Path { get; set; }
        public string TemplateTypePath { get; set; }
        public int RepeatCount { get; set; }
        public string RootCause { get; set; }
        public Departments Departments { get; set; }
        [NotMapped]
        public List<string> AffectedDepartments { get; set; }
    }
}

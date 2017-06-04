using System;
using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public interface IProductAlerts
    {
        int ID { get; set; }
        string Product { get; set; }
        string Title { get; set; }
        string Customer { get; set; }
        string Comments { get; set; }
        string ActionRequired { get; set; }
        DateTime AlertDate { get; set; }
        int Quantity { get; set; }
        string AuthorizedBy { get; set; }
        string Image1Path { get; set; }
        string Image2Path { get; set; }
        string Image3Path { get; set; }
        string Image4Path { get; set; }
        string TemplateTypePath { get; set; }
        int RepeatCount { get; set; }
        string RootCause { get; set; }
        Departments Departments { get; set; }
        List<string> AffectedDepartments { get; set; }
    }
}
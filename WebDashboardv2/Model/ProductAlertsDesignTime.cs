﻿using System;

namespace WebDashboardv2.Model
{
    public class ProductAlertsDesignTime : IProductAlerts
    {

        public string Product { get => "TEST1"; set => throw new NotImplementedException(); }
        public string Title { get => "Test Alert"; set => throw new NotImplementedException(); }
        public string Customer { get => "That Guy"; set => throw new NotImplementedException(); }
        public string Comments { get => "How the hell did this get out the door?"; set => throw new NotImplementedException(); }
        public string ActionRequired { get => "Don't ship half a casting"; set => throw new NotImplementedException(); }
        public DateTime AlertDate { get => DateTime.Now.AddDays(-1); set => throw new NotImplementedException(); }
        public int Quantity { get => 27; set => throw new NotImplementedException(); }
        public string AuthorizedBy { get => "Adam Hoover"; set => throw new NotImplementedException(); }
        public string Image1Path { get => "blank"; set => throw new NotImplementedException(); }
        public string Image2Path { get => "blank"; set => throw new NotImplementedException(); }
        public string Image3Path { get => "blank"; set => throw new NotImplementedException(); }
        public string Image4Path { get => "blank"; set => throw new NotImplementedException(); }
        public string TemplateTypePath { get => "blank"; set => throw new NotImplementedException(); }

        public ProductAlertsDesignTime()
        {

        }
    }
}
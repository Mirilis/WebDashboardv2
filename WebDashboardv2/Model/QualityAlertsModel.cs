using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDashboardv2.Model;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;

namespace WebDashboardv2.Model
{
    public class QualityAlertsModel : IQualityAlertsModel
    {
        private readonly List<IProductAlerts> productAlerts;

        public QualityAlertsModel(ProcessCardContext context)
        {
            productAlerts = new List<IProductAlerts>(context.ProductAlerts.ToList().Cast<IProductAlerts>());
        }

        public List<IProductAlerts> ProductAlerts => productAlerts;
    }
}
using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public class QualityAlertsModelDesignTime : IQualityAlertsModel
    {
        private readonly List<IProductAlerts> productAlerts;
        public List<IProductAlerts> ProductAlerts => productAlerts;
        public QualityAlertsModelDesignTime()
        {
            productAlerts = new List<IProductAlerts>() { new ProductAlertsDesignTime() };
        }
    }
}
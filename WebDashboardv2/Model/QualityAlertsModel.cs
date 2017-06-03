using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public class QualityAlertsModel : IQualityAlertsModel
    {
        private readonly List<IProductAlerts> productAlerts;

        public QualityAlertsModel(ProcessCardContext context)
        {
        }

        public List<IProductAlerts> ProductAlerts => productAlerts;
    }
}
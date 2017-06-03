using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public interface IQualityAlertsModel
    {
        List<IProductAlerts> ProductAlerts { get; }
    }
}
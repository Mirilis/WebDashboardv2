using System.Collections.Generic;

namespace WebDashboardv2.Model
{
    public interface IProductsModel
    {
        List<BlisProductsView> Products { get; }
    }
}

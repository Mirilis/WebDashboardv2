using System.Collections.Generic;
using System.Linq;

namespace WebDashboardv2.Model
{
    public class ProductsModel : IProductsModel
    {
        private readonly List<BlisProductsView> products;
        private readonly ProcessCardContext context;

        public List<BlisProductsView> Products => products;

        public ProductsModel(ProcessCardContext context)
        {
            this.context = context;
            products = context.BlisProductsView.Where(x => x.ActiveStatus == "Y").ToList();
        }
    }
}
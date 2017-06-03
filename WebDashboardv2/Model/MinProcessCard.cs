namespace WebDashboardv2.Model
{
    public class MinProcessCard
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProcessCardType { get; set; }
        public MinProcessCard(int id, string prod, string cls)
        {
            this.ID = id;
            this.ProductName = prod;
            this.ProcessCardType = cls;
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebDashboardv2.Model
{
    public interface IProcessCardsModel
    {
        List<MinProcessCard> DepartmentalCards(ProcessCardClass pcc);
        bool Update(string filename, string key, string value);
        ProcessCard GetProcessCard(int id);
    }

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

    
    public class ProcessCardsModel : IProcessCardsModel
    {
        private readonly List<BlisProductsView> products;
            
        private List<MinProcessCard> minCards;
        public List<MinProcessCard> MinCards
        {
            get
            {
                if (minCards == null)
                {
                    minCards = context.ProcessCards.Where(a=> products.Any(y=>a.ProductName.Contains(y.Product))).Select(x => new MinProcessCard(x.ID, x.ProductName, x.ProcessCardType)).OrderBy(y => y.ProductName).ToList();
                }
                return minCards;
            }
        }

        public ProcessCard GetProcessCard(int id)
        {
            return context.ProcessCards.Where(x => x.ID == id).Include(cards => cards.DataPoints).First();
        }

        
        private readonly ProcessCardContext context;
        private readonly IUserAccessModel userAccess;
        public ProcessCardsModel(ProcessCardContext processCardContext, IUserAccessModel userAccess)
        {
            this.context = processCardContext;
            this.userAccess = userAccess;
            this.products = context.BlisProductsView.Where(x => x.ActiveStatus.Contains("Y")).ToList();

        }

        public List<MinProcessCard> DepartmentalCards(ProcessCardClass pcc)
        {
            if ((int)pcc == 0)
            {
                var pcc1 = (ProcessCardClass)1;
                var pcc2 = (ProcessCardClass)2;
                var pcc3 = (ProcessCardClass)3;
                return MinCards.Where(x => x.ProcessCardType == pcc.ToString().ToSentenceCase() || x.ProcessCardType == pcc1.ToString().ToSentenceCase() || x.ProcessCardType == pcc2.ToString().ToSentenceCase() || x.ProcessCardType == pcc3.ToString().ToSentenceCase()).ToList();
            }
            return MinCards.Where(x => x.ProcessCardType == pcc.ToString().ToSentenceCase()).ToList();
        }
        public bool Update(string ID, string key, string value)
        {
            if (context.ProcessCards.Any(x=>x.ID == int.Parse(ID)))
            {
                var pcA = context.ProcessCards.Where(x => x.ID == int.Parse(ID)).Include("DataPoints").ToList();
                var pc = pcA.First().DataPoints.Where(x => x.Key == key);
                if (pc.Any())
                {
                    var newDataPoint = new DataPoint();
                    newDataPoint.Key = pc.First().Key;
                    newDataPoint.Value = value;
                    newDataPoint.Approver = context.Approvers.Where(x => x.Name == userAccess.Name).First();
                    newDataPoint.ApprovedDate = DateTime.Now;
                    newDataPoint.Type = pc.First().Type;
                    pcA.First().DataPoints.Add(newDataPoint);
                    context.SaveChanges();
                    return true;

                }
            }
            return false;
        }
    }

    
}

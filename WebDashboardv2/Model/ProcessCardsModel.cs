using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDashboardv2.Model
{
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
                    minCards = context.ProcessCards.Where(a => products.Any(y => a.ProductName.Contains(y.Product))).Select(x => new MinProcessCard(x.ID, x.ProductName, x.ProcessCardType)).OrderBy(y => y.ProductName).ToList();
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
            switch (pcc)
            {
                case ProcessCardClass.CoremakeCB22:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)2).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)3).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.Coremake321:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)2).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)3).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.CoremakeLaempe:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)2).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)3).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.Coremake106:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)1).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)2).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)3).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.CoreAssembly:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)4).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.MoldingOsborn:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)5).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)6).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.MoldingSinto:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)6).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)5).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.MeltingOsborn:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)7).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)8).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.MeltingSinto:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)8).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)7).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.CleaningOsborn:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)9).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)10).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.CleaningSinto:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)10).ToString().ToSentenceCase() || x.ProcessCardType == ((ProcessCardClass)9).ToString().ToSentenceCase()).ToList();
                case ProcessCardClass.Finishing:
                    return MinCards.Where(x => x.ProcessCardType == ((ProcessCardClass)11).ToString().ToSentenceCase()).ToList();
                default:
                    return null;
            }
        }

        public bool Update(string ID, string key, string value)
        {
            if (context.ProcessCards.Any(x => x.ID == int.Parse(ID)))
            {
                var pcA = context.ProcessCards.Where(x => x.ID == int.Parse(ID)).Include("DataPoints").ToList();
                var pc = pcA.First().DataPoints.Where(x => x.Key == key);
                if (pc.Any())
                {
                    var newDataPoint = new DataPoint()
                    {
                        Key = pc.First().Key,
                        Value = value,
                        Approver = context.Approvers.Where(x => x.Name == userAccess.Name).First(),
                        ApprovedDate = DateTime.Now,
                        Type = pc.First().Type,
                    };

                    pcA.First().DataPoints.Add(newDataPoint);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
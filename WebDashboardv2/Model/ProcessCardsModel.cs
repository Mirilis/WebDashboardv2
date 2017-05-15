using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebDashboardv2.Model
{
    public interface IProcessCardsModel
    {
        List<ProcessCard> ProcessCards { get; set; }
        List<ProcessCard> DepartmentalCards(ProcessCardClass pcc);
        bool Update(string filename, string key, string value);
    }

    public class ProcessCardsModel : IProcessCardsModel
    {
        public List<ProcessCard> ProcessCards { get; set; }
        private readonly ProcessCardContext context;
        public ProcessCardsModel(ProcessCardContext processCardContext)
        {
            this.context = processCardContext;
            ProcessCards = context.ProcessCards.Include(cards => cards.DataPoints).ToList();
        }
        public List<ProcessCard> DepartmentalCards(ProcessCardClass pcc)
        {
            return ProcessCards.Where(x => x.ProcessCardClass == pcc).OrderBy(y=>y.ProductName).ToList();
        }
        public bool Update(string filename, string key, string value)
        {
            var pcA = context.ProcessCards.Where(x => x.ProductName == filename);
            if (pcA.Any())
            {
                var pc = pcA.First().DataPoints.Where(x=>x.Key == key);
                if (pc.Any())
                {
                    pc.First().Value = value;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }

    
}

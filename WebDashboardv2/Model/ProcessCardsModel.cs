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
    }

    public class ProcessCardsModel : IProcessCardsModel
    {
        public List<ProcessCard> ProcessCards { get; set; }
        private readonly ProcessCardContext sql;
        public ProcessCardsModel(ProcessCardContext processCardContext)
        {
            this.sql = processCardContext;
            ProcessCards = sql.ProcessCards.Include(cards => cards.DataPoints).ToList();
        }
        public List<ProcessCard> DepartmentalCards(ProcessCardClass pcc)
        {
            return ProcessCards.Where(x => x.ProcessCardClass == pcc).ToList();
        }
    }
}

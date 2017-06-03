using System.Collections.Generic;


namespace WebDashboardv2.Model
{
    public interface IProcessCardsModel
    {
        List<MinProcessCard> DepartmentalCards(ProcessCardClass pcc);
        bool Update(string filename, string key, string value);
        ProcessCard GetProcessCard(int id);
    }

    
}

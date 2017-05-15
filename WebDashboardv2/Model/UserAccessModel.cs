using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDashboardv2.Model
{
    public interface IUserAccessModel
    {
        string Name { get;  }
        string Email { get; }
        string Title { get; }
        bool IsAuthorizedToEdit(ProcessCardClass c);
    }
    public class UserAccessModel : IUserAccessModel
    {
        private readonly ProcessCardContext context;
        private Approver currentUser;
        
        public UserAccessModel(ProcessCardContext context)
        {
            var currUsr = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.context = context;
            this.currentUser = context.Approvers.Where(x => x.WindowsName == currUsr).First();
        }

        public string Name { get =>  currentUser.Name; } 
        public string Email { get => currentUser.Email; }
        public string Title { get => currentUser.Title; }

        public bool IsAuthorizedToEdit(ProcessCardClass c)
        {
            var p = c.ToString();
            var e = (ApproverAccess)Enum.Parse(typeof(ApproverAccess), p);
            return currentUser.ValidAccess.HasFlag(e);
        }
    }
}

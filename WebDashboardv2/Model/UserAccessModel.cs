using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace WebDashboardv2.Model
{
    public interface IUserAccessModel
    {
        string Name { get;  }
        string Email { get; }
        string Title { get; }
        bool IsAuthorizedToEdit(ProcessCardClass c);
        void UpdateUser(string currUsr);
    }
    public class UserAccessModel : IUserAccessModel
    {
        private readonly ProcessCardContext context;
        private Approver currentUser;
        
        public UserAccessModel(ProcessCardContext context, IHttpContextAccessor contextaccessor)
        {
            this.context = context;
            
        }
        public void UpdateUser(string currUsr)
        {
            if (currUsr == null)
            {
                currUsr = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            }
            try
            {
                this.currentUser = context.Approvers.Where(x => x.WindowsName == currUsr).First();
            }
            catch
            {
                context.Add(new Approver() { Email = "blank", Name = "Anonymous", ValidAccess = 0, Title = "Anonymous User", WindowsName = currUsr });
                context.SaveChanges();
                this.currentUser = context.Approvers.Where(x => x.WindowsName == currUsr).First();
            }
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

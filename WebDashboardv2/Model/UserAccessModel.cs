using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace WebDashboardv2.Model
{
    public class UserAccessModel : IUserAccessModel
    {
        private readonly ProcessCardContext context;
        private readonly IHttpContextAccessor contextAccessor;
        private Approver currentUser;

        public bool Exists { get; private set; }

        public UserAccessModel(ProcessCardContext context, IHttpContextAccessor contextaccessor)
        {
            this.context = context;
            this.contextAccessor = contextaccessor;
            UpdateUser(contextAccessor.HttpContext.User.Identity.Name);
        }

        private void UpdateUser(string currUsr)
        {
            if (currUsr == null)
            {
                currUsr = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                Exists = false;
            }
            try
            {
                this.currentUser = context.Approvers.Where(x => x.WindowsName == currUsr).First();
                Exists = true;
            }
            catch
            {
                context.Add(new Approver() { Email = "blank", Name = "Anonymous", ValidAccess = 0, Title = "Anonymous User", WindowsName = currUsr });
                context.SaveChanges();
                this.currentUser = context.Approvers.Where(x => x.WindowsName == currUsr).First();
            }
        }

        public string Name { get => currentUser.Name; }
        public string Email { get => currentUser.Email; }
        public string Title { get => currentUser.Title; }

        public bool CanAddProcessCards => false;

        public bool CanCreateQualityAlerts => true;

        public bool IsAuthorizedToEdit(ProcessCardClass c)
        {
            var p = c.ToString();
            var e = (ApproverAccess)Enum.Parse(typeof(ApproverAccess), p);
            return currentUser.ValidAccess.HasFlag(e);
        }
    }
}
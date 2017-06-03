namespace WebDashboardv2.Model
{
    public interface IUserAccessModel
    {
        string Name { get;  }
        string Email { get; }
        string Title { get; }
        bool IsAuthorizedToEdit(ProcessCardClass c);
        bool Exists { get; }
        bool CanAddProcessCards { get; }
    }
}

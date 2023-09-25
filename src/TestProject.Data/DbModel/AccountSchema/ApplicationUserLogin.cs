using Microsoft.AspNetCore.Identity;
namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationUserLogin: IdentityUserLogin<Guid>
{
    public virtual ApplicationUser User { get; set; }
}

using Microsoft.AspNetCore.Identity;

namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}

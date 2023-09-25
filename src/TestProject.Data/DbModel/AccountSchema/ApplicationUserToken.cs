using Microsoft.AspNetCore.Identity;

namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationUserToken: IdentityUserToken<Guid>
{
    public virtual ApplicationUser User { get; set; }
}

using Microsoft.AspNetCore.Identity;

namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationUserClaim: IdentityUserClaim<Guid>
{
    public virtual ApplicationUser User { get; set; }
}

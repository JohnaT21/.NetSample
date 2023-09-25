using Microsoft.AspNetCore.Identity;

namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationRoleClaim: IdentityRoleClaim<Guid>
{
    public virtual ApplicationRole Role { get; set; }
}

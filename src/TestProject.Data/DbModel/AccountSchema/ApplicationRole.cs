using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TestProject.Data.DbModel.ConfigurationSchema;

namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole()
    {
        RoleClaims = new HashSet<ApplicationRoleClaim>();

        UserRoles = new HashSet<ApplicationUserRole>();
        RoleMenuPermissions = new HashSet<RoleMenuPermission>();
    }
    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
    //public override int Id { get; set; }
    public Guid RoleType { get; set; }
    public bool HasOrganizationUnit { get; set; }
    public string Code { get; set; }
    public bool IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    public virtual  ICollection<RoleMenuPermission> RoleMenuPermissions { get; set; }
}

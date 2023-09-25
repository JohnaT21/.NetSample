using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TestProject.Data.DbModel.AccountSchema;

public class ApplicationUser: IdentityUser<Guid>
{
    public ApplicationUser()
    {
        Claims = new HashSet<ApplicationUserClaim>();
        Logins = new HashSet<ApplicationUserLogin>();
        Tokens = new HashSet<ApplicationUserToken>();
        UserRoles = new HashSet<ApplicationUserRole>();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public Guid? OrganizationUnitId { get; set; }
    public Guid? MfrOrganizationUnitId { get; set; }
    public bool ChangePassword { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string Status { get; set; } = "Active"; // Active, NotActive, Locked
    public DateTime NextPasswordExpiryDate { get; set; }
    public DateTime? EmailVerifiedDate { get; set; }

    public string? UserType { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? MFRDepartmentId { get; set; }
    public Guid? StoreId { get; set; }

    public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
    public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
    public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

   
}

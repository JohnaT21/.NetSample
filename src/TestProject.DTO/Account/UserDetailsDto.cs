using System;
using System.Collections.Generic;

namespace TestProject.DTO.Account;

public class UserDetailsDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public string Address { get; set; }
    //public string PersonalImagePath { get; set; }
    public string IP { get; set; }
    public bool ChangePassword { get; set; }
    public string CallingCode { get; set; }
    public Guid? OrganinzationUnitId { get; set; }
    //public string Education { get; set; }
    //public string Experience { get; set; }
    //public string Specialties { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string Status { get; set; } // Active, NotActive, Locked
    public string ElectronicSignature { get; set; }
    public DateTime NextPasswordExpiryDate { get; set; }
    public DateTime? EmailVerifiedDate { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }

    public Guid? UserRoleLevelId { get; set; }
    public List<Guid> UserRoleLevels { get; set; }
    public List<string> UserRoles { get; set; }

    // UI
    public string UserRoleLevelName { get; set; }
    
    
    public string? UserType { get; set; } 
    public Guid? DepartmentId { get; set; }
    public Guid? StoreId { get; set; }
}

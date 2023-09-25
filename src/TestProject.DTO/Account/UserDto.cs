using System;
using System.Collections.Generic;
using TestProject.Data.DbModel.AccountSchema;

namespace TestProject.DTO.Account;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public string UserName { get; set; }
    public bool ChangePassword { get; set; }
    public Guid? OrganizationUnitId { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string Status { get; set; } // Active, NotActive, Locked
    public DateTime NextPasswordExpiryDate { get; set; }
    public DateTime? EmailVerifiedDate { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public List<ApplicationUserRole>? UserRoles { get; set; }
    public string? UserType { get; set; } 
    public Guid? DepartmentId { get; set; }
    public Guid? StoreId { get; set; }
}

public class MyModel
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}

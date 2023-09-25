using System.ComponentModel.DataAnnotations;

public class UserForRegistrationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public Guid? OrganizationUnitId { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<string> Roles { get; set; }
    public string? UserType { get; set; } 
    public Guid? DepartmentId { get; set; }
    public Guid? StoreId { get; set; }
}


namespace TestProject.DTO.Common;

public class BaseFilterDto
{
    public bool ApplySort { get; set; }
    public string? SortProperty { get; set; } = "CreatedOn";
    public bool IsAscending { get; set; }
    public bool? IsActive { get; set; }
    // For security
    public Guid LoggedInUserId { get; set; }
    public bool IsSuperAdmin { get; set; }
    
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 1000;
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Data.BaseModel;
using TestProject.Data.DbModel.AccountSchema;

namespace TestProject.Data.DbModel.ConfigurationSchema;
[Table("menus", Schema = "account")]
public class Menu : DynamicLookup
{
    public Menu()
    {
        // Permissions = new HashSet<Permission>();
        MenuRoles = new HashSet<RoleMenuPermission>();
        MenuPlans = new HashSet<MenuPlan>();
    }
    public Guid Id { get; set; }
    public string Path { get; set; }
    public string Title { get; set; }
    public bool IsExternalLink { get; set; }
    public bool IsSubMenu { get; set; }
    public int? Priority { get; set; }
    public string? IconType { get; set; }
    public string? Icon { get; set; }
    public string? Class { get; set; }
    public bool? GroupTitle { get; set; }
    public string? Badge { get; set; }
    public string? BadgeClass { get; set; }
    public Guid? ParentMenuId { get; set; }
    public int? Order { get; set; }
    public bool IsDeleted { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
    public virtual ICollection<RoleMenuPermission> MenuRoles { get; set; }
    public virtual ICollection<MenuPlan> MenuPlans { get; set; }

}

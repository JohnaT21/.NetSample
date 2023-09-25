using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Data.BaseModel;
using TestProject.Data.DbModel.ConfigurationSchema;

namespace TestProject.Data.DbModel.AccountSchema;

// [Table("role_menu_permissions", Schema = "account")]
public class RoleMenuPermission : BaseEntity
{

    public Guid PermissionId { get; set; }
    public Guid RoleId { get; set; }
    public Guid MenuId { get; set; }
    public virtual Permission Permission { get; set; }
    public virtual ApplicationRole Role { get; set; }
    public virtual Menu Menu { get; set; }
}

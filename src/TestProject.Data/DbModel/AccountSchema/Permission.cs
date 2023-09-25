using TestProject.Data.BaseModel;
using TestProject.Data.DbModel.ConfigurationSchema;

namespace TestProject.Data.DbModel.AccountSchema;

public class Permission : DynamicLookup
{
    // public Permission()
    // {
    //     RolePermissions = new HashSet<RoleMenuPermission>();
    // }
    public Guid Id { get; set; }
    // public string name { get; set; }
    // public string code { get; set; }
    public Guid? MenuId { get; set; }
    public virtual Menu Menu { get; set; }
}

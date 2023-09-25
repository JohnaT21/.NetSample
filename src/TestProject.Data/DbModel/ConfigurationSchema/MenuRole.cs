using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Data.DbModel.AccountSchema;

namespace TestProject.Data.DbModel.ConfigurationSchema;

[Table("menu_roles", Schema = "configuration")]
public class MenuRole
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public Guid RoleId { get; set; }
    public virtual Menu Menu { get; set; }
    public virtual ApplicationRole Role { get; set; }

}

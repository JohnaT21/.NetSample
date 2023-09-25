using System.ComponentModel.DataAnnotations.Schema;
namespace TestProject.Data.DbModel.ConfigurationSchema;

[Table("menu_plans", Schema = "configuration")]
public class MenuPlan
{
    public int Id { get; set; }
    public int MenuId { get; set; }
    public int PlanId { get; set; }
    public virtual Menu Menu { get; set; }
             
}

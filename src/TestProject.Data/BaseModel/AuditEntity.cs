using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Data.DbModel.AccountSchema;

namespace TestProject.Data.BaseModel;

public class AuditEntity
{
    public Guid Id { get; set; }
    public DateTime DateOfAction { get; set; }
    public string Action { get; set; }

    [Required]
    [ForeignKey("Creator")]
    public Guid? CreatedBy { get; set; }

    public virtual ApplicationUser Creator { get; set; }
}

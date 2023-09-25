using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Core.Interfaces;
using TestProject.Data.DbModel.AccountSchema;

namespace TestProject.Data.BaseModel;

public class DynamicLookup : ILookupEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    [ForeignKey("Creator")]
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    [ForeignKey("Updator")]
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public virtual ApplicationUser Creator { get; set; }
    public virtual ApplicationUser Updator { get; set; }
}

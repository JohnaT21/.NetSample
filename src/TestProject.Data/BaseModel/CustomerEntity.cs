using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Core.Interfaces;

namespace TestProject.Data.BaseModel;

public class CustomerEntity: IBaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    [ForeignKey("CustomerCreator")]
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    [ForeignKey("CustomerUpdator")]
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

}

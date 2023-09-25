using System;

namespace TestProject.DTO.Common;

public class NullableBaseEntityDto: IBaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }


    // UI
    public string Creator { get; set; }
    public string Updator { get; set; }
}

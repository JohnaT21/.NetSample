using System;
namespace TestProject.Core.Interfaces;

public interface IAuditable
{
    Guid CreatedBy { get; set; }
    DateTime CreatedOn { get; set; }
    Guid? UpdatedBy { get; set; }
    DateTime? UpdatedOn { get; set; }
}

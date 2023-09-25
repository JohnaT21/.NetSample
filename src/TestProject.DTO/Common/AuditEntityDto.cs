using System;

namespace TestProject.DTO.Common;

public class AuditEntityDto
{
    public Guid Id { get; set; }
    public DateTime DateOfAction { get; set; }
    public string Action { get; set; }
    public Guid CreatedBy { get; set; }

    // UI
    public string Creator { get; set; }
}

using System;
using TestProject.DTO.Common;

namespace TestProject.DTO.Configuration.ConfigurationAudit;

public class ConfigurationAuditFilterDto : BaseFilterDto
{
    public DateTime? DateOfAction { get; set; }
    public string Action { get; set; }
    public Guid CreatedBy { get; set; }
}

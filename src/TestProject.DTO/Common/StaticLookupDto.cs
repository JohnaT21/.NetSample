using TestProject.Core.Interfaces;

namespace TestProject.DTO.Common;

public class StaticLookupDto: ILookupEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }
}

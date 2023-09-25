using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Core.Interfaces;

namespace TestProject.Data.BaseModel;

public class StaticLookup : ILookupEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public string? Name { get; set; }
}


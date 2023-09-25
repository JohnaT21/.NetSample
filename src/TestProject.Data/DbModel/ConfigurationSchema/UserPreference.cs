using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TestProject.Data.DbModel.AccountSchema;

namespace TestProject.Data.DbModel.ConfigurationSchema;

[Table("user_preferences", Schema = "configuration")]
public class UserPreference
{
    public int Id { get; set; }
    public string PreferenceType { get; set; }
    public string PreferenceKey { get; set; }
    public string PreferenceValue { get; set; }
    public int UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}

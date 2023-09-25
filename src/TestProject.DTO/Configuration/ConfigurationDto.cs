namespace TestProject.DTO.Configuration;

public class ConfigurationDto
{
    public Guid Id { get; set; }
    // User Managment
    public Guid NumOfDaysToChangePassword { get; set; }
    public int AccountLoginAttempts { get; set; }
    public int PasswordExpiryTime { get; set; }
    public double UserPhotosize { get; set; }
    public double AttachmentsMaxSize { get; set; }
    public int TimesCountBeforePasswordReuse { get; set; }
    public int TimeToSessionTimeOut { get; set; }
    public int TrialPeriodDays { get; set; }
    public int ReminderDays { get; set; }
}

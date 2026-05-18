namespace backend.DTOs;

public class UpdateNewsletterSettingsDto
{
    public bool NewsletterEnabled { get; set; }

    public string NewsletterFrequency { get; set; } = "Weekly";
}
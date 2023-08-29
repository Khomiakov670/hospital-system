namespace Services.Options;

public class EmailOptions
{
    public const string Section = "EmailSender";
    public string From { get; set; } = null!;
    public string SmptServer { get; set; } = null!;
    public string Port { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Username { get; set; } = null!;
}
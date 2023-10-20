namespace N58_C.Models.Settings;

public class EmailSenderSettings
{
    public string Host { get; set; } = default!;

    public int Port { get; set; }

    public string CredentialAddress { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string TestValue { get; set; } = string.Empty;
}
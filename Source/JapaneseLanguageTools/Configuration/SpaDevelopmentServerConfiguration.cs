namespace JapaneseLanguageTools.Configuration;

public class SpaDevelopmentServerConfiguration
{
    public static string SectionName { get; } = "SpaDevelopmentServer";

    public string? DevelopmentServerBaseUri { get; set; }
}

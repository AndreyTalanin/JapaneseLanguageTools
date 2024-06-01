namespace JapaneseLanguageTools.Data.Entities;

public class WordTag
{
    public int WordId { get; set; }

    public int TagId { get; set; }

    public Tag? Tag { get; set; }
}

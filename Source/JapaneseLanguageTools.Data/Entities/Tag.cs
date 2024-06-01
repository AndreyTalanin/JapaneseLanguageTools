using System.ComponentModel.DataAnnotations;

namespace JapaneseLanguageTools.Data.Entities;

public class Tag
{
    [Key]
    public int Id { get; set; }

    [StringLength(256)]
    public string Name { get; set; } = string.Empty;
}

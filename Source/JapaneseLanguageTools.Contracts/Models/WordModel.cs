using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Contracts.Models;

public class WordModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? WordGroupId { get; set; }

    [StringLength(256)]
    public string Characters { get; set; } = string.Empty;

    public CharacterTypes CharacterTypes { get; set; }

    [StringLength(512)]
    public string? Pronunciation { get; set; }

    [StringLength(512)]
    public string? Meaning { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset UpdatedOn { get; set; }

    public IList<TagModel> WordTags { get; set; } = new List<TagModel>();

    public WordGroupModel? WordGroup { get; set; }
}

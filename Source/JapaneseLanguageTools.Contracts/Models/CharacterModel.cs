using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using JapaneseLanguageTools.Contracts.Enums;

namespace JapaneseLanguageTools.Contracts.Models;

public class CharacterModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? CharacterGroupId { get; set; }

    [StringLength(16)]
    public string Symbol { get; set; } = string.Empty;

    public CharacterTypes Type { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Hiragana" /> and <see cref="CharacterTypes.Katakana" />.</remarks>
    [StringLength(32)]
    public string? Pronunciation { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Hiragana" /> and <see cref="CharacterTypes.Katakana" />.</remarks>
    [StringLength(32)]
    public string? Syllable { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    [StringLength(256)]
    public string? Onyomi { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    [StringLength(256)]
    public string? Kunyomi { get; set; }

    /// <remarks>Applicable only for <see cref="CharacterTypes.Kanji" />.</remarks>
    [StringLength(512)]
    public string? Meaning { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset CreatedOn { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset UpdatedOn { get; set; }

    public IList<TagModel> CharacterTags { get; set; } = new List<TagModel>();

    public CharacterGroupModel? CharacterGroup { get; set; }
}

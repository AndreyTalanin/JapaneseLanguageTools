using System;
using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

[XmlRoot(TagXmlElementName)]
public class TagXmlModel
{
    public const string TagXmlElementName = "Tag";

    [XmlAttribute]
    public int Id { get; set; }

    [XmlAttribute]
    public string Caption { get; set; } = string.Empty;

    [XmlAttribute]
    public string? PlaceholderMarker { get; set; }

    /// <remarks>See the <see cref="CreatedOnString" /> property.</remarks>
    [XmlIgnore]
    public DateTimeOffset CreatedOn { get; set; }

    /// <remarks>See the <see cref="UpdatedOnString" /> property.</remarks>
    [XmlIgnore]
    public DateTimeOffset UpdatedOn { get; set; }

    public TagXmlModel()
    {
    }

    [XmlAttribute(nameof(CreatedOn))]
    public string? CreatedOnString
    {
        get => CreatedOn.ToString("u");
        set => CreatedOn = !string.IsNullOrEmpty(value) ? DateTimeOffset.Parse(value) : default(DateTimeOffset);
    }

    [XmlAttribute(nameof(UpdatedOn))]
    public string? UpdatedOnString
    {
        get => UpdatedOn.ToString("u");
        set => UpdatedOn = !string.IsNullOrEmpty(value) ? DateTimeOffset.Parse(value) : default(DateTimeOffset);
    }
}

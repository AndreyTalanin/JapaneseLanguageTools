using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

public class CharacterGroupXmlModel
{
    [XmlAttribute("Caption")]
    public string Caption { get; set; } = string.Empty;

    [XmlAttribute("Comment")]
    public string? Comment { get; set; }

    [XmlAttribute("Enabled")]
    public bool Enabled { get; set; }

    [XmlArray("Characters")]
    [XmlArrayItem("Character")]
    public CharacterXmlModel[] Characters { get; set; } = [];
}

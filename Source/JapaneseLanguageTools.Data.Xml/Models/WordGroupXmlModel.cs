using System.Xml.Serialization;

namespace JapaneseLanguageTools.Data.Xml.Models;

public class WordGroupXmlModel
{
    [XmlAttribute("Caption")]
    public string Caption { get; set; } = string.Empty;

    [XmlAttribute("Comment")]
    public string? Comment { get; set; }

    [XmlAttribute("Enabled")]
    public bool Enabled { get; set; }

    [XmlArray("Words")]
    [XmlArrayItem("Word")]
    public WordXmlModel[] Words { get; set; } = [];
}

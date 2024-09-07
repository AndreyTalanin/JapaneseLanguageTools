using AutoMapper;

using JapaneseLanguageTools.Contracts.Models;
using JapaneseLanguageTools.Data.Xml.Models;

namespace JapaneseLanguageTools.Core.AutoMapper;

public class TagXmlSerializationProfile : Profile
{
    public TagXmlSerializationProfile()
    {
        SourceMemberNamingConvention = ExactMatchNamingConvention.Instance;
        DestinationMemberNamingConvention = ExactMatchNamingConvention.Instance;

        CreateMap<TagModel, TagXmlModel>()
            .ForMember(xmlModel => xmlModel.CreatedOnString, options => options.Ignore())
            .ForMember(xmlModel => xmlModel.UpdatedOnString, options => options.Ignore());
    }
}

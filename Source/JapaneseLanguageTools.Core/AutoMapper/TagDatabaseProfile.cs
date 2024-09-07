using AutoMapper;

using JapaneseLanguageTools.Contracts.Models;
using JapaneseLanguageTools.Data.Entities;

namespace JapaneseLanguageTools.Core.AutoMapper;

public class TagDatabaseProfile : Profile
{
    public TagDatabaseProfile()
    {
        SourceMemberNamingConvention = ExactMatchNamingConvention.Instance;
        DestinationMemberNamingConvention = ExactMatchNamingConvention.Instance;

        CreateMap<Tag, TagModel>();
    }
}

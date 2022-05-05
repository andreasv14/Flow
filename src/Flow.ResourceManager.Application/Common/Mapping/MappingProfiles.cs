using AutoMapper;
using Flow.ResourceManager.Application.Companies.Commands;
using Flow.ResourceManager.Application.Companies.Dtos;
using Flow.ResourceManager.Application.Items.Dtos;
using Flow.ResourceManager.Application.Traders.Dtos;
using Flow.ResourceManager.Domain.Entities;

namespace Flow.ResourceManager.Application.Common.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Item, ItemDto>()
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Trader, TraderDto>()
            .ForMember(dest => dest.TraderId, opt => opt.MapFrom(src => src.Id));

        CreateMap<Company, CompanyDto>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id));

        CreateMap<CreateCompanyCommand, Company>();
    }
}

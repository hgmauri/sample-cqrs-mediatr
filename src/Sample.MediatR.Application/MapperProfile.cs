using AutoMapper;
using Sample.MediatR.Application.Commands;
using Sample.MediatR.Application.Consumers;
using Sample.MediatR.Application.Queries;
using Sample.MediatR.Persistence.Context;

namespace Sample.MediatR.Application;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Client, AddClientCommand>().ReverseMap();
        CreateMap<Product, AddProductCommand>().ReverseMap();

        CreateMap<Client, GetClientsQueryResult>().ReverseMap();
        CreateMap<Product, GetProductsQueryResult>().ReverseMap();

        CreateMap<Client, IndexClient>().ReverseMap();
        CreateMap<Product, IndexProduct>().ReverseMap();
    }
}

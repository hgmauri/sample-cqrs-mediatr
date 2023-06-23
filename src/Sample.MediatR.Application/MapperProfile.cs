using AutoMapper;
using Sample.MediatR.Application.Consumers.IndexClientProducts;
using Sample.MediatR.Application.UseCases.Client.Create;
using Sample.MediatR.Application.UseCases.Client.Get;
using Sample.MediatR.Application.UseCases.Product.Create;
using Sample.MediatR.Application.UseCases.Product.Get;
using Sample.MediatR.Persistence.Context;

namespace Sample.MediatR.Application;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Client, CreateClientCommand>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();

        CreateMap<Client, GetClientsQueryResponse>().ReverseMap();
        CreateMap<Product, GetProductsQueryResponse>().ReverseMap();

        CreateMap<Client, IndexClient>().ReverseMap();
        CreateMap<Product, IndexProduct>().ReverseMap();
    }
}

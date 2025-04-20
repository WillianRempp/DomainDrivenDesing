using Application.Controller.Dto;
using Application.Domain.Product.Entity;
using Application.Domain.Product.Factory;

namespace Application.Controller.Mapper;

public static class ProductMapper
{
    public static ProductDto ToDto(IProduct product)
    {
        return new ProductDto()
        {
            Id = product.GetId(),
            Name = product.GetName(),
            Price = product.GetPrice()
        };
    }

    public static IProduct ToEntity(ProductDto productDto)
    {
        return ProductFactory.Create("a", productDto.Id, productDto.Name, productDto.Price);
    }
}
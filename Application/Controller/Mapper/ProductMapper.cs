using Application.Controller.Dto;
using Application.Domain.Product.Entity;

namespace Application.Controller.Mapper;

public static class ProductMapper
{
    public static ProductDto ToDto(Product product)
    {
        return new ProductDto()
        {
            Id = product.GetId(),
            Name = product.GetName(),
            Price = product.GetPrice()
        };
    }

    public static Product ToEntity(ProductDto productDto)
    {
        return new Product(productDto.Id, productDto.Name, productDto.Price);
    }
}
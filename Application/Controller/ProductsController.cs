using Application.Controller.Dto;
using Application.Controller.Mapper;
using Application.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/product")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.FindAllAsync();
        var productsDto = products.Select(product => ProductMapper.ToDto(product));

        return Ok(productsDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        await _repository.CreateAsync(ProductMapper.ToEntity(productDto));

        return Ok();
    }
}
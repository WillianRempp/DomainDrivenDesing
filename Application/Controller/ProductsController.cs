using Application.Controller.Dto;
using Application.Controller.Mapper;
using Application.Domain.Product.Event;
using Application.Domain.Product.Repository;
using Application.Domain.shared.Event;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/product")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly IEventDispatcher _eventDispatcher;

    public ProductsController(IProductRepository repository, IEventDispatcher eventDispatcher)
    {
        _repository = repository;
        _eventDispatcher = eventDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _repository.FindAllAsync();
        var productsDto = products.Select(ProductMapper.ToDto);

        return Ok(productsDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repository.CreateAsync(ProductMapper.ToEntity(productDto));
        await _eventDispatcher.Notify(
            new ProductCreatedEvent($"ProductCreatedEvent: Name {productDto.Name}, Price {productDto.Price}"));

        return Ok();
    }
}
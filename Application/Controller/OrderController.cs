using Application.Controller.Dto;
using Application.Controller.Mapper;
using Application.Domain.Entity;
using Application.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;

    public OrderController(IOrderRepository orderRepository, ICustomerRepository customerRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
    {
        var customer = await _customerRepository.FindByIdAsync(orderDto.Id);

        if (customer == null)
        {
            return BadRequest("Customer does not exist");
        }

        foreach (var item in orderDto.Items)
        {
            var product = await _productRepository.FindByIdAsync(item.ProductId);
            if (product == null)
            {
                return BadRequest("Customer does not exist");
            }
        }

        await _orderRepository.CreateOrderAsync(OrderMapper.ToEntity(orderDto), customer);

        return Ok();
    }
}
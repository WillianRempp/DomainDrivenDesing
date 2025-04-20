using Application.Controller.Dto;
using Application.Controller.Mapper;
using Application.Domain.Checkout.Repository;
using Application.Domain.Customer.Repository;
using Application.Domain.Product.Repository;
using Application.Domain.shared.Event;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public OrderController(IOrderRepository orderRepository, ICustomerRepository customerRepository,
        IProductRepository productRepository, IEventDispatcher eventDispatcher)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _eventDispatcher = eventDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
    {
        var customer = await _customerRepository.FindByIdAsync(orderDto.CostumerId);

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
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderRepository.FindAllAsync();
        var ordersDto = orders.Select(OrderMapper.ToDto);

        return Ok(ordersDto);
    }
}
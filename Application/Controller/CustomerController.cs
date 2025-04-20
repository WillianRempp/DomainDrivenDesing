using Application.Controller.Dto;
using Application.Controller.Mapper;
using Application.Domain.Customer.Event;
using Application.Domain.Customer.Repository;
using Application.Domain.shared.Event;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IEventDispatcher _eventDispatcher;

    public CustomerController(ICustomerRepository repository, IEventDispatcher eventDispatcher)
    {
        _repository = repository;
        _eventDispatcher = eventDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _repository.FindAllAsync();
        var customersDto = customers.Select(customer => CustomerMapper.ToDto(customer));

        return Ok(customersDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
    {
        await _repository.CreateAsync(CustomerMapper.ToEntity(customerDto));
        await _eventDispatcher.Notify(new CustomerCreatedEvent($"CustomerCreatedEvent: Name {customerDto.Name}"));

        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto)
    {
        await _repository.UpdateAsync(CustomerMapper.ToEntity(customerDto));
        await _eventDispatcher.Notify(new CustomerUpdatedEvent($"CustomerUpdatedEvent: Name {customerDto.Name}"));

        return Ok();
    }
}
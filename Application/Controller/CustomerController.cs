using Application.Controller.Dto;
using Application.Controller.Mapper;
using Application.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller;

[Route("api/customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
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

        return Ok();
    }
}
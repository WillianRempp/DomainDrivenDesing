using Application.Domain.Entity;
using Application.Domain.Repository;
using Application.Infrastructure.db.Data;
using Application.Infrastructure.db.Model.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly Context _context;

    public CustomerRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateAsync(Customer entity)
    {
        await _context.CustomerModel.AddAsync(
            CustomerMapper.ToModel(entity));
        _context.SaveChanges();
    }

    public async Task DeleteAsync(string id)
    {
        var customerModel = _context.CustomerModel.FirstOrDefault(x => x.Id == id);
        if (customerModel != null)
        {
            _context.CustomerModel.Remove(customerModel);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<Customer>> FindAllAsync()
    {
        var customers = _context.CustomerModel.Include(x => x.Address)
            .Select(x => CustomerMapper.ToEntity(x)).ToList();

        return Task.FromResult(customers);
    }


    public async Task<Customer?> FindByIdAsync(string id)
    {
        var customerModel = await _context.CustomerModel.FirstOrDefaultAsync(x => x.Id == id);
        if (customerModel == null)
        {
            return null;
        }

        return CustomerMapper.ToEntity(customerModel);
    }


    public async Task<Customer?> UpdateAsync(Customer entity)
    {
        var existingCustomer = _context.CustomerModel.FirstOrDefault(x => x.Id == entity.GetId());
        if (existingCustomer == null)
        {
            return null;
        }

        existingCustomer.Name = entity.GetName();
        existingCustomer.Active = entity.IsActive();
        existingCustomer.Address = CustomerMapper.ToModel(entity.GetAddress(), entity.GetId());
        existingCustomer.RewardPoints = entity.GetRewardsPoints();
        await _context.SaveChangesAsync();
        return CustomerMapper.ToEntity(existingCustomer);
    }
}
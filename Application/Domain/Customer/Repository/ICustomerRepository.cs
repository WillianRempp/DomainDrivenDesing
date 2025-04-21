using Application.Domain.Customer.Entity;
using Application.Domain.shared.Repository;

namespace Application.Domain.Customer.Repository;

public interface ICustomerRepository : IRepository<ICustomer>;
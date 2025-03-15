using Application.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controller
{
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
            var comments = await _repository.FindAllAsync();

            return Ok(comments);
        }
    }
}
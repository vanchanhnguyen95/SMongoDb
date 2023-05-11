using Microsoft.AspNetCore.Mvc;
using Product.API.Repositories.Interfaces;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //private readonly IRepositoryBaseAsync<CatalogProduct, long, ProductContext> _repository;
        //public ProductsController(IRepositoryBaseAsync<CatalogProduct, long, ProductContext> repository)
        //{
        //    _repository = repository;
        //}

        private readonly IProductRepository _repository;
        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _repository.GetProductsAsync();
            return Ok(result);
        }
    }
}

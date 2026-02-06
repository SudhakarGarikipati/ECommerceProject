using App.Application.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ICatalogAppService _catalogAppService;

        public ProductsController(ICatalogAppService catalogAppService)
        {
            _catalogAppService = catalogAppService;
        }

        public IActionResult Index()
        {
            var products = _catalogAppService.GetAll();
            return View(products);
        }
    }
}

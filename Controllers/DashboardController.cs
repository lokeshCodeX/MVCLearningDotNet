using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dto;



namespace WebApplication1.Controllers
{
    public class DashboardController(AppDbContext context): Controller
    {

        public IActionResult Index()
        {
            var list =  context.Products.Select(x=> new ProductDto { Id =x.Id, Color=x.Color, Description= x.Description,
            Price=x.Price, ProductName=x.ProductName }).ToList();
            return View(list);
        }

        public IActionResult ProductForm()
        {
            return View();
        }

        public async Task<IActionResult> CreateProductAsync(ProductDto dto)
        {
            var product = new Models.Product
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                Price = dto.Price,
                Color = dto.Color
            };
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }   

    }
}

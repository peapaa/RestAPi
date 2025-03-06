using Microsoft.AspNetCore.Mvc;
using RestAPi.Model;

namespace RestAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 100 },
            new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 200 },
            new Product { Id = Guid.NewGuid(), Name = "Product 3", Price = 300 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(ProductVM productVM)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productVM.Name,
                Price = productVM.Price
            };
            products.Add(product);
            return Ok(new
            {
                success = true,
                product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, ProductVM productEdit)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = productEdit.Name;
                product.Price = productEdit.Price;
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                products.Remove(product);
                return Ok(new
                {
                    success = true
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

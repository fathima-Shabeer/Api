using Microsoft.AspNetCore.Mvc;
using PracticeApi.Models;

namespace PracticeApi.Controllers;

[ApiController]                 // enables automatic validation + JSON binding
[Route("api/[controller]")]     // URL becomes: /api/products
public class ProductsController : ControllerBase
{
    // In-memory list acting as a fake database.
    // static = shared across requests. Resets when the app restarts.
    private static readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Gold Ring",  Price = 1500 },
        new Product { Id = 2, Name = "Gold Chain", Price = 3200 }
    };

    // GET /api/products  -> read all
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_products);                       // 200 OK + JSON list
    }

    // GET /api/products/1  -> read one
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();     // 404
        return Ok(product);
    }

    // POST /api/products  -> create (data comes from the request body)
    [HttpPost]
    public ActionResult<Product> Create(Product newProduct)
    {
        newProduct.Id = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1;
        _products.Add(newProduct);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct); // 201
    }

    // PUT /api/products/1  -> update
    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updated)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();

        product.Name = updated.Name;
        product.Price = updated.Price;
        return NoContent();                         // 204 (success, no body)
    }

    // DELETE /api/products/1  -> delete
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();

        _products.Remove(product);
        return NoContent();
    }
}

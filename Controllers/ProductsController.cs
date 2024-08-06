using APITest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITest.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductContext _context;

    public ProductsController(ProductContext context)
    {
        _context = context;
    }

    //get all products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        try
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return Ok(products);
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при получении списка продуктов!");
        }
    }

    //add product
    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Created($"api/products/{product.Id}", product);
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при добавлении продукта!");
        }
    }

    //remove product
    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound("Продукт не найден!");

        try
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при удалении продукта!");
        }
    }

    //update price of a product
    [HttpPut("{id}/price")]
    public async Task<ActionResult> UpdateProductPrice(int id, [FromBody] double newPrice)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound("Продукт не найден!");

        try
        {
            product.Price = newPrice;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при обновлении цены продукта!");
        }
    }

    //get sorted products by asc or desc
    [HttpGet("sorted")]
    public async Task<ActionResult<IEnumerable<Product>>> GetSortedProducts(string sortOrder)
    {
        if (string.IsNullOrEmpty(sortOrder) || (sortOrder != "asc" && sortOrder != "desc"))
            return BadRequest("Неверный параметр сортировки! Должно быть 'asc' или 'desc'!");

        try
        {
            var products = sortOrder == "asc"
                ? await _context.Products.OrderBy(p => p.Price).Include(p => p.Category).ToListAsync()
                : await _context.Products.OrderByDescending(p => p.Price).Include(p => p.Category).ToListAsync();

            return Ok(products);
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при получении отсортированного списка продуктов!");
        }
    }

    //delete many products by ids
    [HttpDelete("delete-many")]
    public async Task<ActionResult> DeleteManyProducts([FromBody] int[] ids)
    {
        if (ids.Length == 0) return BadRequest("Список идентификаторов продуктов пуст");

        try
        {
            var products = await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при удалении продуктов!");
        }
    }

    //get ONE product by special work in product's description
    [HttpGet("search")]
    public async Task<ActionResult<Product>> GetProductByDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description)) return BadRequest("Описание продукта не указано!");

        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Description.Contains(description));
            if (product == null) return NotFound("Продукт с таким описанием не найден!");
            return Ok(product);
        }
        catch (Exception)
        {
            return StatusCode(500, "Произошла ошибка при поиске продукта по описанию!");
        }
    }
}
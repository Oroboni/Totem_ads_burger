using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class LancheController : Controller
{

    private readonly ApplicationDbContext _context;

    public LancheController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var category = await _context.Products
            .Include(p => p.Compositions)
            .ToListAsync();
        return View(category);
    }

    [HttpGet]
    public IActionResult Create()
    {

        var categoriasFilho = _context.Categories
        .Where(c => c.ParentCategoryId != null)
        .ToList();

        ViewBag.ChildCategories = categoriasFilho;

        ViewBag.ChildCategories = _context.Categories
            .Where(c => c.ParentCategoryId != null)
            .ToList();

        ViewBag.Ingredients = _context.Ingredients.ToList();
        return View(new Product());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var product = await _context.Products
            .Include(p => p.Compositions)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        ViewBag.ChildCategories = _context.Categories
            .Where(c => c.ParentCategoryId != null)
            .ToList();

        ViewBag.Ingredients = _context.Ingredients.ToList();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Product product, List<Composition> Compositions)
    {
        var productDb = await _context.Products
            .Include(p => p.Compositions)
            .FirstOrDefaultAsync(p => p.Id == product.Id);

        if (productDb == null)
            return NotFound();

        productDb.Name = product.Name;
        productDb.Description = product.Description;
        productDb.Price = product.Price;
        productDb.Foto = product.Foto;
        productDb.CategoryId = product.CategoryId;

        if (productDb.Compositions != null)
        {
            _context.Compositions.RemoveRange(productDb.Compositions);
        }

        foreach (var comp in Compositions)
        {
            if (Request.Form[$"Compositions[{Compositions.IndexOf(comp)}].IsSelected"] == "true")
            {
                comp.ProductId = product.Id;
                comp.MaxQuantity = comp.MaxQuantity;
                _context.Compositions.Add(comp);
            }
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return NotFound();
        var compositions = await _context.Compositions
            .Where(c => c.ProductId == id)
            .ToListAsync();
        _context.Products.Remove(product);
        _context.Compositions.RemoveRange(compositions);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

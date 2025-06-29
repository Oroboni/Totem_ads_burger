using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class CategoryController : Controller
{

    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var category = await _context.Categories
            .Include(c => c.Subcategories)
            .ToListAsync();
        return View(category);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var categoriasPai = _context.Categories
        .Where(c => c.ParentCategoryId == null)
        .ToList();

        ViewBag.ParentCategories = categoriasPai;

        return View(new Category { Name = string.Empty });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var categoriasPai = _context.Categories
        .Where(c => c.ParentCategoryId == null)
        .ToList();

        ViewBag.ParentCategories = categoriasPai;

        var Categories = await _context.Categories.FindAsync(id);
        if (Categories == null)
        {
            return NotFound();
        }
        return View(Categories);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Category category)
    {
        var categoryDb = await _context.Categories.FindAsync(category.Id);
        if (categoryDb == null)
        {
            return NotFound();
        }

        categoryDb.Name = category.Name;
        categoryDb.ParentCategoryId = category.ParentCategoryId;

        _context.Update(categoryDb);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var ingredient = await _context.Categories.FindAsync(id);
        if (ingredient == null) return NotFound();

        _context.Categories.Remove(ingredient);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

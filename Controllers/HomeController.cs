using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Pedido")]
    [HttpGet("Pedido/{categorySlug}")]
    [HttpGet("Pedido/{categorySlug}/{subcategorySlug?}")]
    public async Task<IActionResult> Pedido(string? categorySlug, string? subcategorySlug)
    {
        var rootCategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == null)
            .ToListAsync();

        string? activeCategorySlug = null;
        int? activeCategoryId = null;

        if (!string.IsNullOrEmpty(categorySlug))
        {
            var activeCategory = rootCategoriesRaw.FirstOrDefault(c => c.Slug == categorySlug);
            if (activeCategory != null)
            {
                activeCategorySlug = activeCategory.Slug;
                activeCategoryId = activeCategory.Id;
            }
        }

        if (activeCategoryId == null && rootCategoriesRaw.Count > 0)
        {
            var first = rootCategoriesRaw.First();
            activeCategorySlug = first.Slug;
            activeCategoryId = first.Id;
        }

        if (activeCategoryId == null)
            return NotFound();

        var rootCategories = rootCategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                Slug = c.Slug,
                active = c.Id == activeCategoryId
            })
            .ToList();

        var subcategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == activeCategoryId)
            .ToListAsync();

        int? activeSubcategoryId = null;
        if (!string.IsNullOrEmpty(subcategorySlug)) // Se tiver slug de subcategoria, ele procurará a subcategoria correspondente e deixa seu ID como "active"
        {
            var activeSubcategory = subcategoriesRaw.FirstOrDefault(s => s.Slug == subcategorySlug);
            if (activeSubcategory != null)
                activeSubcategoryId = activeSubcategory.Id;
        }
        else if (subcategoriesRaw.Any())
        {
            activeSubcategoryId = subcategoriesRaw.First().Id;
        }

        var subcategories = subcategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                Slug = c.Slug,
                active = c.Id == activeSubcategoryId
            })
            .ToList();

        List<object> products;
        bool hasSubcategories = subcategoriesRaw.Any();

        if (hasSubcategories)
        {
            if (activeSubcategoryId.HasValue)
            {
                products = await _context.Products
                    .Where(p => p.CategoryId == activeSubcategoryId)
                    .Select(p => new
                    {
                        id = p.Id,
                        name = p.Name,
                        description = p.Description,
                        price = p.Price
                    })
                    .ToListAsync<object>();
            }
            else
            {
                var subcategoryIds = subcategoriesRaw.Select(s => s.Id).ToList();
                products = await _context.Products
                    .Where(p => subcategoryIds.Contains(p.CategoryId))
                    .Select(p => new
                    {
                        id = p.Id,
                        name = p.Name,
                        description = p.Description,
                        price = p.Price
                    })
                    .ToListAsync<object>();
            }
        }
        else
        {
            products = await _context.Products
                .Where(p => p.CategoryId == activeCategoryId)
                .Select(p => new
                {
                    id = p.Id,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price
                })
                .ToListAsync<object>();
        }

        ViewBag.CategorySlug = activeCategorySlug;
        ViewBag.Categories = rootCategories;
        ViewBag.SubCategories = subcategories;
        ViewBag.Products = products;

        return View();
    }


    public IActionResult Carrinho()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

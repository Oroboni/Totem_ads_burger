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
    
    public IActionResult LoginCliente()
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

        if (string.IsNullOrEmpty(categorySlug))
        {
            var firstCategory = rootCategoriesRaw.FirstOrDefault();
            if (firstCategory != null)
            {
                var firstSubcategory = await _context.Categories
                    .Where(c => c.ParentCategoryId == firstCategory.Id)
                    .OrderBy(c => c.Id)
                    .FirstOrDefaultAsync();

                if (firstSubcategory != null)
                {
                    return RedirectToAction("Pedido", new { categorySlug = firstCategory.Slug, subcategorySlug = firstSubcategory.Slug });
                }

                return RedirectToAction("Pedido", new { categorySlug = firstCategory.Slug });
            }

            return NotFound();
        }

        int? activeCategoryId = null;
        var activeCategory = rootCategoriesRaw.FirstOrDefault(c => c.Slug == categorySlug);
        if (activeCategory != null)
        {
            activeCategoryId = activeCategory.Id;
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
        if (!string.IsNullOrEmpty(subcategorySlug))
        {
            var activeSubcategory = subcategoriesRaw.FirstOrDefault(s => s.Slug == subcategorySlug);
            if (activeSubcategory != null)
                activeSubcategoryId = activeSubcategory.Id;
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
        List<object> items;

        if (hasSubcategories)
        {
            if (activeSubcategoryId.HasValue)
            {
                bool isComboCategory = false;

                if (activeCategoryId == 2)
                {
                    isComboCategory = true;
                }
                else
                {
                    var subcategory = await _context.Categories.FindAsync(activeSubcategoryId.Value);
                    if (subcategory?.ParentCategoryId == 2)
                    {
                        isComboCategory = true;
                    }
                }

                if (isComboCategory)
                {
                    var comboQuery = _context.Combos.AsQueryable();
                    comboQuery = comboQuery.Where(c => c.CategoryId == activeSubcategoryId.Value);

                    items = await comboQuery
                        .Select(c => new
                        {
                            id = c.Id,
                            name = c.Name,
                            description = c.Description,
                            Foto = c.Foto,
                            price = c.Price,
                            isCombo = true
                        }).ToListAsync<object>();

                    ViewBag.Products = items;
                }
                else
                {
                    products = await _context.Products
                        .Where(p => p.CategoryId == activeSubcategoryId)
                        .Select(p => new
                        {
                            id = p.Id,
                            name = p.Name,
                            description = p.Description,
                            Foto = p.Foto,
                            price = p.Price
                        })
                        .ToListAsync<object>();

                    ViewBag.Products = products;
                }
            }
            else
            {
                bool isComboCategory = false;

                if (activeCategoryId == 2)
                {
                    isComboCategory = true;
                }
                else if (subcategoriesRaw.Any(s => s.ParentCategoryId == 2))
                {
                    isComboCategory = true;
                }

                if (isComboCategory)
                {
                    var subcategoryIds = subcategoriesRaw.Select(s => s.Id).ToList();
                    var comboQuery = _context.Combos.AsQueryable();
                    comboQuery = comboQuery.Where(c => subcategoryIds.Contains(c.CategoryId));

                    items = await comboQuery
                        .Select(c => new
                        {
                            id = c.Id,
                            name = c.Name,
                            description = c.Description,
                            Foto = c.Foto,
                            price = c.Price,
                            isCombo = true
                        }).ToListAsync<object>();

                    ViewBag.Products = items;
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
                            Foto = p.Foto,
                            price = p.Price
                        })
                        .ToListAsync<object>();

                    ViewBag.Products = products;
                }
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
                    Foto = p.Foto,
                    price = p.Price
                })
                .ToListAsync<object>();

            ViewBag.Products = products;
        }

        ViewBag.CategorySlug = categorySlug;
        ViewBag.Categories = rootCategories;
        ViewBag.SubCategories = subcategories;

        return View();
    }

    public IActionResult Editar()
    {
        return View();
    }
    public IActionResult Escolherlocal()
    {
        return View();
    }
    public IActionResult CPFnaNota()
    {

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

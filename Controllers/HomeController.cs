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
    
    [HttpGet("Pedido/{categoryId:int?}/{subcategoryId:int?}")]
    public async Task<IActionResult> Pedido(int? categoryId, int? subcategoryId)
    {
        // Busca categorias raiz (sem categoria pai)
        var rootCategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == null)
            .ToListAsync();

        // Se não houver categoryId fornecido, usa o primeiro como ativo
        var activeCategoryId = categoryId ?? rootCategoriesRaw.FirstOrDefault()?.Id;

        // Mapeia as categorias raiz para um formato com indicação de qual está ativa
        var rootCategories = rootCategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                active = c.Id == activeCategoryId
            })
            .ToList();

        // Busca subcategorias da categoria ativa
        var subcategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == activeCategoryId)
            .ToListAsync();

        // Determina subcategoria ativa, se existir
        var activeSubcategoryId = subcategoriesRaw.Any(c => c.Id == subcategoryId)
            ? subcategoryId
            : subcategoriesRaw.FirstOrDefault()?.Id;

        // Mapeia subcategorias com marcação de qual está ativa
        var subcategories = subcategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                active = c.Id == activeSubcategoryId
            })
            .ToList();

        // Busca produtos da subcategoria ativa
        var products = await _context.Products
            .Where(p => p.CategoryId == activeSubcategoryId)
            .Select(p => new
            {
                id = p.Id,
                name = p.Name,
                price = p.Price
            })
            .ToListAsync();

        // Envia dados para a View via ViewBag (dinâmico)
        ViewBag.Category = categoryId;
        ViewBag.Categories = rootCategories;
        ViewBag.SubCategories = subcategories;
        ViewBag.Products = products;

        // Retorna a view associada ao método Menu
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

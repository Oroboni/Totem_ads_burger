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
        if (!categoryId.HasValue && rootCategoriesRaw.Count == 0)
            return NotFound(); // ou algum fallback

        var activeCategoryId = categoryId ?? rootCategoriesRaw.First().Id;


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
        List<object> products;

        bool hasSubcategories = subcategoriesRaw.Any();

        if (hasSubcategories)
        {
            if (subcategoryId.HasValue)
            {
                // Se subcategoria ativa foi especificada e é válida
                products = await _context.Products
                    .Where(p => p.CategoryId == subcategoryId)
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
                // Nenhuma subcategoria selecionada → mostra produtos de todas as subcategorias
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
            // Categoria raiz sem subcategorias → mostra produtos diretos dela
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



        // Envia dados para a View via ViewBag (dinâmico)
        ViewBag.Category = activeCategoryId;
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

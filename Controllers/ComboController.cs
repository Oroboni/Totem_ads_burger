using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TotemPWA.Controllers;

public class ComboController : Controller
{

    private readonly ApplicationDbContext _context;

    public ComboController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var Combo = await _context.Combos
            .Include(c => c.ComboProducts)
            .ThenInclude(cp => cp.Product)
            .ThenInclude(p => p.Compositions)
            .ToListAsync();
        return View(Combo);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Products = new SelectList(_context.Products, "Id", "Name");
        var categories = _context.Categories.Where(c => c.ParentCategoryId == 2).ToList();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");

        return View(new ComboFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Create")]
    public async Task<IActionResult> Create(ComboFormViewModel model)
    {
        _context.Combos.Add(model.Combo);
        await _context.SaveChangesAsync();

        foreach (var productId in model.SelectedProductIds)
        {
            _context.ComboProducts.Add(new ComboProduct
            {
                ComboId = model.Combo.Id,
                ProductId = productId
            });
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }



    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var combo = await _context.Combos
            .Include(c => c.ComboProducts)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (combo == null) return NotFound();

        var vm = new ComboFormViewModel
        {
            Combo = combo,
            SelectedProductIds = combo.ComboProducts.Select(cp => cp.ProductId).ToList()
        };

        ViewBag.Products = new MultiSelectList(_context.Products, "Id", "Name", vm.SelectedProductIds);
        var categories = await _context.Categories.Where(c => c.ParentCategoryId == 2).ToListAsync();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");

        return View(vm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Editar")]
    public async Task<IActionResult> Editar(ComboFormViewModel model)
    {
        var combo = await _context.Combos
            .Include(c => c.ComboProducts)
            .FirstOrDefaultAsync(c => c.Id == model.Combo.Id);

        if (combo == null) return NotFound();

        combo.Name = model.Combo.Name;
        combo.Description = model.Combo.Description;
        combo.Foto = model.Combo.Foto;
        combo.Price = model.Combo.Price;
        combo.CategoryId = model.Combo.CategoryId;

        combo.ComboProducts.Clear();
        foreach (var productId in model.SelectedProductIds)
        {
            combo.ComboProducts.Add(new ComboProduct
            {
                ProductId = productId,
                ComboId = combo.Id
            });
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var Combos = await _context.Combos.FindAsync(id);
        if (Combos == null) return NotFound();

        _context.Combos.Remove(Combos);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

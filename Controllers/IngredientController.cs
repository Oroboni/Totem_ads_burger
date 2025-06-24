using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class IngredientController : Controller
{

    private readonly ApplicationDbContext _context;

    public IngredientController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var ingredientes = await _context.Ingredients.ToListAsync();

        return View(ingredientes);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Ingredient());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ingredient ingredient)
    {
        if (!ModelState.IsValid)
        {
            return View(ingredient);
        }

        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Editar(int id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ingredient = await _context.Ingredients.FindAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return View(ingredient);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Ingredient ingredient)
    {
        if (!ModelState.IsValid)
        {
            return View(ingredient);
        }

        var ingredientDb = await _context.Ingredients.FindAsync(ingredient.Id);
        if (ingredientDb == null)
        {
            return NotFound();
        }

        ingredientDb.Name = ingredient.Name;
        ingredientDb.AdditionalPrice = ingredient.AdditionalPrice;
        ingredientDb.Foto = ingredient.Foto;

        _context.Update(ingredientDb);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);
        if (ingredient == null) return NotFound();

        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

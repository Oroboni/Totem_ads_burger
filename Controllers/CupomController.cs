using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class CupomController : Controller
{
    private readonly ApplicationDbContext _context;

    public CupomController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var cupons = await _context.Cupons.ToListAsync();
        return View(cupons);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new Cupom { Codigo = string.Empty, Desconto = 0, Type = CupomType.ValorFixo });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cupom cupom)
    {
        if (!ModelState.IsValid)
            return View(cupom);

        _context.Cupons.Add(cupom);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Editar(string codigo)
    {
        if (codigo == null)
            return NotFound();

        var cupom = await _context.Cupons.FindAsync(codigo);
        if (cupom == null)
        {
            return NotFound();
        }
        return View(cupom);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Cupom cupom)
    {
        var cupomDb = await _context.Cupons.FindAsync(cupom.Codigo);
        if (cupomDb == null)
        {
            return NotFound();
        }

        cupomDb.Desconto = cupom.Desconto;

        _context.Update(cupomDb);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string codigo)
    {
        var cupom = await _context.Cupons.FindAsync(codigo);
        if (cupom == null) return NotFound();

        _context.Cupons.Remove(cupom);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
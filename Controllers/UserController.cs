using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers;

public class UserController : Controller
{

    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var usuarios = await _context.Users.ToListAsync();
        var Login = HttpContext.Session.GetString("UserId");

        return View(usuarios);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new User());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        // Verifica se já existe um usuário com o mesmo login
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Login == user.Login);

        if (existingUser != null)
        {
            ModelState.AddModelError("Login", "Já existe um usuário com este login.");
            return View(user);
        }
        else
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

    public async Task<IActionResult> Editar(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var userDb = await _context.Users.FindAsync(user.Id);
        if (userDb == null)
        {
            return NotFound();
        }

        userDb.Login = user.Login;
        userDb.Senha = user.Senha;

        _context.Update(userDb);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using System.Diagnostics;
using CrudDotNet8.Datos;
using Microsoft.AspNetCore.Mvc;
using CrudDotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudDotNet8.Controllers;

public class InicioController : Controller
{
    private readonly ApplicationDbContext _context;

    public InicioController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Contacto.ToListAsync());
    }
    
    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Contacto contacto)
    {   
        
        if (!ModelState.IsValid) return View();
        
        contacto.FechaCreacion = DateTime.UtcNow;
        
        _context.Contacto.Add(contacto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Editar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Contacto contactoBuscado = _context.Contacto.Find(id);

        if (contactoBuscado == null)
        {
            return NotFound();
        }
        
        return View(contactoBuscado);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Contacto contacto)
    {   
        if (!ModelState.IsValid) return View();

        if (contacto.FechaCreacion.Kind == DateTimeKind.Unspecified)
        {
            contacto.FechaCreacion = DateTime.SpecifyKind(contacto.FechaCreacion, DateTimeKind.Utc);
        }
        
        _context.Contacto.Update(contacto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Detalle(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Contacto contactoBuscado = _context.Contacto.Find(id);

        if (contactoBuscado == null)
        {
            return NotFound();
        }
        
        return View(contactoBuscado);
    }
    
    [HttpGet]
    public IActionResult Borrar(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Contacto contactoBuscado = _context.Contacto.Find(id);

        if (contactoBuscado == null)
        {
            return NotFound();
        }
        
        return View(contactoBuscado);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Borrar(Contacto contacto)
    {
        _context.Contacto.Remove(contacto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
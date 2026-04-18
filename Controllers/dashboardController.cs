using Microsoft.EntityFrameworkCore;
using riwiwi.data;
using riwiwi.Models;
using Microsoft.AspNetCore.Mvc;

namespace riwiwi.Controllers;

public class dashboardController : Controller
{
    private readonly MysqlDbContext _context;

    public dashboardController(MysqlDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var dash = _context.dashboard.ToList();
        return View(dash);
    }

    [HttpGet]
    public IActionResult newferia()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Store(dashboard events)
    {
        _context.dashboard.Add(events);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var evento = _context.dashboard.Find(id);
        if (evento == null) return NotFound();
        return View(evento);
    }

    [HttpPost]
    public IActionResult Update(dashboard events)
    {
        _context.dashboard.Update(events);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var evento = _context.dashboard.Find(id);
        if (evento == null) return NotFound();
        return View(evento);
    }

    [HttpPost]
    public IActionResult Destroy(int id)
    {
        var evento = _context.dashboard.Find(id);
        if (evento == null) return NotFound();
        _context.dashboard.Remove(evento);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
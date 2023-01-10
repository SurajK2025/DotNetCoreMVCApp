using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeepNotesWebApp.Models;

namespace KeepNotesWebApp.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Validate(string username, string password)
    {
        //Validate from database.
        Console.WriteLine($"User logged in {username} {password}");
        return RedirectToAction("Notes", "Notes", new { username = $"{username}" });
    }

    public IActionResult Saveuser(string name, string username, string password)
    {
        //Register user to database.
        Console.WriteLine($"User registered: {name} {username} {password}");
        return RedirectToAction("Index", "Home", new { username = $"{username}" });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

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
        //Not working check why??
        ViewData["currentUser"]=$"{username}";
        return RedirectToAction("Notes", "Notes");
    }

    public IActionResult Saveuser(string name, string username, string password)
    {
        //Register user to database.
        Console.WriteLine($"User registered: {name} {username} {password}");
        //Not working check why??
        ViewData["currentUser"]=$"{username}";
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

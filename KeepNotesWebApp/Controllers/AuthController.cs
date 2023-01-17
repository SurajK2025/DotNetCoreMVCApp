using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeepNotesWebApp.Models;
using DAL;

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
        HttpContext.Session.Clear();
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Validate(User user)
    {
        User validUser = KeepNotesDBConnectorApi.GetUserByUsername(user.Username);
        if(validUser.Password == user.Password){
            HttpContext.Session.SetString("username", validUser.Username);
            HttpContext.Session.SetString("userid", validUser.Userid.ToString());
            return RedirectToAction("AllNotes", "Notes");
        }
        Console.WriteLine("Invalid User");
        return Redirect("Login");
    }

    public IActionResult Saveuser(User user)
    {
        KeepNotesDBConnectorApi.RegisterNewUser(user);
        return Redirect("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

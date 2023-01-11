using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeepNotesWebApp.Models;

namespace KeepNotesWebApp.Controllers;

public class NotesController : Controller
{
    private readonly ILogger<NotesController> _logger;

    public NotesController(ILogger<NotesController> logger)
    {
        _logger = logger;
    }

    public IActionResult AllNotes(string username)
    {
        ViewData["currentUser"]=$"{username}";
        return View();
    }

    public IActionResult UpdateNote()
    {
        return View();
    }

    public IActionResult AddNote()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

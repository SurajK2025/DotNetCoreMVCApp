using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KeepNotesWebApp.Models;
using DAL;

namespace KeepNotesWebApp.Controllers;

public class NotesController : Controller
{
    private readonly ILogger<NotesController> _logger;

    public NotesController(ILogger<NotesController> logger)
    {
        _logger = logger;
    }

    public IActionResult AllNotes()
    {
        List<Note> notes = KeepNotesDBConnectorApi.GetAllNotes();
        ViewData["noteslist"] = notes;
        return View();
    }

    public IActionResult UpdateNote(int id)
    {
        Note note = KeepNotesDBConnectorApi.GetNoteByNoteId(id);
        ViewData["note"] = note;
        return View();
    }

    public IActionResult SaveUpdatedNote(string title, string description)
    {
        Console.WriteLine($"{title} {description}");
        return Redirect("AllNotes");
    }

    public IActionResult AddNote()
    {
        return View();
    }

    public IActionResult SaveNewNote(string title, string description)
    {
        Console.WriteLine($"{title} {description}");
        return Redirect("AllNotes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

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
        int userid = Convert.ToInt32(HttpContext.Session.GetString("userid"));
        List<Note> notes = KeepNotesDBConnectorApi.GetAllNotesByUserId(userid);
        ViewData["noteslist"] = notes;
        return View();
    }

    public IActionResult UpdateNote(int id)
    {
        HttpContext.Session.SetString("updateNoteid", id.ToString());
        Note note = KeepNotesDBConnectorApi.GetNoteByNoteId(id);
        ViewData["note"] = note;
        return View();
    }

    public IActionResult SaveUpdatedNote(Note note)
    {
        Console.WriteLine(note.ToString());
        note.Noteid = Convert.ToInt32(HttpContext.Session.GetString("updateNoteid"));
        KeepNotesDBConnectorApi.UpdateNoteNyNoteId(note);
        return Redirect("AllNotes");
    }

    public IActionResult AddNote()
    {
        return View();
    }

    public IActionResult SaveNewNote(Note note)
    {
        int userid = Convert.ToInt32(HttpContext.Session.GetString("userid"));
        KeepNotesDBConnectorApi.InsertNewNote(note, userid);
        return Redirect("AllNotes");
    }

    public IActionResult DeleteNote(int noteid)
    {
        KeepNotesDBConnectorApi.DeleteNote(noteid);
        return RedirectToAction("AllNotes", "Notes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

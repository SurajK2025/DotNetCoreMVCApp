namespace KeepNotesWebApp.Models;

public class User {
    public int userid{get;set;}
    public string name{get;set;}
    public string username{get;set;}
    public string password{get;set;}

    public override string ToString()
    {
        return $"userid={userid} name={name} username={username} password={password}";
    }
}
namespace KeepNotesWebApp.Models;

public class User {
    public int Userid{get;set;}
    public string Name{get;set;}
    public string Username{get;set;}
    public string Password{get;set;}

    public override string ToString()
    {
        return $"userid={Userid} name={Name} username={Username} password={Password}";
    }
}
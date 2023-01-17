namespace DAL;
using System.Data;
using MySql.Data.MySqlClient;
using KeepNotesWebApp.Models;

public class KeepNotesDBConnectorApi
{
    public static string conString = @"server=localhost; port=3306; user=root; password=root; database=keepnotes";
    public static List<Note> GetAllNotes()
    {
        List<Note> allNotes = new List<Note>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = "select * from notes";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Note note = new Note
                {
                    Noteid = int.Parse(row["noteid"].ToString()),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    Date = row["createdDate"].ToString(),
                    Userid = int.Parse(row["userid"].ToString())
                };
                allNotes.Add(note);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }

    public static Note GetNoteByNoteId(int id)
    {
        Note note = null;
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "select * from notes where noteid=" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                note = new Note
                {
                    Noteid = int.Parse(reader["noteid"].ToString()),
                    Title = reader["title"].ToString(),
                    Description = reader["description"].ToString(),
                    Date = reader["createdDate"].ToString(),
                    Userid = int.Parse(reader["userid"].ToString())
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return note;
    }

    public static List<Note> GetAllNotesByUserId(int id){
        List<Note> allNotes = new List<Note>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            string query = $"select * from notes where userid={id}";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Note note = new Note
                {
                    Noteid = int.Parse(row["noteid"].ToString()),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    Date = row["createdDate"].ToString(),
                    Userid = int.Parse(row["userid"].ToString())
                };
                allNotes.Add(note);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allNotes;
    }

    public static User GetUserByUsername(string username){
        User user = null;
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"select * from users where username='{username}'";
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    Userid = int.Parse(reader["userid"].ToString()),
                    Name = reader["name"].ToString(),
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString()  
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return user;
    }

    public static void RegisterNewUser(User user){
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"insert into users(name, username, password) values('{user.Name}', '{user.Username}', '{user.Password}')";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void UpdateNoteNyNoteId(Note note){
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"update notes set title='{note.Title}', description='{note.Description}', createdDate=Curdate() where noteid=" + note.Noteid;
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteReader();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void InsertNewNote(Note note, int userid){
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"insert into notes(title, description, createddate, userid) values('{note.Title}', '{note.Description}', Curdate(), {userid})";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeleteNote(int noteid){
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"delete from notes where noteid={noteid}";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }
}
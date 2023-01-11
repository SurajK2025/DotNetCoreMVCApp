namespace DAL.DisConnected;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

class KeepNotesDBConnector{
    public static string conString=@"server=localhost;port=3306;user=root;password=root123;database=keepnotes";       
    public  static List<Note> GetAllNotesByUserId(){
        List<Note> allNotes = new List<Note>();
        MySqlConnection con=new MySqlConnection(conString);

        try{
            DataSet ds=new DataSet();

            string query="SELECT * FROM notes";
            MySqlCommand cmd=new MySqlCommand(query, con);
            MySqlDataAdapter da=new MySqlDataAdapter(cmd);

            da.Fill(ds);
    
            DataTable dt=ds.Tables[0];
            DataRowCollection rows=dt.Rows;
            foreach( DataRow row in rows)
            {
                int id = int.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                string location = row["location"].ToString();
                Note dept=new Note{
                                                Id = id,
                                                Name = name,
                                                Location = location
                };
                allNotes.Add(dept);
            }
        }
        catch(Exception ee){
                Console.WriteLine(ee.Message);
        }
        return allNotes;
    }
}
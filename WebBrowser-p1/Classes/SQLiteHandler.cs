using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser_p1.Classes
{
    internal class SQLiteHandler
    {

        public static SQLiteConnection ConnectToDb()
        {
            SQLiteConnection conn = null;
            conn = new SQLiteConnection("Data Source=webBrowserDB.sqlite; Version=3;");

            try
            {
                conn.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Close();
            }
            return conn;
        }

        public static void DisconnectFromDb(SQLiteConnection conn)
        {
            if(conn != null && conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public static void InsertKeyword(SQLiteConnection conn, string keyword)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO keywords (keyword) " + $"VALUES('{keyword}')";

            cmd.ExecuteNonQuery();
        }
        
        public static List<string> GetAllKeywords(SQLiteConnection conn)
        {
            List<string> keywords = new List<string>();

            SQLiteDataReader reader = null;
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT keyword FROM keywords";

            reader = cmd.ExecuteReader();

            while (reader.Read()) {
                keywords.Add(reader.GetString(0));
            }

            return keywords;
        }

    }
}

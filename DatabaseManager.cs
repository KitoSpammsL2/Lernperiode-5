using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TheFinalChess
{
    public class DatabaseManager
    {
        private readonly string connectionString;

        public DatabaseManager(string connStr)
        {
            connectionString = connStr;
        }

        public void SaveGame(List<Button> buttons)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand delete = new SqlCommand("DELETE FROM ChessBoardState", conn);
            delete.ExecuteNonQuery();

            foreach (var button in buttons)
            {
                if (!button.Name.StartsWith("btn")) continue;
                string feld = button.Name.Substring(3); // btnA1 => A1
                string inhalt = button.Tag?.ToString() ?? "";

                SqlCommand insert = new SqlCommand("INSERT INTO ChessBoardState (Feld, Inhalt) VALUES (@Feld, @Inhalt)", conn);
                insert.Parameters.AddWithValue("@Feld", feld);
                insert.Parameters.AddWithValue("@Inhalt", inhalt);
                insert.ExecuteNonQuery();
            }
        }

        public Dictionary<string, string> LoadGame()
        {
            Dictionary<string, string> boardState = new();

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT Feld, Inhalt FROM ChessBoardState", connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string field = reader["Feld"].ToString();
                    string content = reader["Inhalt"].ToString();
                    boardState[field] = content;
                }
            }


            return boardState;
        }
    }
}

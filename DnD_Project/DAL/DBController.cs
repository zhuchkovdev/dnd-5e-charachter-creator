using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.Json;
using System.Data.SQLite;
using DnD_Project.CharacterModule;


namespace DnD_Project.DAL
{
    public class DBController
    {
        string connectionString;
        public DBController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateUser(User user)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Users (Login, Password) VALUES (@login, @pass)";
                var command = new SQLiteCommand(sqlExpression, connection);
                var loginParam = new SQLiteParameter("@login", user.Login);
                var passParam = new SQLiteParameter("@pass", user.Password);
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passParam);
                command.ExecuteNonQuery();
            }
        }
        
        public int? GetUserID(User user)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Users WHERE Login=@login AND Password=@pass";
                var command = new SQLiteCommand(sqlExpression, connection);
                var loginParam = new SQLiteParameter("@login", user.Login);
                var passParam = new SQLiteParameter("@pass", user.Password);
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    int userID = reader.GetInt32(0);
                    reader.Close();
                    return userID;
                }
                else return null;

            }
        }

        public bool UserExists(User user)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Users WHERE Login=@login AND Password=@pass";
                var command = new SQLiteCommand(sqlExpression, connection);
                var loginParam = new SQLiteParameter("@login", user.Login);
                var passParam = new SQLiteParameter("@pass", user.Password);
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passParam);

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else return false;

            }
        }

        public void CreateBlankCharacter(User user, string characterName, out int charID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var command = connection.CreateCommand();
                command.Transaction = transaction;

                command.CommandText = String.Format("INSERT INTO Characters (Name) VALUES ('{0}')", characterName);
                command.ExecuteNonQuery();

                command.CommandText = "SELECT MAX(ID) FROM Characters AS MaxID";
                var reader = command.ExecuteReader();
                reader.Read();
                charID = reader.GetInt32(0);
                reader.Close();

                command.CommandText = "INSERT INTO UserChars (UserID, CharID) VALUES (@userId, @charId)";
                command.Parameters.AddWithValue("@userId", user.ID);
                command.Parameters.AddWithValue("@charId", charID);
                command.ExecuteNonQuery();

                transaction.Commit();
            }
        }

        public List<int> GetCharactersList(User user)
        {
            var charIDs = new List<int>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM UserChars WHERE UserID=@user_id";
                var userParam = new SQLiteParameter("@user_id", user.ID);
                var command = new SQLiteCommand(sqlExpression, connection);
                command.Parameters.Add(userParam);

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        charIDs.Add(reader.GetInt32(1));
                    }
                }
                reader.Close();

                return charIDs;
            }
        }

        internal void DeleteCharacter(Character character)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "DELETE FROM Characters WHERE ID=@id";
                var command = new SQLiteCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", character.ID);
                command.ExecuteNonQuery();

                sqlExpression = "DELETE FROM UserChars WHERE CharID=@id";
                command = new SQLiteCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", character.ID);
                command.ExecuteNonQuery();
            }
        }

        public string GetCharacterName(int charID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT Name FROM Characters WHERE ID=@id";
                var command = new SQLiteCommand(sqlExpression, connection);
                var idParam = new SQLiteParameter("@id", charID);
                command.Parameters.Add(idParam);

                var reader = command.ExecuteReader();
                reader.Read();
                string name = reader.GetString(0);
                reader.Close();
                return name;
            }
        }

        public Character GetCharacter(int charID)
        {
            string jsonData;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Characters WHERE ID=@id";
                var command = new SQLiteCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", charID);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    jsonData = Convert.ToString(reader["CharacterData"]);
                    reader.Close();
                }
            }

            CharacterData restoredData = JsonSerializer.Deserialize<CharacterData>(jsonData);

            var character = new Character(restoredData);
            character.ID = charID;

            return character;
        }

        public void SaveCharacter(CharacterData data)
        {
            string jsonData = JsonSerializer.Serialize<CharacterData>(data);
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = String.Format("UPDATE Characters SET CharacterData = '{0}' WHERE ID = @id", jsonData);
                var command = new SQLiteCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", data.ID);
                command.ExecuteNonQuery();
            }
        }


    }
}

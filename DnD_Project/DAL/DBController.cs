using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DnD_Project.DAL
{
    class DBController
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
                    return reader.GetInt32(0);
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

        public void CreateBlankCharacter(User user, out int charID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Characters (Name) VALUES (NULL)";
                var command = new SQLiteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                sqlExpression = "SELECT * FROM Characters WHERE Name=NULL";
                command = new SQLiteCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                reader.Read();
                charID = reader.GetInt32(0);

                sqlExpression = "INSERT INTO UserChars (UserID, CharID) VALUES (@user_id, @char_id)";
                var loginParam = new SQLiteParameter("@user_id", user.ID);
                var passParam = new SQLiteParameter("@char_id", charID);
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passParam);

                command = new SQLiteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}

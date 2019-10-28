using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DnD_Project.DBResources
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
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Users (Login, Password) VALUES (@login, @pass)";
                var command = new SqlCommand(sqlExpression, connection);
                var loginParam = new SqlParameter("@login", user.Login);
                var passParam = new SqlParameter("@pass", user.Password);
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passParam);
                command.ExecuteNonQuery();
            }
        }
        
        public int? GetUserID(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Users WHERE Login=@login AND Password=@pass";
                var command = new SqlCommand(sqlExpression, connection);
                var loginParam = new SqlParameter("@login", user.Login);
                var passParam = new SqlParameter("@pass", user.Password);
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
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "SELECT * FROM Users WHERE Login=@login AND Password=@pass";
                var command = new SqlCommand(sqlExpression, connection);
                var loginParam = new SqlParameter("@login", user.Login);
                var passParam = new SqlParameter("@pass", user.Password);
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

        public void CreateBlankCharacter()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlExpression = "INSERT INTO Chars (Name) VALUES (NULL)";
                var command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}

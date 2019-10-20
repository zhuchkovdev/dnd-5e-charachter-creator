using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DnD_Project.Resources;

namespace DnD_Project
{
    class DBController
    {
        string connectionString;
        public DBController(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void CreateCharacter()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                var command = connection.CreateCommand();
                command.Transaction = transaction;

                command.CommandText = "INSERT INTO Chars (Name) VALUES (NULL)";
                //var param = new SqlParameter("@name", null);
                //command.Parameters.Add(param);
                command.ExecuteNonQuery();
                transaction.Commit();
            }     
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
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        public void SaveCharacter(Character character)
        {

        }
        public Character LoadCharacter(int charID)
        {
            return new Character();
        }
        
    }
}

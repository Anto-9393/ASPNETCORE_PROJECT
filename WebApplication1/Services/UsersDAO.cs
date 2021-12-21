using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UsersDAO
    {
        bool success = false;

        string connenctionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindCredentially(UserModel user)
        {
            // Ritorna true se ha trovato l'utente nel DB 
            string sqlStatement = "SELECT  * FROM  dbo.Users WHERE username = @username AND  password =@password";

            //Connessione database
            using (SqlConnection connection = new SqlConnection(connenctionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username" , System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if(reader.HasRows)
                    {
                        success = true;
                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine("Error : ", e.Message);
                }
            }

            return success;
        }
        }
    }
 

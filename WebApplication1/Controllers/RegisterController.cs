using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {

        string connenctionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;" +
           "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
           "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Register(UserModel user)

        {
            string sqlStatement = "INSERT  INTO  dbo.Users(username,password) VALUES(@username,@password)";

            //Connessione database
            using (SqlConnection connection = new SqlConnection(connenctionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("password", user.Password);

                connection.Open();
                int result = command.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");


            }
            return View("Registration");
        }
    }
}

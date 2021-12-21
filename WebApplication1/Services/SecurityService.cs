using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SecurityService
    {
        List<UserModel> knownUsers = new List<UserModel>();

        //Connection Db
        UsersDAO userDAO = new UsersDAO();

   
        public bool IsValid(UserModel user)
        {   //Verificare se l'utente si trova nella Lista
            return userDAO.FindCredentially(user);
        }











    }

   
}

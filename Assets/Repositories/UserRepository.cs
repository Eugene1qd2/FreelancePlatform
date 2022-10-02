using FreelancePlatform.Assets.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace FreelancePlatform.Assets.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credantial)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from users where Username=@username and Password=@password";
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credantial.UserName;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credantial.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

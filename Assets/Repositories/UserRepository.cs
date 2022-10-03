using FreelancePlatform.Assets.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FreelancePlatform.Assets.Additional_Data;


namespace FreelancePlatform.Assets.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public ErrorStatus Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from users where Username=@username;";
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
                if (command.ExecuteScalar() != null)
                {
                    return ErrorStatus.RegisteredUsernameError;
                }
                else
                {
                    command.CommandText = "select * from users where Email=@email;";
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = userModel.Email;
                    if (command.ExecuteScalar() != null)
                    {
                        return ErrorStatus.RegisteredEmailError;
                    }
                    else
                    {
                        try
                        {
                            NetworkCredential net = new NetworkCredential(userModel.Username, userModel.Password);
                            command.CommandText = "insert into users(Username,Password,Surname,Name,Middlename,Birthday,Email,Male) value(@username,@password,@surname,@name,@middlename,@birthday,@email,@male)";
                            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = net.Password;
                            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userModel.Surname;
                            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userModel.Name;
                            command.Parameters.Add("@middlename", MySqlDbType.VarChar).Value = userModel.Middlename;
                            command.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = userModel.Birthdate.ToString("yyyy-MM-dd");
                            command.Parameters.Add("@male", MySqlDbType.VarChar).Value = userModel.Male;
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            return ErrorStatus.RegistrationError;
                        }
                    }
                }
            }

            return ErrorStatus.NoError;
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

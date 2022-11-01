using FreelancePlatform.Assets.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FreelancePlatform.Assets.Additional_Data;
using System.Security;
using System.Drawing;
using System.IO;

namespace FreelancePlatform.Assets.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository()
        {
            using (System.IO.FileStream fs = new System.IO.FileStream("..\\..\\Assets\\Images\\Default.png", FileMode.Open))
            {
                defaultImage = new byte[fs.Length];
                fs.Read(defaultImage, 0, defaultImage.Length);
            }
        }
        public byte[] defaultImage;
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
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
                            command.CommandText = "insert into users(Username,Password,Surname,Name,Middlename,Birthday,Email,Male,Photo) value(@username,@password,@surname,@name,@middlename,@birthday,@email,@male,@photo)";
                            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = net.Password;
                            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userModel.Surname;
                            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userModel.Name;
                            command.Parameters.Add("@middlename", MySqlDbType.VarChar).Value = userModel.Middlename;
                            command.Parameters.Add("@birthday", MySqlDbType.VarChar).Value = userModel.Birthdate.ToString("yyyy-MM-dd");
                            command.Parameters.Add("@male", MySqlDbType.VarChar).Value = userModel.Male;
                            command.Parameters.Add("@photo", MySqlDbType.LongBlob).Value = userModel.Photo ?? defaultImage;
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
            UserModel user = new UserModel();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from users where Username=@username";
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    byte[] photo = reader.GetValue(11) as byte[];
                    user = new UserModel()
                    {
                        Surname = reader.GetString("Surname"),
                        Name = reader.GetString("Name"),
                        Middlename = reader.GetString("Middlename"),
                        Birthdate = DateTime.Parse(reader.GetString("Birthday")),
                        Email = reader.GetString("Email"),
                        Registrationdate = DateTime.Parse(reader.GetString("Registerdate")),
                        Male = reader.GetString("Male"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Id = int.Parse(reader.GetString("ID")),
                        Photo = photo,
                        Aboutme = reader.GetValue(10) as string
                    };
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangePhoto(UserModel userModel)
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "update users set Photo=@photo where Username=@username;";
                    command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
                    command.Parameters.Add("@photo", MySqlDbType.LongBlob).Value = userModel.Photo ?? defaultImage;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ChangeAboutMeByUsername(UserModel user)
        {
            using (var connection = GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "update users set Aboutme=@about where Username=@username;";
                    command.Parameters.Add("@username", MySqlDbType.VarChar).Value = user.Username;
                    command.Parameters.Add("@about", MySqlDbType.Text).Value = user.Aboutme;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

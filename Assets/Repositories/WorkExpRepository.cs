using FreelancePlatform.Assets.Additional_Data;
using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.MVVM.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.Repositories
{
    class WorkExpRepository : RepositoryBase,IWorkExpRepository
    {
        public ErrorStatus Add(WorkExpModel workExp, UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = "insert into workexps(ID_user,Company,Post,Duration) value(@id_user,@company,@post,@duration)";
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
                    command.Parameters.Add("@company", MySqlDbType.VarChar).Value = workExp.Company;
                    command.Parameters.Add("@post", MySqlDbType.VarChar).Value = workExp.Post;
                    command.Parameters.Add("@duration", MySqlDbType.VarChar).Value = workExp.Duration;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return ErrorStatus.RegistrationError;
                }
            }
            return ErrorStatus.NoError;
        }

        public void Edit(WorkExpModel workExp)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "update workexps set Company=@company,Post=@post,Duration=@duration where ID_workexp=@id;";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = workExp.Id;
                command.Parameters.Add("@company", MySqlDbType.VarChar).Value = workExp.Company;
                command.Parameters.Add("@post", MySqlDbType.VarChar).Value = workExp.Post;
                command.Parameters.Add("@duration", MySqlDbType.VarChar).Value = workExp.Duration;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public WorkExpModel GetById(int Id)
        {
            WorkExpModel workExp = new WorkExpModel();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from workExps where ID_workexp=@Id";
                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    workExp=new WorkExpModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Company = (string)reader.GetValue(2),
                        Post = (string)reader.GetValue(3),
                        Duration = (string)reader.GetValue(4)
                    };
                }
            }
            return workExp;
        }

        public List<WorkExpModel> GetByUserId(int userId)
        {
            List<WorkExpModel> workExps = new List<WorkExpModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from workExps where ID_user=@userId";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    workExps.Add(new WorkExpModel()
                    {
                        Id= Convert.ToInt32(reader.GetValue(0)),
                        UserId= Convert.ToInt32(reader.GetValue(1)),
                        Company=(string)reader.GetValue(2),
                        Post= (string)reader.GetValue(3),
                        Duration= (string)reader.GetValue(4)
                    });
                }
            }
            return workExps;
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "delete from workexps where ID_workexp=@id;";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
    }
}

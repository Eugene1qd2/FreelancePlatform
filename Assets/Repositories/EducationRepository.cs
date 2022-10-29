using FreelancePlatform.Assets.Additional_Data;
using FreelancePlatform.Assets.MVVM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.Repositories
{
    class EducationRepository : RepositoryBase, IEducationRepository
    {
        public ErrorStatus Add(EducationModel education, UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = "insert into educations(ID_user,Institution,Startyear,Endyear) value(@id_user,@institution,@startyear,@endyear)";
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
                    command.Parameters.Add("@institution", MySqlDbType.VarChar).Value = education.Institution;
                    command.Parameters.Add("@startyear", MySqlDbType.Int32).Value = education.StartYear;
                    command.Parameters.Add("@endyear", MySqlDbType.Int32).Value = education.EndYear;
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

        public void Edit(EducationModel education)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "update educations set Institution=@institution,Startyear=@startyear,Endyear=@endyear where ID_education=@id;";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = education.Id;
                command.Parameters.Add("@institution", MySqlDbType.VarChar).Value = education.Institution;
                command.Parameters.Add("@startyear", MySqlDbType.Int32).Value = education.StartYear;
                command.Parameters.Add("@endyear", MySqlDbType.Int32).Value = education.EndYear;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public EducationModel GetById(int Id)
        {
            EducationModel education = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from educations where ID_education=@Id";
                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    education = new EducationModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Institution = (string)reader.GetValue(2),
                        StartYear = Convert.ToInt32(reader.GetValue(3)),
                        EndYear = Convert.ToInt32(reader.GetValue(4)),
                    };
                }
            }
            return education;
        }

        public List<EducationModel> GetByUserId(int userId)
        {
            List<EducationModel> educations = new List<EducationModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from educations where ID_user=@userId";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    educations.Add(new EducationModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Institution = (string)reader.GetValue(2),
                        StartYear = Convert.ToInt32(reader.GetValue(3)),
                        EndYear = Convert.ToInt32(reader.GetValue(4)),
                    });
                }
            }
            return educations;
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "delete from educations where ID_education=@id;";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
    }
}

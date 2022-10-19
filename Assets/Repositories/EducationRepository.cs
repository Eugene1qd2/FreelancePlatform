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
    class EducationRepository : RepositoryBase,IEducationRepository
    {
        public ErrorStatus Add(EducationModel education, UserModel user)
        {
            throw new NotImplementedException();
        }

        public void Edit(EducationModel education)
        {
            throw new NotImplementedException();
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
                        Id= Convert.ToInt32(reader.GetValue(0)),
                        UserId= Convert.ToInt32(reader.GetValue(1)),
                        Institution=(string)reader.GetValue(2),
                        StartYear=Convert.ToInt32(reader.GetValue(3)),
                        EndYear= Convert.ToInt32(reader.GetValue(4)),
                    });
                }
            }
            return educations;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

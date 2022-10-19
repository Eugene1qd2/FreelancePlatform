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
    class WorkExpRepository : RepositoryBase,IWorkExpRepository
    {
        public ErrorStatus Add(WorkExpModel workExp, UserModel user)
        {
            throw new NotImplementedException();
        }

        public void Edit(WorkExpModel workExp)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

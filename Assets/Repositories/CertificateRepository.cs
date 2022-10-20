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
    class CertificateRepository : RepositoryBase, ICertificateRepository
    {
        public ErrorStatus Add(CertificateModel certificate, UserModel user)
        {
            throw new NotImplementedException();
        }

        public void Edit(CertificateModel certificate)
        {
            throw new NotImplementedException();
        }

        public List<CertificateModel> GetByUserId(int userId)
        {
            List<CertificateModel> certificates = new List<CertificateModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from сertificates where ID_user=@userId";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    certificates.Add(new CertificateModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Organization = (string)reader.GetValue(2),
                        Skill = (string)reader.GetValue(3),
                        Link = (string)reader.GetValue(4)
                    });
                }
            }
            return certificates;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

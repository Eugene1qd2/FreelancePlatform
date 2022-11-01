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
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = "insert into сertificates(ID_user,Organization,Skill,Link) value(@id_user,@organization,@skill,@link)";
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
                    command.Parameters.Add("@organization", MySqlDbType.VarChar).Value = certificate.Organization;
                    command.Parameters.Add("@skill", MySqlDbType.VarChar).Value = certificate.Skill;
                    command.Parameters.Add("@link", MySqlDbType.VarChar).Value = certificate.Link;
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

        public void Edit(CertificateModel certificate)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "update сertificates set Organization=@organization,Skill=@skill,Link=@link where ID_сertificate=@id;";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = certificate.Id;
                command.Parameters.Add("@organization", MySqlDbType.VarChar).Value = certificate.Organization;
                command.Parameters.Add("@skill", MySqlDbType.VarChar).Value = certificate.Skill;
                command.Parameters.Add("@link", MySqlDbType.VarChar).Value = certificate.Link;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public CertificateModel GetById(int Id)
        {
            CertificateModel certificate = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from сertificates where ID_сertificate=@Id";
                command.Parameters.Add("@Id", MySqlDbType.Int32).Value = Id;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    certificate = new CertificateModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = Convert.ToInt32(reader.GetValue(1)),
                        Organization = (string)reader.GetValue(2),
                        Skill = (string)reader.GetValue(3),
                        Link = (string)reader.GetValue(4),
                    };
                }
            }
            return certificate;
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
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "delete from сertificates where ID_сertificate=@id;";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
    }
}

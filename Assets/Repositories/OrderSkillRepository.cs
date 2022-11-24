using FreelancePlatform.Assets.Additional_Data;
using FreelancePlatform.Assets.MVVM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.Repositories
{
    class OrderSkillRepository : RepositoryBase, IOrderSkillRepository
    {
        public ErrorStatus Add(OrderSkillModel orderSkill, OrderModel order)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = "insert into ads_skills(ID_skill,ID_ad) value(@id_skill,@id_order)";
                    command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value = orderSkill.Id;
                    command.Parameters.Add("@id_order", MySqlDbType.Int32).Value = order.Id;
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

        public ErrorStatus Add(List<OrderSkillModel> orderSkills, OrderModel order)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                try
                {
                    foreach (var item in orderSkills)
                    {
                        command.CommandText = "insert into ads_skills(ID_skill,ID_ad) value(@id_skill,@id_order)";
                        command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value = item.Id;
                        command.Parameters.Add("@id_order", MySqlDbType.Int32).Value = order.Id;
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    return ErrorStatus.RegistrationError;
                }
            }

            return ErrorStatus.NoError;
        }

        public List<OrderSkillModel> GetAllSkills()
        {
            List<OrderSkillModel> skills = new List<OrderSkillModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new OrderSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        OrderId = -1,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    });
                }
            }
            return skills;
        }

        public OrderSkillModel GetById(int Id)
        {
            OrderSkillModel skill = new OrderSkillModel();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills where ID_skill in(@id);";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skill = new OrderSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        OrderId = -1,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    };
                }
            }
            return skill;
        }


        public List<OrderSkillModel> GetByOrderId(int orderId)
        {
            List<OrderSkillModel> userSkills = new List<OrderSkillModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills where ID_skill in(select ID_skill from ads_skills where ID_ad=@orderId);";
                command.Parameters.Add("@orderId", MySqlDbType.Int32).Value = orderId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userSkills.Add(new OrderSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        OrderId = orderId,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    });
                }
            }
            return userSkills;
        }

        public List<OrderSkillModel> GetExceptOrderId(int orderId)
        {
            List<OrderSkillModel> Skills = new List<OrderSkillModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills where ID_skill not in(select ID_skill from ads_skills where ID_ad=@orderId);";
                command.Parameters.Add("@orderId", MySqlDbType.Int32).Value = orderId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Skills.Add(new OrderSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        OrderId = orderId,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    });
                }
            }
            return Skills;
        }

        public void Remove(OrderModel order, int id)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.CommandText = "delete from ads_skills where ID_ad=@id_order and ID_skill=@id_skill;";
                command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@id_order", MySqlDbType.Int32).Value = order.Id;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
    }
}

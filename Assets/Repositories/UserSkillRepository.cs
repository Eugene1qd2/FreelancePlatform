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
    class UserSkillRepository : RepositoryBase, IUserSkillRepository
    {
        public ErrorStatus Add(UserSkillModel userSkill, UserModel user)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = "insert into user_skills(ID_skill,ID_user) value(@id_skill,@id_user)";
                    command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value = userSkill.Id;
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
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

        public List<UserSkillModel> GetAllSkills()
        {
            List<UserSkillModel> skills = new List<UserSkillModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    skills.Add(new UserSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = -1,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    });
                }
            }
            return skills;
        }

        public UserSkillModel GetById(int Id)
        {
            UserSkillModel skill = new UserSkillModel();
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
                    skill = new UserSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = -1,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    };
                }
            }
            return skill;
        }


        public List<UserSkillModel> GetByUserId(int userId)
        {
            List<UserSkillModel> userSkills = new List<UserSkillModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills where ID_skill in(select ID_skill from user_skills where ID_user=@userId);";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userSkills.Add(new UserSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = userId,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    });
                }
            }
            return userSkills;
        }

        public List<UserSkillModel> GetExceptUserId(int userId)
        {
            List<UserSkillModel> userSkills = new List<UserSkillModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from skills where ID_skill not in(select ID_skill from user_skills where ID_user=@userId);";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userSkills.Add(new UserSkillModel()
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        UserId = userId,
                        Skill = (string)reader.GetValue(1),
                        Discription = (string)reader.GetValue(2)
                    });
                }
            }
            return userSkills;
        }

        public void Remove(UserModel user, int id)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                    command.CommandText = "delete from user_skills where ID_user=@id_user and ID_skill=@id_skill;";
                    command.Parameters.Add("@id_skill", MySqlDbType.Int32).Value =id;
                    command.Parameters.Add("@id_user", MySqlDbType.Int32).Value = user.Id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
            }
        }
    }
}

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
    class UserSkillRepository : RepositoryBase, IUserSkillRepository
    {
        public ErrorStatus Add(UserSkillModel workExp, UserModel user)
        {
            throw new NotImplementedException();
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

        public void Remove(UserModel user, int id)
        {
            throw new NotImplementedException();
        }
    }
}

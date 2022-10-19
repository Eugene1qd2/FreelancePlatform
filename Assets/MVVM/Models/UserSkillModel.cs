using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class UserSkillModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Skill { get; set; }
        public string Discription { get; set; }

        public UserSkillModel()
        {

        }
        public UserSkillModel(int userId, int id, string skill, string discription)
        {
            UserId = userId;
            Id = id;
            Skill = skill;
            Discription = discription;
        }
    }
}

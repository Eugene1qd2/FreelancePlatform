using FreelancePlatform.Assets.MVVM.ViewModels;
using FreelancePlatform.Assets.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class OrderSkillModel
    {
        public int OrderId { get; set; }
        public int Id { get; set; }
        public string Skill { get; set; }
        public string Discription { get; set; }

        public OrderSkillModel()
        {

        }
        public OrderSkillModel(int orderId, int id, string skill, string discription)
        {
            OrderId = orderId;
            Id = id;
            Skill = skill;
            Discription = discription;
        }
    }
}

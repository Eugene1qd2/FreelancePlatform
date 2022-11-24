using FreelancePlatform.Assets.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class OrderModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public string WorkPlace { get; set; }
        public string Address { get; set; }
        public double Budget { get; set; }
        public DateTime NonrelDate { get; set; }
        public int LessonCount { get; set; }
        public string Goal { get; set; }
        public bool IsAccepted { get; set; }
        public int ResponseCount { get; set; }
        public int SelectedSkillsCount { get; set; }
        public List<OrderSkillModel> OrderSkills { get; set; }
        public List<ResponseModel> Responses { get; set; }

        public string GoalString
        {
            get
            {
                return "Цель: "+ (Goal.Replace("\n", " ").Replace("\r", string.Empty)).Substring(0,Goal.Length>160?160: Goal.Length) +"...";
            }
            set { }
        }

        public string ResponseCountString
        {
            get
            {
                return "Количество откликов: "+ResponseCount.ToString();
            }
            set { }
        }
        public OrderModel()
        {

        }
    }
}

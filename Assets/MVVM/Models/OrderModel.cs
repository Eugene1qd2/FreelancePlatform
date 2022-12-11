using FreelancePlatform.Assets.MVVM.ViewModels;
using FreelancePlatform.Assets.Repositories;
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
        private int _userId;
        public int UserId { get { return _userId; } set { _userId = value; User = userRepository.GetById(_userId); } }
        public UserModel User { get; set; }
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
                return "Цель: " + (Goal.Replace("\n", " ").Replace("\r", string.Empty)).Substring(0, Goal.Length > 160 ? 160 : Goal.Length) + "...";
            }
            set { }
        }

        public string BudgetString
        {
            get
            {
                return "Бюджет: " + Budget + "р.";
            }
            set { }
        }

        public string LessonCountString
        {
            get
            {
                return "Количество занятий: " + LessonCount;
            }
            set { }
        }

        public string AddressString
        {
            get
            {
                return "Адрес: " + Address;
            }
            set { }
        }

        public string WorkPlaceString
        {
            get
            {
                return "Место работы: " + WorkPlace;
            }
            set { }
        }

        public string NonreldateString
        {
            get
            {
                return "Дата нерелевантности: " + NonrelDate.ToString("dd.MM.yyyy");
            }
            set { }
        }

        public string ResponseCountString
        {
            get
            {
                return "Количество откликов: " + ResponseCount.ToString();
            }
            set { }
        }
        IUserRepository userRepository;
        public List<string> OrderStrings
        {
            get
            {
                List<string> strings = new List<string>();
                strings.Add("Цель: " + Goal);
                strings.Add(BudgetString);
                if (WorkPlace != null && WorkPlace != string.Empty)
                    strings.Add(WorkPlaceString);
                if (Address != null && Address != string.Empty)
                    strings.Add(AddressString);
                strings.Add(NonreldateString);
                if (LessonCount != 0 && LessonCount != -1)
                    strings.Add(LessonCountString);
                return strings;
            }
        }
        public OrderModel()
        {
            userRepository = new UserRepository();
        }
    }
}

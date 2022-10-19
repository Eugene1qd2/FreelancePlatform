using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class WorkExpModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Company { get; set; }
        public string Post { get; set; }
        public string Duration { get; set; }

        private string _workExpString;

        public string WorkExpString
        {
            get
            {
                _workExpString = UserId == 0 ? Company : ("Компания-работодатель: "+Company + "\nДолжность: " + Post + "\nВремя работы: " + Duration );
                return _workExpString;
            }
        }
        public WorkExpModel()
        {

        }
        public WorkExpModel(int userId, int id, string company, string post, string duration)
        {
            UserId = userId;
            Id = id;
            Company = company;
            Post = post;
            Duration = duration;
            _workExpString = "Компания-работодатель: " + Company + "\nДолжность: " + Post + "\nВремя работы: " + Duration;
        }
    }
}

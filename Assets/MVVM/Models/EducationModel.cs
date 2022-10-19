using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class EducationModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Institution { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        private string _educationString;
        public string EducationString
        {
            get
            {
                _educationString = UserId == 0 ? Institution : (Institution + ", " + StartYear + "-" + EndYear + "гг.");
                return _educationString;
            }
        }

        public EducationModel()
        {

        }

        public EducationModel(int userId, int id, string institution, int startYear, int endYear)
        {
            UserId = userId;
            Id = id;
            Institution = institution;
            StartYear = startYear;
            EndYear = endYear;
            _educationString = Institution + ", " + StartYear + "-" + EndYear + "гг.";
        }
    }
}

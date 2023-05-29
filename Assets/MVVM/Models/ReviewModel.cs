using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class ReviewModel
    {
        public UserModel Sender { get; set; }
        public UserModel Resiever { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public List<bool> RateList { get; set; }
        public DateTime Senddate { get; set; }

        public ReviewModel(UserModel sender, string text,int rate, DateTime senddate, UserModel resiever)
        {
            Sender = sender;
            Text = text;
            Rate = rate;
            Senddate = senddate;
            Resiever = resiever;
            List<bool> ratels = new List<bool>();
            for (int i = 0; i < Rate; i++)
            {
                ratels.Add(true);
            }
            RateList = ratels;
        }
        public void FillRateList()
        {
            List<bool> ratels = new List<bool>();
            for (int i = 0; i < Rate; i++)
            {
                ratels.Add(true);
            }
            RateList = ratels;
        }
        public ReviewModel()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public class MessageModel
    {
        public UserModel Sender { get; set; }
        public int ChatId { get; set; }             
        public DateTime SendDate { get; set; }               
        public string Text { get; set; }
        public float Opacity { get; set; }
        public int Side { get; set; }
        public MessageModel()
        {
            Opacity = 1f;
        }
    }
}

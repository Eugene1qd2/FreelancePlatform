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
    public class ChatModel
    {
        public int ChatId { get; set; }
        public string Topic { get; set; }
        private List<UserModel> _chatMembers;
        private int ownerId=-1;
        public List<UserModel> ChatMembers
        {
            get { return _chatMembers; }
            set
            {
                _chatMembers = value;
                if (ownerId != -1)
                {
                    User = value.First(x => x.Id != ownerId);
                }
            }
        }

        public bool isSomethingNew { get; set; }
        public UserModel User { get; set; }

        public ChatModel()
        {

        }

        public ChatModel(int id)
        {
            ownerId = id;
        }
    }
}

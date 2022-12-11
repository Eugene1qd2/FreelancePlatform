using FreelancePlatform.Assets.Additional_Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.Assets.MVVM.Models
{
    public interface IChatRepository
    {
        ErrorStatus Add(ChatModel chat);
        void Edit(ChatModel chat);
        void Remove(int id);
        List<ChatModel> GetByUserId(int userId);
        ChatModel GetById(int Id);
        ObservableCollection<MessageModel> GetMessagesByChatId(int chatId);
        ChatModel GetByMembers(int[] members, string Topic);
    }
}

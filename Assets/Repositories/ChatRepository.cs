using FreelancePlatform.Assets.Additional_Data;
using FreelancePlatform.Assets.MVVM.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;
using static System.Net.Mime.MediaTypeNames;

namespace FreelancePlatform.Assets.Repositories
{
    class ChatRepository : RepositoryBase, IChatRepository
    {
        public ErrorStatus Add(ChatModel chat)
        {
            throw new NotImplementedException();
        }

        public void Edit(ChatModel chat)
        {
            throw new NotImplementedException();
        }

        public ChatModel GetById(int Id)
        {
            IUserRepository userRepository = new UserRepository();
            ChatModel chat = new ChatModel();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from chats where ID_chat in(@chatId)";
                command.Parameters.Add("@chatId", MySqlDbType.Int32).Value = Id;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chat = new ChatModel()
                    {
                        ChatId = Convert.ToInt32(reader.GetValue(0)),
                        Topic = (string)reader.GetValue(1),
                    };
                }
                reader.Close();

                chat.ChatMembers = new List<UserModel>();
                command.CommandText = $"select ID_user from chat_members where ID_chat in({chat.ChatId})";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chat.ChatMembers.Add(userRepository.GetById(Convert.ToInt32(reader.GetValue(0))));
                }
                reader.Close();

            }
            return chat;
        }

        public ChatModel GetByMembers(int[] members, string Topic)
        {
            IUserRepository userRepository = new UserRepository();
            ChatModel chat = new ChatModel();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from chats where ID_chat in(select ID_chat from chat_members where (ID_user=@userId OR ID_user=@userId2) AND Topic=@topic group by ID_chat);";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = members[0];
                command.Parameters.Add("@userId2", MySqlDbType.Int32).Value = members[1];
                command.Parameters.Add("@topic", MySqlDbType.VarChar).Value = Topic;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chat = new ChatModel(members[1])
                    {
                        ChatId = Convert.ToInt32(reader.GetValue(0)),
                        Topic = (string)reader.GetValue(1),
                    };
                }
                reader.Close();
                List<UserModel> memberss = new List<UserModel>();
                command.CommandText = $"select ID_user from chat_members where ID_chat in({chat.ChatId})";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    memberss.Add(userRepository.GetById(Convert.ToInt32(reader.GetValue(0))));
                }
                chat.ChatMembers = memberss;
                reader.Close();

            }
            return chat;
        }

        public ObservableCollection<ChatModel> GetByUserId(int userId)
        {
            IUserRepository userRepository = new UserRepository();
            ObservableCollection<ChatModel> chats = new ObservableCollection<ChatModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from chats where ID_chat in(select ID_chat from chat_members where ID_user=@userId)";
                command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chats.Add(new ChatModel(userId)
                    {
                        ChatId = Convert.ToInt32(reader.GetValue(0)),
                        Topic = (string)reader.GetValue(1),
                    });
                }
                reader.Close();
                for (int i = 0; i < chats.Count; i++)
                {
                    List<UserModel> members = new List<UserModel>();
                    command.CommandText = $"select ID_user from chat_members where ID_chat in({chats[i].ChatId})";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        members.Add(userRepository.GetById(Convert.ToInt32(reader.GetValue(0))));
                    }
                    chats[i].ChatMembers = members;
                    reader.Close();
                }
            }
            return chats;
        }

        public ObservableCollection<MessageModel> GetMessagesByChatId(int chatId)
        {
            IUserRepository userRepository = new UserRepository();

            ObservableCollection<MessageModel> messages = new ObservableCollection<MessageModel>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select ID_user,Senddate,Text from messages where ID_chat=@chatId order by Senddate desc limit 50;";
                command.Parameters.Add("@chatId", MySqlDbType.Int32).Value = chatId;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    messages.Add(new MessageModel()
                    {
                        ChatId = chatId,
                        Sender = userRepository.GetById(Convert.ToInt32(reader.GetValue(0))),
                        SendDate = Convert.ToDateTime(reader.GetValue(1)),
                        Text = (string)reader.GetValue(2),
                    });
                }
            }
            ObservableCollection<MessageModel> messages1 = new ObservableCollection<MessageModel>(messages.Reverse());
            return messages1;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

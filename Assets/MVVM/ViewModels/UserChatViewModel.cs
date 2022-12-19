using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Windows.Design.Interaction;
using MySql.Data.MySqlClient.Memcached;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;
using System.Windows;
using Org.BouncyCastle.Asn1.Cmp;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class UserChatViewModel : ViewModelBase
    {
        IPAddress ipAddr;
        IPEndPoint endPoint;
        TcpClient userClient;

        StreamReader sr;
        StreamWriter sw;

        private ChatModel _currentChat;
        public ChatModel CurrentChat
        {
            get
            {
                return _currentChat;
            }
            set
            {
                _currentChat = value;
                OnPropertyChanged();
                FirstUser = _currentChat.ChatMembers.First(x => x.Id != CurrentUser.Id);
            }
        }
        private UserModel _firstUser;
        public UserModel FirstUser
        {
            get
            {
                return _firstUser;
            }
            set
            {
                _firstUser = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MessageModel> _messages;
        public ObservableCollection<MessageModel> Messages
        {
            get { return _messages; }
            set { _messages = value; OnPropertyChanged(); }
        }

        private UserModel _currentUser;

        IUserRepository userRepository;
        IChatRepository chatRepository;
        IOrderRepository orderRepository;

        public ICommand GoBackCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public ICommand CheckProfileCommand { get; set; }

        public event Action OnGoBack;
        public event Action<int> OnCheckProfile;
        public event Action<int> OnNewMessage;

        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }


        public UserModel CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }


        public UserChatViewModel()
        {
        }

        public UserChatViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            chatRepository = new ChatRepository();
            orderRepository = new OrderRepository();

            CurrentUser = user;

            GoBackCommand = new ViewModelCommand(ExecuteGoBackCommand);
            SendMessageCommand = new ViewModelCommand(ExecuteSendMessageCommand, CanExecuteSendMessageCommand);
            CheckProfileCommand = new ViewModelCommand(ExecuteCheckProfileCommand);
            Connect();
        }

        public void Connect()
        {
            ipAddr = IPAddress.Parse("127.0.0.1");
            endPoint = new IPEndPoint(ipAddr, 8888);
            userClient = new TcpClient();

            userClient.Connect(endPoint);

            sr = new StreamReader(userClient.GetStream());
            sw = new StreamWriter(userClient.GetStream());
            sw.AutoFlush = true;
            sw.WriteLine($"Connect^ {CurrentUser.Id} {CurrentUser.Username}");

            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        if (userClient?.Connected == true)
                        {
                            var line = sr.ReadLine();
                            Console.WriteLine(line);
                            if (line != null)
                            {
                                if (line.Contains("Update^"))
                                {
                                    int id = int.Parse(line.Split()[1]);
                                    if (CurrentChat == null || CurrentChat.ChatId != id)
                                    {
                                        OnNewMessage(id);
                                    }
                                    UpdateInfo(id, false);

                                }
                            }
                        }
                        System.Threading.Tasks.Task.Delay(10).Wait();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            });
        }

        public void Disconnect()
        {
            if (userClient != null)
            {
                try
                {

                    sw.AutoFlush = true;
                    sw.WriteLine($"{CurrentUser.Id} Disconnect^");
                    try
                    {
                        userClient.GetStream().Close();
                    }
                    catch
                    {

                    }
                    userClient.Close();
                    userClient = null;
                }
                catch { }
            }
        }

        private void ExecuteGoBackCommand(object obj)
        {
            OnGoBack();
        }

        private void ExecuteCheckProfileCommand(object obj)
        {
            OnCheckProfile((int)obj);
        }

        private void ExecuteSendMessageCommand(object obj)
        {
            try
            {
                Messages.Add(new MessageModel() { Sender = CurrentUser, SendDate = DateTime.Now, Text = InputText, Opacity = 0.5f });
                sw.AutoFlush = true;
                sw.WriteLine($"{CurrentUser.Id} Send^ {CurrentUser.Id} {CurrentChat.ChatId} msg:{InputText}");
                InputText = string.Empty;
            }
            catch { }
        }
        private bool CanExecuteSendMessageCommand(object obj)
        {
            if (InputText != null)
            {
                return userClient?.Connected == true && InputText != string.Empty;
            }
            else
            {
                return false;
            }
        }

        public void UpdateInfo(int id, bool isSelect)
        {
            if (isSelect)
            {
                CurrentChat = chatRepository.GetById(id);
            }
            if (CurrentChat == null || CurrentChat.ChatId == id)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CurrentChat = chatRepository.GetById(id);
                    Messages = chatRepository.GetMessagesByChatId(CurrentChat.ChatId);
                });
            }

        }

        public void CreateChatById(int id)
        {
            OrderModel order = orderRepository.GetById(id);
            try
            {
                sw.AutoFlush = true;
                sw.WriteLine($"{CurrentUser.Id} Create^ <{order.Topic}> {order.UserId} {CurrentUser.Id} msg:Здравствуйте, меня заинтересовало ваше предложение о работе, не могли бы мы обсудить нюансы?");
                System.Threading.Tasks.Task.Delay(10).Wait();
            }
            catch { }
        }

        public void CreateChatByTopic(string Topic,int UserId)
        {
            try
            {
                sw.AutoFlush = true;
                sw.WriteLine($"{CurrentUser.Id} Create^ <{Topic}> {UserId} {CurrentUser.Id} msg:Здравствуйте, не могли бы мы обсудить некоторые вопросы?");
                System.Threading.Tasks.Task.Delay(10).Wait();
            }
            catch { }
        }

        public int SendConfirmMessage(int UserId, int OrderId)
        {
            OrderModel order = orderRepository.GetById(OrderId);
            int[] members = new int[] { UserId, CurrentUser.Id };
            ChatModel chat = chatRepository.GetByMembers(members, order.Topic);
            try
            {
                sw.AutoFlush = true;
                sw.WriteLine($"{CurrentUser.Id} Send^ {CurrentUser.Id} {chat.ChatId} msg:Здравствуйте, я принимаю ваш отклик для выполнения указанной ниже работы: {order.Goal}");
                System.Threading.Tasks.Task.Delay(10).Wait();
            }
            catch { }
            return chat.ChatId;
        }
    }
}

using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class ChatsViewModel: ViewModelBase
    {
        private UserModel _currentUser;
        private ObservableCollection<ChatModel> _chats;


        IUserRepository userRepository;
        IChatRepository chatRepository;

        public event Action<int> OnSelectChat;

        public ICommand SelectChatCommand { get; set; }
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
        public ObservableCollection<ChatModel> Chats
        {
            get
            {
                return _chats;
            }
            set
            {
                _chats=value;
                OnPropertyChanged();
            }
        }
        public void UpdateInfo()
        {
            Chats = chatRepository.GetByUserId(CurrentUser.Id);
        }
        public ChatsViewModel()
        {
        }

        public ChatsViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            chatRepository=new ChatRepository();
            CurrentUser = user;
            
            Chats = chatRepository.GetByUserId(CurrentUser.Id);
            SelectChatCommand = new ViewModelCommand(ExecuteSelectChatCommand);
        }

        private void ExecuteSelectChatCommand(object obj)
        {
            OnSelectChat((int)obj);
        }
    }
}

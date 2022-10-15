using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using FreelancePlatform.Assets.Additional_Data;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccauntViewModel userAccaunt { get; set; }
        private string _username;
        private string _errorMessage;
        private object _currentView;
        private UserModel _currentUser;

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

        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private IUserRepository userRepository;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value; OnPropertyChanged();
            }

        }
        public ICommand UserAccauntCommand { get; }
        public ICommand OrdersListCommand { get; }
        public ICommand ChatsCommand { get; }
        public ICommand MyOrdersCommand { get; }
        public ICommand SettingsCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            
            CurrentUser = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

            userAccaunt = new UserAccauntViewModel(CurrentUser);

            CurrentView = userAccaunt;
            UserAccauntCommand = new ViewModelCommand(o =>
            {
                CurrentView = userAccaunt;
            });
            OrdersListCommand = new ViewModelCommand(o =>
            {
                CurrentView = null;
            });
            ChatsCommand = new ViewModelCommand(o =>
            {
                CurrentView = null;
            });
            MyOrdersCommand = new ViewModelCommand(o =>
            {
                CurrentView = null;
            });
            SettingsCommand = new ViewModelCommand(o =>
            {
                CurrentView = null;
            });

        }
    }
}

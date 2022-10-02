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

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isEntered = false;

        private IUserRepository userRepository;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged();
            }

        }
        public SecureString Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }

        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }

        }
        public bool IsEntered
        {
            get { return _isEntered; }
            set { _isEntered = value; OnPropertyChanged(); }

        }

        public ICommand LoginCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RememberPasswordCommand = new ViewModelCommand(p=>ExecuteRememberPasswordCommand("",""));
        }

        private bool ExecuteRememberPasswordCommand(string username , string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length<3)
            {
                validData = false;

            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            IPStatus status = IPStatus.Unknown;
            try
            {
                status = new Ping().Send(@"vk.com").Status;
            }
            catch { }
            if (status == IPStatus.Success)
            {
                var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                    IsEntered = true;
                    ErrorMessage = string.Empty;
                }
                else
                {
                    ErrorMessage = "Неправильный логин или пароль!";
                }
            }
            else
            {
                ErrorMessage = "Нет подключения к интернету!";
            }

        }
    }
}

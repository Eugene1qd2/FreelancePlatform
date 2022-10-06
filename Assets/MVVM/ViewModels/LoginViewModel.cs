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
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isEntered = false;
        private bool _isVisible = true;

        private int failureCount = 0;
        private string prevUsername = string.Empty;

        private IUserRepository userRepository;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value; OnPropertyChanged();
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
        public bool IsViewVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; OnPropertyChanged(); }

        }

        public ICommand LoginCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand OpenRegistrationCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RememberPasswordCommand = new ViewModelCommand(p => ExecuteRememberPasswordCommand("", ""));
            OpenRegistrationCommand = new ViewModelCommand(ExecuteOpenRegistationCommand);
        }

        private void ExecuteOpenRegistationCommand(object obj)
        {
            IsViewVisible = false;
            ErrorMessage = string.Empty;
        }

        private bool ExecuteRememberPasswordCommand(string username, string email)
        {
            UserModel user = userRepository.GetByUsername(username);
            if (user != null)
            {
                MailData.SendMail(user.Email, "Ваш пароль: <br><i>" + user.Password + "</i>", "Восстановление пароля");
                ErrorMessage = "Пароль отправлен на вашу почту!";
                return true;
            }
            else
            {
                ErrorMessage = "Такого пользователя не существует!";
                return false;
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
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
            IsEntered = false;
            IPStatus status = IPStatus.Unknown;
            try
            {
                status = new Ping().Send(@"google.com").Status;
            }
            catch { }
            if (status == IPStatus.Success)
            {
                bool isValidUser = false;
                try
                {
                    isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
                }
                catch
                {
                    ErrorMessage = "Нет подключения к базе данных!";
                    return;
                }
                if (isValidUser)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                    IsEntered = true;
                    IsViewVisible = false;
                    ErrorMessage = string.Empty;
                }
                else
                {
                    if (prevUsername == Username)
                    {
                        failureCount++;
                    }
                    else
                    {
                        failureCount = 1;
                        prevUsername = Username;
                    }
                    if (failureCount == 3)
                    {
                        UserModel user = userRepository.GetByUsername(Username);
                        if (user!=null)
                        {
                            MailData.SendMail(user.Email, "Ваш пароль: <br><i>" + user.Password + "</i>", "Восстановление пароля");
                            ErrorMessage = "Пароль отправлен на вашу почту!";
                            return;
                        }
                        else
                        {
                            ErrorMessage = "Такого пользователя не существует!";
                        }

                    }
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

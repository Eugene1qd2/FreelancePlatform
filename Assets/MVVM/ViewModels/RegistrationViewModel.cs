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
using System.Text.RegularExpressions;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _surname;
        private string _name;
        private string _middlename;
        private string _birthdate;
        private string _email;
        private string _male;
        private string _errorMessage;

        private string generatedCode;
        private string _mailInfoText;
        AcceptionWindow acceptionWindow; //тут тоже хз пока
        public string MailInfoText
        {
            get
            {
                return _mailInfoText;
            }
            set
            {
                _mailInfoText = value;
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

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(); }
        }

        public string Middlename
        {
            get { return _middlename; }
            set { _middlename = value; OnPropertyChanged(); }
        }

        public string Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        public string Male
        {
            get { return _male; }
            set { _male = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand DeclineRegistrationCommand { get; }
        public ICommand ConfirmMailCommand { get; }

        public RegistrationViewModel()
        {
            userRepository = new UserRepository();
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
            DeclineRegistrationCommand = new ViewModelCommand(ExecuteDeclineRegistrationCommand);
            ConfirmMailCommand = new ViewModelCommand(ExecuteConfirmMailCommand, CanExecuteConfirmMailCommand);
        }

        private bool CanExecuteConfirmMailCommand(object obj)
        {
            return true;
        }

        private void ExecuteConfirmMailCommand(object obj)
        {
            acceptionWindow.Close();
        }

        private void ExecuteDeclineRegistrationCommand(object obj)
        {
            App.Current.MainWindow.Show();
        }
        public static bool isValidMail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email.ToLower(), pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public static bool isValidString(string str)
        {
            string pattern = "^[A-ЯЁ][а-яё]+";
            Match isMatch = Regex.Match(str.ToLower(), pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public static bool isValidPhone(string phone)
        {
            string pattern = @"^[+](?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$";
            Match isMatch = Regex.Match(phone.ToLower(), pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        public static bool isValidDate(string dates)
        {
            DateTime date;
            bool isDate = DateTime.TryParse(dates, out date);
            bool validDate = date < DateTime.Today && date > new DateTime(1900, 1, 1);
            return isDate && validDate;
        }
        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;
            
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 8 ||
                !isValidString(Surname) ||
                !isValidString(Name) ||
                !isValidString(Middlename) ||
                !isValidMail(Email) ||
                string.IsNullOrWhiteSpace(Male) || !isValidDate(Birthdate))
            {
                validData = false;
            }
            else
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteRegisterCommand(object obj)
        {
            IPStatus status = IPStatus.Unknown;
            try
            {
                status = new Ping().Send(@"google.com").Status;
            }
            catch { }
            if (status == IPStatus.Success)
            {
                generatedCode = MailData.GenerateCode(5);
                try
                {
                MailData.SendMail(Email, "Ваш код подтверждения: " + generatedCode, "Подтверждение электронной почты");
                }
                catch
                {
                    ErrorMessage = "Такой почты не существует!";
                    return;
                }
                acceptionWindow = new AcceptionWindow(Email);
                var result = acceptionWindow.ShowDialog();

                if (result == true)
                    if (acceptionWindow.Code == generatedCode)
                    {
                        try
                        {
                            ErrorStatus errorStatus = userRepository.Add(new UserModel(Username, ErrorData.SecureStringToString(Password), Name, Surname, Middlename, DateTime.Parse(Birthdate), Email, Male));
                            if (errorStatus == ErrorStatus.NoError)
                            {
                                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                                ErrorMessage = string.Empty;
                                App.Current.MainWindow.Show();
                            }
                            else
                            {
                                ErrorMessage = ErrorData.GetErrorMessage(errorStatus);
                            }
                        }
                        catch
                        {
                            ErrorMessage = "Нет подключения к базе данных!";
                        }
                    }
                    else
                    {
                        ErrorMessage = "Неверный код подтверждения!";
                    }
            }
            else
            {
                ErrorMessage = "Нет подключения к интернету!";
            }

        }
    }
}

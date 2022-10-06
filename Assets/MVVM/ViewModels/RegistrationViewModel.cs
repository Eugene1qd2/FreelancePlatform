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
    public class RegistrationViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string surname;
        private string name;
        private string middlename;
        private string birthdate;
        private string email;
        private string male;
        private string _errorMessage;

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
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }

        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; OnPropertyChanged(); }
        }

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        public string Male
        {
            get { return male; }
            set { male = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public RegistrationViewModel()
        {
            userRepository = new UserRepository();
            RegisterCommand = new ViewModelCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            bool validData;
            DateTime date;
            bool isDate = DateTime.TryParse(Birthdate, out date);
            bool validDate = (date < DateTime.Today && date>new DateTime(1900,1,1));
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 8 ||
                string.IsNullOrWhiteSpace(Surname) || Surname.Length<3 ||
                string.IsNullOrWhiteSpace(Name) || Name.Length<3 ||
                string.IsNullOrWhiteSpace(Middlename) || Middlename.Length<3 ||
                string.IsNullOrWhiteSpace(Email) || Email.Length<3 ||
                string.IsNullOrWhiteSpace(Male) || !isDate || !validDate)
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
                try
                {
                    Console.WriteLine(DateTime.Parse(Birthdate));
                    ErrorStatus errorStatus = userRepository.Add(new UserModel(Username, ErrorData.SecureStringToString(Password), Name, Surname, Middlename, DateTime.Parse(Birthdate), Email, Male));
                    if (errorStatus==ErrorStatus.NoError)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                        ErrorMessage = string.Empty;
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
                ErrorMessage = "Нет подключения к интернету!";
            }

        }
    }
}

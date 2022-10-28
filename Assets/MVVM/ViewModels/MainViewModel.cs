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
        private ApplicationSettingsViewModel applicationSettings { get; set; }
        private UserSkillsViewModel userSkills { get; set; }
        private EducationViewModel educations { get; set; }
        private AddEducationViewModel addEducations { get; set; }

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
            applicationSettings = new ApplicationSettingsViewModel();
            userSkills= new UserSkillsViewModel(CurrentUser);
            educations = new EducationViewModel(CurrentUser);
            addEducations = new AddEducationViewModel(CurrentUser);

            CurrentView = userAccaunt;
            UserAccauntCommand = new ViewModelCommand(o =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
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
                CurrentView = applicationSettings;
            });
            userAccaunt.OnChangeSkills += () =>
            {
                CurrentView = userSkills;
            };

            /// <summary>
            /// User Accaunt triggers
            /// </summary>
            userAccaunt.OnChangeEducations += () =>
            {
                CurrentView = educations;
                educations.UpdateInfo();
            };

            /// <summary>
            /// Education triggers
            /// </summary>
            educations.OnAddEducation += () =>
            {
                CurrentView = addEducations;
                addEducations.IdEducation = -1;

            };
            educations.OnEditEducation += (int Id) =>
            {
                CurrentView = addEducations;
                addEducations.IdEducation = Id;
            };

            educations.OnGoBack += () =>
            {
                CurrentView = userAccaunt;
                userAccaunt.UpdateInfo();
            };

            addEducations.OnGoBack += () =>
            {
                CurrentView = educations;
                educations.UpdateInfo();
            };

            addEducations.OnConfirm += () =>
            {
                CurrentView = educations;
                educations.UpdateInfo();
            };

            /// <summary>
            /// User Skills triggers
            /// </summary>
            userSkills.OnGoBack += () =>
            {
                CurrentView=userAccaunt;
                userAccaunt.UpdateInfo();
            };
        }
    }
}

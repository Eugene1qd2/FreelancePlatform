using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class EducationViewModel: ViewModelBase
    {
        private UserModel _currentUser;
        private List<EducationModel> _educations;


        string _errorMessage;

        IEducationRepository educationRepository;

        public ICommand DeclineChangeEducationCommand { get; set; }
        public ICommand RemoveEducationCommand { get; set; }
        public ICommand EditEducationCommand { get; set; }
        public ICommand AddEducationCommand { get; set; }



        public event Action OnGoBack;
        public event Action OnAddEducation;
        public event Action<int> OnEditEducation;


        public List<EducationModel> Educations
        {
            get
            {
                return _educations;
            }
            set
            {
                _educations = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
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


        public EducationViewModel()
        {
        }

        public EducationViewModel(UserModel user)
        {
            educationRepository = new EducationRepository();

            CurrentUser = user;
            Educations = educationRepository.GetByUserId(CurrentUser.Id);

            DeclineChangeEducationCommand = new ViewModelCommand(ExecuteDeclineChangeEducationCommand);
            RemoveEducationCommand = new ViewModelCommand(ExecuteRemoveEducationCommand);
            EditEducationCommand = new ViewModelCommand(ExecuteEditEducationCommand);
            AddEducationCommand = new ViewModelCommand(ExecuteAddEducationCommand);
        }

        public void UpdateInfo()
        {
            Educations = educationRepository.GetByUserId(CurrentUser.Id);
        }

        private void ExecuteDeclineChangeEducationCommand(object obj)
        {
            OnGoBack();
        }

        private void ExecuteRemoveEducationCommand(object obj)
        {
            educationRepository.Remove((int)obj);
            Educations = educationRepository.GetByUserId(CurrentUser.Id);
        }
        private void ExecuteEditEducationCommand(object obj)
        {
            OnEditEducation((int)obj);
        }
        private void ExecuteAddEducationCommand(object obj)
        {
            OnAddEducation();
        }
    }
}

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
    class WorkExpViewModel: ViewModelBase
    {
        private UserModel _currentUser;
        private List<WorkExpModel> _workExps;


        string _errorMessage;

        IWorkExpRepository workExpRepository;

        public ICommand DeclineCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }



        public event Action OnGoBack;
        public event Action OnAddWorkExp;
        public event Action<int> OnEditWorkExp;


        public List<WorkExpModel> WorkExps
        {
            get
            {
                return _workExps;
            }
            set
            {
                _workExps = value;
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


        public WorkExpViewModel()
        {
        }

        public WorkExpViewModel(UserModel user)
        {
            workExpRepository = new WorkExpRepository();

            CurrentUser = user;
            WorkExps = workExpRepository.GetByUserId(CurrentUser.Id);

            DeclineCommand = new ViewModelCommand(ExecuteDeclineCommand);
            RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
        }

        public void UpdateInfo()
        {
            WorkExps = workExpRepository.GetByUserId(CurrentUser.Id);
        }

        private void ExecuteDeclineCommand(object obj)
        {
            OnGoBack();
        }

        private void ExecuteRemoveCommand(object obj)
        {
            workExpRepository.Remove((int)obj);
            WorkExps = workExpRepository.GetByUserId(CurrentUser.Id);
        }
        private void ExecuteEditCommand(object obj)
        {
            OnEditWorkExp((int)obj);
        }
        private void ExecuteAddCommand(object obj)
        {
            OnAddWorkExp();
        }
    }
}

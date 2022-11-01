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
    class CertificateViewModel: ViewModelBase
    {
        private UserModel _currentUser;
        private List<CertificateModel> _certificates;


        string _errorMessage;

        ICertificateRepository certificateRepository;

        public ICommand DeclineCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }



        public event Action OnGoBack;
        public event Action OnAddCertificate;
        public event Action<int> OnEditCertificate;


        public List<CertificateModel> Certificates
        {
            get
            {
                return _certificates;
            }
            set
            {
                _certificates = value;
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


        public CertificateViewModel()
        {
        }

        public CertificateViewModel(UserModel user)
        {
            certificateRepository = new CertificateRepository();

            CurrentUser = user;
            Certificates = certificateRepository.GetByUserId(CurrentUser.Id);

            DeclineCommand = new ViewModelCommand(ExecuteDeclineCommand);
            RemoveCommand = new ViewModelCommand(ExecuteRemoveCommand);
            EditCommand = new ViewModelCommand(ExecuteEditCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
        }

        public void UpdateInfo()
        {
            Certificates = certificateRepository.GetByUserId(CurrentUser.Id);
        }

        private void ExecuteDeclineCommand(object obj)
        {
            OnGoBack();
        }

        private void ExecuteRemoveCommand(object obj)
        {
            certificateRepository.Remove((int)obj);
            Certificates = certificateRepository.GetByUserId(CurrentUser.Id);
        }
        private void ExecuteEditCommand(object obj)
        {
            OnEditCertificate((int)obj);
        }
        private void ExecuteAddCommand(object obj)
        {
            OnAddCertificate();
        }
    }
}

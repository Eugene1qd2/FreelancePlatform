using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class AddCertificateViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        string _organization;
        string _skill;
        string _link;

        string _errorMessage;

        ICertificateRepository certificateRepository;

        public ICommand DeclineCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }



        public event Action OnGoBack;
        public event Action OnConfirm;

        public string Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
                OnPropertyChanged();
            }
        }

        public string Skill
        {
            get
            {
                return _skill;
            }
            set
            {
                _skill = value;
                OnPropertyChanged();
            }
        }
        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
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

        private int _idCertificate;
        public int IdCertificate
        {
            get
            {
                return _idCertificate;
            }
            set
            {
                _idCertificate = value;
                if (value == -1)
                {
                    Organization = string.Empty;
                    Skill = string.Empty;
                    Link = string.Empty;
                }
                else
                {
                    var CurrentWorkExp = certificateRepository.GetById(value);
                    Organization = CurrentWorkExp.Organization;
                    Skill = CurrentWorkExp.Skill;
                    Link = CurrentWorkExp.Link;
                }
            }
        }

        public AddCertificateViewModel()
        {
        }

        public AddCertificateViewModel(UserModel user)
        {
            certificateRepository = new CertificateRepository();

            CurrentUser = user;

            DeclineCommand = new ViewModelCommand(ExecuteDeclineCommand);
            ConfirmCommand = new ViewModelCommand(ExecuteConfirmCommand, CanExecuteConfirmCommand);
        }

        private void ExecuteDeclineCommand(object obj)
        {
            OnGoBack();
        }
        private void ExecuteConfirmCommand(object obj)
        {
            if (IdCertificate != -1)
            {

                certificateRepository.Edit(new CertificateModel()
                {
                    Id = IdCertificate,
                    Organization = Organization,
                    Skill = Skill,
                    Link = Link
                });
            }
            else
            {
                certificateRepository.Add(new CertificateModel()
                {
                    Organization = Organization,
                    Skill = Skill,
                    Link = Link
                }, CurrentUser);
            }
            OnConfirm();
        }

        private bool CanExecuteConfirmCommand(object obj)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(Link, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (Organization != string.Empty
                && Skill != string.Empty && Skill.Length > 3
                && Link != string.Empty && Link.Length > 3
                && result)
            {
                return true;
            }
            return false;
        }
    }
}

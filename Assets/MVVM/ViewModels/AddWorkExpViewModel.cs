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
    class AddWorkExpViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        string _duration;
        string _company;
        string _post;

        string _errorMessage;

        IWorkExpRepository workExpRepository;

        public ICommand DeclineCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }



        public event Action OnGoBack;
        public event Action OnConfirm;

        public string Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
                OnPropertyChanged();
            }
        }
        public string Post
        {
            get
            {
                return _post;
            }
            set
            {
                _post = value;
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

        private int _idWorkExp;
        public int IdWorkExp
        {
            get
            {
                return _idWorkExp;
            }
            set
            {
                _idWorkExp = value;
                if (value == -1)
                {
                    Duration = string.Empty;
                    Company = string.Empty;
                    Post = string.Empty;
                }
                else
                {
                    var CurrentWorkExp = workExpRepository.GetById(value);
                    Duration = CurrentWorkExp.Duration;
                    Company = CurrentWorkExp.Company;
                    Post = CurrentWorkExp.Post;
                }
            }
        }

        public AddWorkExpViewModel()
        {
        }

        public AddWorkExpViewModel(UserModel user)
        {
            workExpRepository = new WorkExpRepository();

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
            if (IdWorkExp != -1)
            {

                workExpRepository.Edit(new WorkExpModel()
                {
                    Id= IdWorkExp,
                    Duration =Duration,
                    Company = Company,
                    Post = Post
                });
            }
            else
            {
                workExpRepository.Add(new WorkExpModel()
                {
                    Duration = Duration,
                    Company = Company,
                    Post = Post
                }, CurrentUser);
            }
            ModalWindow modal = new ModalWindow("Информация об опыте работы сохранена!");
            modal.ShowDialog();
            OnConfirm();
        }
        private bool CanExecuteConfirmCommand(object obj)
        {
            if (Duration != string.Empty
                && Company!=string.Empty && Company.Length>3
                && Post!=string.Empty && Post.Length>3)
            {
                return true;
            }
            return false;
        }
    }
}

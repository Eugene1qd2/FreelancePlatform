using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.MVVM.Views;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class ProfileViewModel : ViewModelBase
    {
        public ICommand UserAccauntCommand { get; set; }
        public ICommand UserStatsCommand { get; set; }
        public ICommand UserReviewsCommand { get; set; }
        private object _currentView { get; set; }
        private UserModel _currentUser { get; set; }
        private UserModel _currentProfile { get; set; }
        private bool _profileCheck { get; set; }
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
        public UserModel CurrentProfile
        {
            get
            {
                return _currentProfile;
            }
            set
            {
                _currentProfile = value;
                OnPropertyChanged();
            }
        }
        public bool ProfileCheck
        {
            get
            {
                return _profileCheck;
            }
            set
            {
                _profileCheck = value; 
                OnPropertyChanged();
            }

        }
        public ProfileViewModel(UserModel user)
        {
            CurrentUser = user;
            CurrentProfile = user;
            ProfileCheck = true;
        }

    }
}

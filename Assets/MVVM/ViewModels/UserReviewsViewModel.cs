using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class UserReviewsViewModel : ViewModelBase
    {
        private UserModel _currentUser;
        private UserModel _currentProfile;
        private int _rate;
        
        IUserRepository userRepository;
        IReviewRepository reviewRepository;
        private ObservableCollection<ReviewModel> _userReviews;

        public ICommand SendReviewCommand { get; }

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

        public ObservableCollection<ReviewModel> UserReviews
        {
            get
            {
                return _userReviews;
            }
            set
            {
                _userReviews = value;
                OnPropertyChanged();
            }
        }
        public int Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged();
            }
        }
        private string _reviewText;

        public string ReviewText
        {
            get { return _reviewText; }
            set 
            {
                _reviewText = value;
                OnPropertyChanged();
            }
        }


        public UserReviewsViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            reviewRepository=new ReviewRepository();
            CurrentUser = user;
            UserReviews=reviewRepository.GetByUserId(user.Id);
            SendReviewCommand = new ViewModelCommand(ExecuteSendReviewCommand, CanExecuteSendReviewCommand);
        }

        private bool CanExecuteSendReviewCommand(object obj)
        {
            return Rate > 0 && !String.IsNullOrEmpty(ReviewText) && CurrentUser.Id!=CurrentProfile.Id;
        }

        private void ExecuteSendReviewCommand(object obj)
        {
            if(reviewRepository.Add(new ReviewModel(CurrentUser, ReviewText, Rate, DateTime.Now, CurrentProfile))==Additional_Data.ErrorStatus.NoError)
            {
                ModalWindow md=new ModalWindow("Отзыв успешно добавлен!");
                md.ShowDialog();
            }
            else
            {
                ModalWindow md = new ModalWindow("Возникли некоторые проблеммы с добавлением отзыва!");
                md.ShowDialog();
            }
            UserReviews = reviewRepository.GetByUserId(CurrentProfile.Id);
        }

        public void UpdateInfo(int id)
        {
            CurrentUser = userRepository.GetByUsername(CurrentUser.Username);
            CurrentProfile=userRepository.GetById(id);
            UserReviews = reviewRepository.GetByUserId(id);
        }
    }
}

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
    class UserStatsViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        public ObservableCollection<ResponseModel> _doneOrders;

        private int _userLeftOrdersCount;
        private int _userAcceptedOrdersCount;
        private float _userRate;

        public int UserLeftOrdersCount
        {
            get
            {
                return _userLeftOrdersCount;
            }
            set
            {
                _userLeftOrdersCount = value;
                OnPropertyChanged();
            }
        }

        public int UserAcceptedOrdersCount
        {
            get
            {
                return _userAcceptedOrdersCount;
            }
            set
            {
                _userAcceptedOrdersCount = value;
                OnPropertyChanged();
            }
        }

        public float UserRate
        {
            get
            {
                return _userRate;
            }
            set
            {
                _userRate = value;
                OnPropertyChanged();
            }
        }

        IUserRepository userRepository;
        IUserStatsRepository userStatsRepository;
        IOrderRepository orderRepository;

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

        public ObservableCollection<ResponseModel> DoneOrders
        {
            get
            {
                return _doneOrders;
            }
            set
            {
                _doneOrders = value;
                OnPropertyChanged();
            }
        }

        public UserStatsViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            userStatsRepository = new UserStatsRepository();
            orderRepository = new OrderRepository();

            CurrentUser = user;
        }

        public void UpdateInfo()
        {
            CurrentUser = userRepository.GetByUsername(CurrentUser.Username);
            UserRate = userStatsRepository.GetRateById(CurrentUser.Id);
            UserAcceptedOrdersCount = userStatsRepository.GetAcceptedOrdersCountById(CurrentUser.Id);
            UserLeftOrdersCount = userStatsRepository.GetLeftOrdersCountById(CurrentUser.Id);
            DoneOrders = orderRepository.GetOrdersInWorkById(CurrentUser.Id);

        }
    }
}

using FreelancePlatform.Assets.MVVM.Models;
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
    class OrdersViewModel: ViewModelBase
    {
        private UserModel _currentUser;
        private List<OrderModel> _orders;

        IUserRepository userRepository;
        IOrderRepository orderRepository;

        public event Action<int> OnSelectOrder;

        public ICommand SelectOrderCommand { get; set; }
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

        public List<OrderModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }


        public void UpdateInfo()
        {
            Orders = orderRepository.GetAll();
        }

        public OrdersViewModel()
        {
        }

        public OrdersViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();

            CurrentUser = user;
            Orders= orderRepository.GetAll();

            SelectOrderCommand = new ViewModelCommand(ExecuteSelectOrderCommand);
        }

        private void ExecuteSelectOrderCommand(object obj)
        {
            OnSelectOrder((int)obj);
        }
    }
}

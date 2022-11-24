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
    class MyOrdersViewModel: ViewModelBase
    {
        private UserModel _currentUser;
        private List<OrderModel> _myOrders;

        IUserRepository userRepository;
        IOrderRepository orderRepository;

        public event Action<int> OnSelectOrder;
        public event Action OnAddOrder;

        public ICommand SelectOrderCommand { get; set; }
        public ICommand AddOrderCommand { get; set; }
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

        public List<OrderModel> MyOrders
        {
            get
            {
                return _myOrders;
            }
            set
            {
                _myOrders = value;
                OnPropertyChanged();
            }
        }


        public void UpdateInfo()
        {
            MyOrders = orderRepository.GetByUserId(CurrentUser.Id);
        }

        public MyOrdersViewModel()
        {
        }

        public MyOrdersViewModel(UserModel user)
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();

            CurrentUser = user;
            MyOrders= orderRepository.GetByUserId(CurrentUser.Id);

            SelectOrderCommand = new ViewModelCommand(ExecuteSelectOrderCommand);
            AddOrderCommand = new ViewModelCommand(ExecuteAddOrderCommand);
        }

        private void ExecuteSelectOrderCommand(object obj)
        {
            OnSelectOrder((int)obj);
        }
        
        private void ExecuteAddOrderCommand(object obj)
        {
            OnAddOrder();
        }
    }
}

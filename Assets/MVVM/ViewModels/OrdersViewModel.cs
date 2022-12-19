using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class OrdersViewModel : ViewModelBase
    {
        private UserModel _currentUser;
        private ObservableCollection<OrderModel> _orders;

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

        public ObservableCollection<OrderModel> Orders
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
            Orders = orderRepository.GetAll();

            SelectOrderCommand = new ViewModelCommand(ExecuteSelectOrderCommand);
        }

        private void ExecuteSelectOrderCommand(object obj)
        {
            OnSelectOrder((int)obj);
        }

        internal void UpdateInfo(FilterStruct filter)
        {
            if (filter.search != string.Empty && filter.search != null && filter.search.Trim() != string.Empty)
            {
                if (filter.search.Contains("@"))
                {
                    string username = filter.search.Split(new string[] { " ", ",", "@" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (username != string.Empty)
                    {
                        Orders = orderRepository.GetByUsername(username);
                    }
                    else
                    {
                        Orders = new ObservableCollection<OrderModel>();
                    }
                }
                else
                if (filter.search.Contains("#"))
                {
                    string[] skills = filter.search.Split(new string[] { " ", ",", "#" }, StringSplitOptions.RemoveEmptyEntries);
                    if (skills.Length > 0)
                    {
                        Orders = orderRepository.GetBySkills(skills);
                    }
                    else
                    {
                        Orders = new ObservableCollection<OrderModel>();
                    }
                }
                else
                {
                    Orders = orderRepository.GetByTopic(filter.search);
                }
            }
            else
            {
                Orders = orderRepository.GetAll();
            }

            if (filter.budget != null && filter.budget > 0)
            {
                ObservableCollection<OrderModel> list = new ObservableCollection<OrderModel>();
                foreach (OrderModel order in Orders)
                {
                    if (order.Budget > filter.budget)
                    {
                        list.Add(order);
                    }
                }
                Orders =list;
            }
        }
    }
}

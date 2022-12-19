using FreelancePlatform.Assets.MVVM.Models;
using FreelancePlatform.Assets.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FreelancePlatform.Assets.MVVM.ViewModels
{
    class AddOrderViewModel : ViewModelBase
    {
        private UserModel _currentUser;

        string _errorMessage;

        bool _isStudy;
        bool _isAdderss;
        bool _isNotStudy;
        bool _isNotAdderss;

        public ICommand DeclineCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand AddSkillsCommand { get; set; }

        private string _topic;
        private string _type;
        private string _workPlace;
        private string _address;
        private double _budget;
        private string _nonreldate;
        private DateTime _dateNonreldate;
        private int _lessonCount;
        private string _goal;
        private bool _isAccepted;

        public event Action OnGoBack;
        public event Action OnConfirm;
        public event Action OnAddSkills;

        public OrderModel SelectedOrder;

        private IOrderRepository orderRepository;
        private IOrderSkillRepository orderSkillsRepository;

        public List<OrderSkillModel> OrderSkills;


        public bool IsStudy
        {
            get { return _isStudy; }
            set
            {
                _isStudy = value;
                IsNotStudy = !_isStudy;
                if (value)
                {
                    Type = "Обучение";
                }
                else
                {
                    Type = "Создание проекта";
                    LessonCount = 0;
                    WorkPlace = string.Empty;
                    Address = string.Empty;
                    IsAddress = false;
                }
                OnPropertyChanged();
            }
        }
        public bool IsAddress
        {
            get
            {
                return _isAdderss;
            }
            set
            {
                _isAdderss = value;
                IsNotAddress = !_isAdderss;
                if (value)
                {
                    WorkPlace = "По адресу";
                }
                else
                {
                    WorkPlace = "Удалённо";
                    Address = string.Empty;
                }
                OnPropertyChanged();
            }
        }

        public bool IsNotStudy
        {
            get { return _isNotStudy; }
            set
            {
                _isNotStudy = value;
                OnPropertyChanged();
            }
        }
        public bool IsNotAddress
        {
            get
            {
                return _isNotAdderss;
            }
            set
            {
                _isNotAdderss = value;
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

        private int _idorder;
        public int IdOrder
        {
            get
            {
                return _idorder;
            }
            set
            {
                _idorder = value;
                if (value == -1)
                {
                    Topic = string.Empty;
                    Address = string.Empty;
                    Goal = string.Empty;
                    LessonCount=0;
                    WorkPlace = string.Empty;
                    Address = string.Empty;
                    Nonreldate=string.Empty;
                    Budget = 0;
                    IsAddress = true;
                    IsStudy = true;
                }
                else
                {
                    SelectedOrder = orderRepository.GetById(value);
                    Topic = SelectedOrder.Topic;
                    Address = SelectedOrder.Address;
                    Goal = SelectedOrder.Goal;
                    if (SelectedOrder.Type== "Обучение")
                    {
                        LessonCount = SelectedOrder.LessonCount;
                        WorkPlace = SelectedOrder.WorkPlace;
                        IsStudy = true;
                        if (WorkPlace== "По адресу")
                        {
                            IsAddress = true;
                            Address = SelectedOrder.Address;
                        }
                        else
                        {
                            IsAddress = false;
                            Address = string.Empty;
                        }
                    }
                    else
                    {
                        IsStudy = false;
                        LessonCount = 0;
                        WorkPlace = string.Empty;
                    }
                    IsAccepted = SelectedOrder.IsAccepted;
                    
                    Nonreldate = SelectedOrder.NonrelDate.ToString("dd-MM-yyyy");
                    Budget = SelectedOrder.Budget;
                    OrderSkills = orderSkillsRepository.GetByOrderId(SelectedOrder.Id);
                    SelectedOrder.OrderSkills = OrderSkills;
                }
            }
        }

        public string Topic
        {
            get
            {
                return _topic;
            }
            set
            {
                _topic = value;
                OnPropertyChanged();
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public string WorkPlace
        {
            get
            {
                return _workPlace;
            }
            set
            {
                _workPlace = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }
        public double Budget
        {
            get
            {
                return _budget;
            }
            set
            {
                _budget = value;
                OnPropertyChanged();
            }
        }
        public string Nonreldate
        {
            get
            {
                return _nonreldate;
            }
            set
            {
                _nonreldate = value;
                DateTime.TryParse(_nonreldate, out _dateNonreldate);
                OnPropertyChanged();
            }
        }
        public int LessonCount
        {
            get
            {
                return _lessonCount;
            }
            set
            {
                _lessonCount = value;
                OnPropertyChanged();
            }
        }
        public string Goal
        {
            get
            {
                return _goal;
            }
            set
            {
                _goal = value;
                OnPropertyChanged();
            }
        }
        public bool IsAccepted
        {
            get
            {
                return _isAccepted;
            }
            set
            {
                _isAccepted = value;
                OnPropertyChanged();
            }
        }

        public AddOrderViewModel()
        {
        }

        public AddOrderViewModel(UserModel user)
        {
            orderRepository = new OrderRepository();
            orderSkillsRepository = new OrderSkillRepository();

            CurrentUser = user;
            IsStudy = true;
            IsAddress = true;
            ConfirmCommand = new ViewModelCommand(ExecuteConfirmCommand, CanExecuteConfirmCommand);
            DeclineCommand = new ViewModelCommand(ExecuteDeclineCommand);
            AddSkillsCommand = new ViewModelCommand(ExecuteAddSkillsCommand);
        }

        private void ExecuteDeclineCommand(object obj)
        {
            OnGoBack();
        }
        private void ExecuteConfirmCommand(object obj)
        {
            if (IdOrder == -1)
            {
                OrderModel order = new OrderModel()
                {
                    Topic = Topic,
                    Type = Type,
                    WorkPlace = WorkPlace,
                    Address = Address,
                    Budget = Budget,
                    NonrelDate = _dateNonreldate,
                    LessonCount = LessonCount,
                    Goal = Goal,
                    IsAccepted = IsAccepted,
                    OrderSkills = OrderSkills,
                };
            }
            else
            {
                OrderModel order = new OrderModel()
                {
                    Id = IdOrder,
                    Topic = Topic,
                    Type = Type,
                    WorkPlace = WorkPlace,
                    Address = Address,
                    Budget = Budget,
                    NonrelDate = _dateNonreldate,
                    LessonCount = LessonCount,
                    Goal = Goal,
                    IsAccepted = IsAccepted,
                    OrderSkills = OrderSkills,
                };
                orderRepository.Edit(order);
            }
            ModalWindow modal = new ModalWindow("Информация о заказе сохранена!");
            modal.ShowDialog();
            OnConfirm();
        }
        private void ExecuteAddSkillsCommand(object obj)
        {
            OnAddSkills();
        }
        private bool CanExecuteConfirmCommand(object obj)
        {
            if (Topic.Length > 3 && Type != string.Empty && ((IsStudy && (!IsAddress || Address.Length > 3) && LessonCount > 0) || (!IsStudy)) && Budget > 0 && _nonreldate != null && _dateNonreldate > DateTime.Now && Goal.Length > 10 && OrderSkills != null && OrderSkills.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}

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
    class OrderSkillsViewModel : ViewModelBase
    {
        private List<OrderSkillModel> _orderSkills;
        private List<OrderSkillModel> _displaySkills;
        private List<OrderSkillModel> _allSkills;

        private string _searchSkills;

        private OrderModel _currentOrder;

        string _errorMessage;

        IOrderSkillRepository orderSkillRepository;

        public ICommand DeclineChangeSkillsCommand { get; set; }
        public ICommand RemoveSkillCommand { get; set; }
        public ICommand AddSkillCommand { get; set; }



        public event Action OnGoBack;

        public string SearchSkills
        {
            get { return _searchSkills; }
            set
            {
                _searchSkills = value;
                OnPropertyChanged();
                FilterSkills();
            }
        }


        public List<OrderSkillModel> Skills
        {
            get
            {
                return _displaySkills;
            }
            set
            {
                _displaySkills = value;
                OnPropertyChanged();
            }
        }


        public List<OrderSkillModel> OrderSkills
        {
            get
            {
                return _orderSkills;
            }
            set
            {
                _orderSkills = value;
                OnPropertyChanged();
            }
        }

        private void FilterSkills()
        {
            Skills = _allSkills.Except(OrderSkills, new ListOrderComparer()).ToList();

            if (Skills != null && SearchSkills != string.Empty && SearchSkills != null)
            {
                Skills = Skills.Where(x => x.Skill.Contains(SearchSkills)).ToList();
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

        public OrderModel CurrentOrder
        {
            get
            {
                return _currentOrder;
            }
            set
            {
                _currentOrder = value;
                OnPropertyChanged();
            }
        }

        public OrderSkillsViewModel()
        {
            orderSkillRepository = new OrderSkillRepository();

            _allSkills = orderSkillRepository.GetAllSkills();

            Skills = new List<OrderSkillModel>();
            DeclineChangeSkillsCommand = new ViewModelCommand(ExecuteDeclineChangeSkillsCommand);
            AddSkillCommand = new ViewModelCommand(ExecuteAddSkillsCommand);
            RemoveSkillCommand = new ViewModelCommand(ExecuteRemoveSkillCommand);
            OrderSkills = new List<OrderSkillModel>();

        }

        public OrderSkillsViewModel(OrderModel order)
        {
            orderSkillRepository = new OrderSkillRepository();

            CurrentOrder = order;

            OrderSkills = orderSkillRepository.GetByOrderId(order.Id);
            _allSkills = orderSkillRepository.GetAllSkills();
            Skills = _allSkills.Except(OrderSkills, new ListOrderComparer()).ToList();

            DeclineChangeSkillsCommand = new ViewModelCommand(ExecuteDeclineChangeSkillsCommand);
            AddSkillCommand = new ViewModelCommand(ExecuteAddSkillsCommand);
            RemoveSkillCommand = new ViewModelCommand(ExecuteRemoveSkillCommand);
        }

        private void ExecuteDeclineChangeSkillsCommand(object obj)
        {
            OnGoBack();
        }

        private void ExecuteRemoveSkillCommand(object obj)
        {
            OrderSkillModel skill = orderSkillRepository.GetById((int)obj);

            skill.OrderId = CurrentOrder == null ? -1 : CurrentOrder.Id;
            List<OrderSkillModel> skills = new List<OrderSkillModel>();
            foreach (var item in OrderSkills)
            {
                skills.Add(item);
            }
            skills.RemoveAll(x => x.Id == skill.Id);
            OrderSkills = skills;

            UpdateSkills();
            FilterSkills();
        }

        private void ExecuteAddSkillsCommand(object obj)
        {
            OrderSkillModel skill = orderSkillRepository.GetById((int)obj);

            skill.OrderId = CurrentOrder == null ? -1 : CurrentOrder.Id;
            List<OrderSkillModel> skills = new List<OrderSkillModel>();
            foreach (var item in OrderSkills)
            {
                skills.Add(item);
            }
            skills.Add(skill);
            OrderSkills = skills;

            UpdateSkills();
            FilterSkills();
        }

        private void UpdateSkills()
        {
            Skills = _allSkills.Except(OrderSkills, new ListOrderComparer()).ToList();
        }

        internal void UpdateInfo(OrderModel selectedOrder)
        {
            CurrentOrder = selectedOrder;
            _allSkills = orderSkillRepository.GetAllSkills();
            Skills = _allSkills.Except(OrderSkills, new ListOrderComparer()).ToList();
            if (selectedOrder != null)
            {
                OrderSkills = selectedOrder.OrderSkills == null ? new List<OrderSkillModel>() : selectedOrder.OrderSkills;
            }
            else
            {
                OrderSkills = new List<OrderSkillModel>();
            }
            DeclineChangeSkillsCommand = new ViewModelCommand(ExecuteDeclineChangeSkillsCommand);
            AddSkillCommand = new ViewModelCommand(ExecuteAddSkillsCommand);
            RemoveSkillCommand = new ViewModelCommand(ExecuteRemoveSkillCommand);
        }
    }
    public class ListOrderComparer : IEqualityComparer<OrderSkillModel>
    {
        bool IEqualityComparer<OrderSkillModel>.Equals(OrderSkillModel x, OrderSkillModel y)
        {
            return (x.Skill.Equals(y.Skill) && x.Id.Equals(y.Id));
        }

        int IEqualityComparer<OrderSkillModel>.GetHashCode(OrderSkillModel obj)
        {
            if (ReferenceEquals(obj, null))
                return 0;

            return obj.Skill.GetHashCode() + obj.Id;
        }
    }
}

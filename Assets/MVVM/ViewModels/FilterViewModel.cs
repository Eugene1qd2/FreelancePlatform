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
    public struct FilterStruct
    {
        public string search;
        public int budget;
    }
    class FilterViewModel : ViewModelBase
    {
        public ICommand ApplyFilterCommand { get; set; }

        public event Action<FilterStruct> OnApplyFilter;

        private float _opacity;
        public float Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                _opacity = value;
                OnPropertyChanged();
            }
        }

        private string _inputText;

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        private int _budget;

        public int Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                OnPropertyChanged();
            }
        }

        private IOrderRepository orderRepository;
        private IOrderSkillRepository orderSkillsRepository;

        public FilterViewModel()
        {
            orderRepository = new OrderRepository();
            orderSkillsRepository = new OrderSkillRepository();

            ApplyFilterCommand = new ViewModelCommand(ExecuteApplyFilterCommand);
        }
        private void ExecuteApplyFilterCommand(object obj)
        {
            OnApplyFilter(new FilterStruct()
            {
                budget = _budget,
                search = _inputText,
            });
        }
    }
}

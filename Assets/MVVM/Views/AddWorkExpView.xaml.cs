using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FreelancePlatform.Assets.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для UserSkillsViewModel.xaml
    /// </summary>
    public partial class AddWorkExpView : UserControl
    {
        private bool isChecked = false;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                CheckedPropertyChanged();
                isChecked = value;
            }
        }

        private void CheckedPropertyChanged()
        {
            if (IsChecked)
            {
                rect.Visibility = Visibility.Hidden;
                list.Visibility = Visibility.Hidden;
            }
            else
            {
                rect.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Visible;
            }
        }
        private void MaleDropdown(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textB.Text = (list.Items[list.SelectedIndex] as ListBoxItem).Content.ToString();
            IsChecked = false;
        }
        public AddWorkExpView()
        {
            InitializeComponent();
        }
    }
}

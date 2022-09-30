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

namespace FreelancePlatform.Assets.Controls
{
    /// <summary>
    /// Логика взаимодействия для UnderlinedComboBox.xaml
    /// </summary>
    public partial class UnderlinedComboBox : UserControl
    {
        private bool isChecked=false;

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
                rect.Height = 0;
                rect.Visibility = Visibility.Hidden;
                list.Visibility = Visibility.Hidden;
            }
            else
            {
                rect.Height = 220;
                rect.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Visible;
            }
        }

        public UnderlinedComboBox()
        {
            InitializeComponent();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textB.Text = (list.Items[list.SelectedIndex] as ListBoxItem).Content.ToString();
            IsChecked = false;
            textB.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x39, 0x3E, 0x46));
        }

        private void ListBoxItem_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as ListBoxItem).Background= new SolidColorBrush(Color.FromArgb(0xFF, 0xc9, 0xc9, 0xc9));
        }

        private void ListBoxItem_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as ListBoxItem).Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xd9, 0xd9, 0xd9));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            btn.Opacity = 0.8;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            btn.Opacity = 1;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}

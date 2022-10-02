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
using System.Windows.Shapes;

namespace FreelancePlatform
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
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

        public RegistrationWindow()
        {
             InitializeComponent();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void HintButtonClick(object sender, RoutedEventArgs e)
        {
            ModalWindow modal = new ModalWindow((sender as Button).Tag.ToString());
            modal.ShowDialog();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
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
            textB.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x39, 0x3E, 0x46));
        }
    }
}

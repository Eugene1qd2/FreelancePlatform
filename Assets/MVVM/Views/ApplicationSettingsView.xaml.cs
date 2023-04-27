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
    /// Логика взаимодействия для UserAccountView.xaml
    /// </summary>
    public partial class ApplicationSettingsView : UserControl
    {
        ResourceDictionary DefaultTheme;
        ResourceDictionary RedTheme;
        ResourceDictionary BlueTheme;
        ResourceDictionary YellowTheme;

        public ApplicationSettingsView()
        {
            InitializeComponent();
            var uri = new Uri(@"Assets/Themes/DefaultTheme.xaml", UriKind.Relative);
            DefaultTheme = Application.LoadComponent(uri) as ResourceDictionary;
            uri = new Uri(@"Assets/Themes/RedTheme.xaml", UriKind.Relative);
            RedTheme = Application.LoadComponent(uri) as ResourceDictionary;
            uri = new Uri(@"Assets/Themes/BlueTheme.xaml", UriKind.Relative);
            BlueTheme = Application.LoadComponent(uri) as ResourceDictionary;
            uri = new Uri(@"Assets/Themes/YellowTheme.xaml", UriKind.Relative);
            YellowTheme = Application.LoadComponent(uri) as ResourceDictionary;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Remove(RedTheme);
            Application.Current.Resources.MergedDictionaries.Remove(BlueTheme);
            Application.Current.Resources.MergedDictionaries.Remove(YellowTheme);
            Application.Current.Resources.MergedDictionaries.Add(DefaultTheme);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Add(RedTheme);
            Application.Current.Resources.MergedDictionaries.Remove(YellowTheme);
            Application.Current.Resources.MergedDictionaries.Remove(BlueTheme);
            Application.Current.Resources.MergedDictionaries.Remove(DefaultTheme);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Remove(RedTheme);
            Application.Current.Resources.MergedDictionaries.Remove(YellowTheme);
            Application.Current.Resources.MergedDictionaries.Add(BlueTheme);
            Application.Current.Resources.MergedDictionaries.Remove(DefaultTheme);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Remove(RedTheme);
            Application.Current.Resources.MergedDictionaries.Add(YellowTheme);
            Application.Current.Resources.MergedDictionaries.Remove(BlueTheme);
            Application.Current.Resources.MergedDictionaries.Remove(DefaultTheme);
        }
    }
}

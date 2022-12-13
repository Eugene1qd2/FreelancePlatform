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
    public partial class UserChatView : UserControl
    {
        public UserChatView()
        {
            InitializeComponent();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            ScrollViewer listViewScrollViewer = GetVisualChild<ScrollViewer>(listView);
            listViewScrollViewer.LineDown();
        }
        private static T GetVisualChild<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        private void ListView_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            ListView listView = sender as ListView;
            ScrollViewer listViewScrollViewer = GetVisualChild<ScrollViewer>(listView);
            listViewScrollViewer.LineDown();
        }
    }
}

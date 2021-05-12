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

namespace OOPTotmyanina.FolderWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        public WindowMenu()
        {
            InitializeComponent();
        }

        private void miBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            FolderClass.ClassMB.MessageQuestionExit();
        }

        private void miListStaff_Click(object sender, RoutedEventArgs e)
        {
            WindowListUser windowListUser = new WindowListUser();
            windowListUser.ShowDialog();
        }
    }
}

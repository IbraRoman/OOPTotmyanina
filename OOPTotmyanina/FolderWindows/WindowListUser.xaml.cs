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
    /// Логика взаимодействия для WindowListUser.xaml
    /// </summary>
    public partial class WindowListUser : Window
    {
        FolderClass.ClassDG ClassDG;
        public WindowListUser()
        {
            InitializeComponent();
            ClassDG = new FolderClass.ClassDG(DgListUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClassDG.LoadDB("SELECT * FROM dbo.ViewUser");
        }
    }
}

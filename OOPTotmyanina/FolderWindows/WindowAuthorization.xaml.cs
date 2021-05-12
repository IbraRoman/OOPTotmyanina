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
using System.Data.SqlClient;

namespace OOPTotmyanina.FolderWindows
{
    /// <summary>
    /// Interaction logic for WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=K306PC10\SQLEXPRESS;
                                                         Initial Catalog=OOPAmir;
                                                         Integrated Security=True");
        SqlCommand sqlCommand;
        SqlDataReader SqlDataReader;
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                FolderClass.ClassMB.MBError("Не заполнен логин");
                tbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(psbPassword.Password))
            {
                FolderClass.ClassMB.MBError("Не заполнен пароль");
                psbPassword.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select PasswordUser," +
                        "NameRole From dbo.ViewUser " +
                        $"Where LoginUser='{tbLogin.Text}'", sqlConnection);
                    SqlDataReader = sqlCommand.ExecuteReader();
                    SqlDataReader.Read();
                    if (SqlDataReader[0].ToString() != psbPassword.Password)
                    {
                        FolderClass.ClassMB.MBError("Не верный пароль");
                        psbPassword.Focus();
                    }
                    else
                    {
                        FolderClass.FolderTables.ClassUser.LoginUser = tbLogin.Text;
                        FolderClass.FolderTables.ClassUser.PasswordUser = psbPassword.Password;
                        FolderClass.FolderTables.ClassRole.NameRole = SqlDataReader[1].ToString();

                        switch (FolderClass.FolderTables.ClassRole.NameRole)
                        {
                            case "Администратор":
                                WindowMenu windowMenu = new WindowMenu();
                                windowMenu.ShowDialog();
                                break;
                            case "Пользователь":
                                FolderClass.ClassMB.MBInformation("Роль пользователя "); 
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    FolderClass.ClassMB.MBError(ex);

                    
                }
                finally
                {
                    sqlConnection.Close();

                }
            }


        }
    }
}
        
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace OOPTotmyanina.FolderClass
{
    class ClassDG
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=K306PC10\SQLEXPRESS;
                                                         Initial Catalog=OOPAmir;
                                                         Integrated Security=True");
        DataGrid DataGrid;
        SqlDataAdapter SqlDataAdapter;
        DataTable DataTable;

        //конструктор класса
        public ClassDG(DataGrid dataGrid)
        {
            this.DataGrid = dataGrid;
        }

        public void LoadDB(string sqlCommand)
        {
            try
            {
                //открывается подключение
                sqlConnection.Open();
                //работа с БД на основе sql-команды
                //и подключения
                SqlDataAdapter = new SqlDataAdapter(sqlCommand, sqlConnection);
                //объявляется новая виртуальная таблица
                DataTable = new DataTable();
                //заполняется виртуальная таблица
                //на основе sql-команды и подключения 
                SqlDataAdapter.Fill(DataTable);
                //из виртуальной тыблицы загружаются
                //данные в DataGrid
                DataGrid.ItemsSource = DataTable.DefaultView;
            }
            catch (Exception ex)
            {
                ClassMB.MBError(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}

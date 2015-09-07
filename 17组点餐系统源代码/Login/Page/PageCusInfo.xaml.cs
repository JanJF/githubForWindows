using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;
using OrderSystemBLL;

namespace Login.Page
{
    /// <summary>
    /// PageCusInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PageCusInfo : System.Windows.Controls.Page
    {

        DataTable dt = new DataTable();
        CustomerDAL c_dal = new CustomerDAL();
        CustomerBLL c_bll = new CustomerBLL();

        static int id;
        public PageCusInfo()
        {
            InitializeComponent();
            dt = c_dal.GetAllCustomer_dt();
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
                        
            var bl = dg.IsChecked;
            if (bl == true)
            {
                id = int.Parse(((DataRowView)dataGrid1.CurrentItem).Row[0].ToString());
            }
            DataTable dt = (dataGrid1.ItemsSource as DataView).Table;
            c_bll.Delete_customer(id);
            MessageBox.Show("删除成功");
            dt = c_dal.GetAllCustomer_dt();
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dt = c_dal.select_customer_by_telephone_dt(textBox1.Text);
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        
    }
}

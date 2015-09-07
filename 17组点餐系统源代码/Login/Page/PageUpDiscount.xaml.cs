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
using OrderSystemBLL;

namespace Login.Page
{
    /// <summary>
    /// PageUpDiscount.xaml 的交互逻辑
    /// </summary>
    public partial class PageUpDiscount : System.Windows.Controls.Page
    {
        RestaurantBLL rest = new RestaurantBLL();

        public PageUpDiscount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int rest_privilege = common.rest.rest_privilege;                
            int rest_service1 = common.rest.rest_service;
            DateTime begin = common.rest.begin_date;
            DateTime end = common.rest.end_date;
            int ID = common.rest.ID;
            rest.Up_service_dis(rest_privilege, rest_service1, begin, end, ID);
            MessageBox.Show("上传成功！");
            
        }

       

        
        //菜品8折
        private void checkBox3_Checked_1(object sender, RoutedEventArgs e)
        {
            common.rest.rest_privilege = 101;
        }

        //满200减50
        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            common.rest.rest_privilege = 102;
        }

        //积分折扣
        private void checkBox5_Checked(object sender, RoutedEventArgs e)
        {
            common.rest.rest_privilege = 103;
        }

        //送货上门
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            common.rest.rest_service = 1001;
        }

        //原料加工
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            common.rest.rest_service = 1002;
        }

        private void data_start_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            common.rest.begin_date = (DateTime)data_start.SelectedDate;

        }

        private void data_end_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            common.rest.end_date = (DateTime)data_end.SelectedDate;
        }

    }
}

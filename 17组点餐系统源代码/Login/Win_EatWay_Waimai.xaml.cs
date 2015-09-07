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
using System.Windows.Shapes;
using OrderSystemBLL;

namespace Login
{
    /// <summary>
    /// Win_EatWay_Waimai.xaml 的交互逻辑
    /// </summary>
    public partial class Win_EatWay_Waimai : Window
    {
        public Win_EatWay_Waimai()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        OrderBLL bll = new OrderBLL();

        

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            string add = comboBox2.Text;
            if (add == common.rest.rest_district)
            {
                int rest_id = common.ord.restaurant_ID;
                DateTime date = common.ord.order_date;
                string location = comboBox2.Text + textBox1.Text;
                bll.update_order_by_restID_and_date(rest_id, date, location);
                MessageBox.Show("您的订单已生成，正在等待餐厅接单！");
                this.Close();
            }
            else
            {
                MessageBox.Show("对不起，您的位置不在此餐厅配送范围内。");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}

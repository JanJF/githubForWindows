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
using OrderSystem.Model;
using System.Data;

namespace Login
{
    /// <summary>
    /// Win_comment.xaml 的交互逻辑
    /// </summary>
    public partial class Win_comment : Window
    {
        public Win_comment()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            label1.Content = get_rest_name();
            showComment();
        }
        OrderBLL bll = new OrderBLL();
        RestaurantBLL r_bll = new RestaurantBLL();

        private void btn_commit_Click(object sender, RoutedEventArgs e)
        {
            string comment = textBox1.Text;
            bll.Update_Restaurant_pass(comment, common.ord.ID);
            MessageBox.Show("上传成功");
            this.Close();
        }

        private string get_rest_name()
        {

            int rest_id;
            Restaurant rest = new Restaurant();
            DataTable dt = new DataTable();
            dt = bll.select_rest_ID_by_ord_ID(common.ord.ID);
            rest_id = int.Parse(dt.Rows[0]["restaurant_ID"].ToString());
            //name = order.restaurant_ID;
            rest = r_bll.Select_restaurant(rest_id);
            return rest.rest_name;
        }

        private void showComment()
        {
            DataTable dt = new DataTable();
            dt = bll.get_comment_by_ord_ID(common.ord.ID);
            textBox1.Text = dt.Rows[0]["order_description"].ToString();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}

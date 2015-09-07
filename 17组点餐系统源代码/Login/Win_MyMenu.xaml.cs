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
using System.Data;
using OrderSystem.DAL;
using OrderSystem.Model;
using OrderSystemBLL;

namespace Login
{
    /// <summary>
    /// Win_MyMenu.xaml 的交互逻辑
    /// </summary>
    public partial class Win_MyMenu : Window
    {
        OrderItem_InformationDAL oit_dal = new OrderItem_InformationDAL();
        DishDAL d_dal = new DishDAL();
        OrderItem_InformationBLL bll = new OrderItem_InformationBLL();
        OrderBLL o_bll = new OrderBLL();
        
        public Win_MyMenu()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            OrderDAL o_dal = new OrderDAL();
            RestaurantDAL r_dal = new RestaurantDAL();
            DataTable dt = new DataTable();
            List<Order> orders = o_dal.select_order_by_cus_id(common.cus.ID);

            Order ord = new Order();
            int count = orders.Count;
            dt = o_dal.select_order_by_cus_id_dt(common.cus.ID);
            dt.Columns.Add("order_restaurant", typeof(String));
            dt.Columns.Add("order_state_str", typeof(String));
            string order_state;
            for (int i = 0; i < count; i++)
            {
                dt.Rows[i]["order_restaurant"] = r_dal.select_restaurant(orders[i].restaurant_ID).rest_name;
                if (orders[i].order_state == 1)
                    order_state = "已接单";
                else
                    order_state = "未接单";
                dt.Rows[i]["order_state_str"] = order_state;
            }
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void orderitem(object sender, RoutedEventArgs e)
        {
            int order_id = Convert.ToInt32(((DataRowView)dataGrid1.CurrentItem).Row[0]);
            //MessageBox.Show(order_id.ToString());
            DataTable dt = oit_dal.select_orderitems_dt(order_id);
            List<OrderItem_Information> oits = new List<OrderItem_Information>();
            oits = oit_dal.select_orderitems(order_id);
            int count = oit_dal.select_orderitems(order_id).Count;
            dt.Columns.Add("dish_name", typeof(String));
            for (int i = 0; i < count; i++)
            {
                dt.Rows[i]["dish_name"] = d_dal.select_dish_by_ID(oits[i].dish_ID).dish_name;
            }
            dataGrid2.ItemsSource = dt.DefaultView;
        }

        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //跳转至评论
        public void CheckBox_Click(object sender, RoutedEventArgs e)
        {

            int order_id = Convert.ToInt32(((DataRowView)dataGrid1.CurrentItem).Row[0]);
            common.ord.ID = order_id;
            
            Win_comment Win_com = new Win_comment();
            Win_com.Show();
            this.Close();
        }
        public void cancel_order(object sender, RoutedEventArgs e)
        {
            int order_id = Convert.ToInt32(((DataRowView)dataGrid1.CurrentItem).Row[0]);
            if (bll.Delete_Orderitem(order_id))
                MessageBox.Show("删除菜单项成功");
            if (o_bll.Delete_Order(order_id))
                MessageBox.Show("删除菜单成功");
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

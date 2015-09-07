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
using System.Data;
using OrderSystem.DAL;
using OrderSystem.Model;
using OrderSystemBLL;

namespace Login.Page
{
    /// <summary>
    /// PageOrder.xaml 的交互逻辑
    /// </summary>
    public partial class PageOrder : System.Windows.Controls.Page
    {
        public PageOrder()
        {
            InitializeComponent();
            //初始化时需添加数据库访问加载以前的订单
            show_dishOrder();
        }

        DishDAL d_dal = new DishDAL();
        OrderDAL o_dal = new OrderDAL();
        OrderItem_InformationDAL oit_dal = new OrderItem_InformationDAL();
        CustomerBLL c_bll = new CustomerBLL();
        OrderBLL bll = new OrderBLL();

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //这里刷新时只显示新的订单，数据库应添加一个订单状态列
        }

        //根据菜单ID显示菜单
        private void show_dishOrder()
        {
            DataTable dt = o_dal.select_order_dt(common.rest.ID,0);
            List<Order> oder = new List<Order>();
            oder = o_dal.select_order_list(common.rest.ID, 0);
            int count = o_dal.select_order_list(common.rest.ID,0).Count;
            dt.Columns.Add("cus_telephone", typeof(String));
            //dt.Columns.Add("dish_amount",typeof(Int16));
            for (int i = 0; i < count; i++)
            {
                //int ID = o_dal.select_customer_phone(common.rest.ID, 0).customer_ID;
                dt.Rows[i]["cus_telephone"] = c_bll.Select_customer(oder[i].customer_ID).cus_telephone;     //ID从order_information中由restaurant_id和state
                //dt.Rows[i]["cus_telephone"] = common.cus.cus_telephone;
              //  dt.Rows[i]["dish_amount"]=
            }
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void Orderitem_Show(object sender, RoutedEventArgs e)
        {
            int order_id =Convert.ToInt16(((DataRowView)dataGrid1.CurrentItem).Row[0]);
            List<OrderItem_Information> oit = new List<OrderItem_Information>();
            DataTable dt = new DataTable();            
            dt = oit_dal.select_orderitems_dt(order_id);
            oit = oit_dal.select_orderitems(order_id);
            int count = oit.Count;
            int i = 0;
            dt.Columns.Add("dish_name",typeof(String));
            for (; i < count; i++)
            {
                dt.Rows[i]["dish_name"] = d_dal.select_dish_by_ID(oit[i].dish_ID).dish_name;
            }
            dataGrid2.ItemsSource = dt.DefaultView;
        }

        private void accept_order(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            int id=0;
            var bl = dg.IsChecked;
            if (bl == true)
            {
                id = int.Parse(((DataRowView)dataGrid1.CurrentItem).Row[0].ToString());
            }
            DataTable dt = (dataGrid1.ItemsSource as DataView).Table;
            if (bll.Update_Restaurant_pass(id))
                MessageBox.Show("接单成功");
            dataGrid1.ItemsSource = dt.DefaultView;
        }
    }
}

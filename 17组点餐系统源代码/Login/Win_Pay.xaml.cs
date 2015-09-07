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
    /// Win_Pay.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Pay : Window
    {
        OrderItem_InformationDAL oit_dal = new OrderItem_InformationDAL();
        DishDAL d_dal = new DishDAL();
        OrderDAL o_dal = new OrderDAL();
        CustomerBLL bll = new CustomerBLL();
        
        public Win_Pay()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            label6.Content = Convert.ToString(common.ord.actually_pay);
            label3.Content = Convert.ToString(common.ord.should_pay);
            if (common.ord.order_privilege == 101)
            {
                comboBox1.Items.Add("菜品8折优惠哦，亲！");
            }
            else if (common.ord.order_privilege == 102)
            {
                comboBox1.Items.Add("满200减50哦，亲！");
            }
            else if (common.ord.order_privilege == 103)
            {
                comboBox1.Items.Add("积分折扣，100积分抵10元哦！");
            }

            DataTable dt = oit_dal.select_orderitems_dt(common.ord.ID);
            List<OrderItem_Information> oits = new List<OrderItem_Information>();
            oits=oit_dal.select_orderitems(common.ord.ID);
            int count = oit_dal.select_orderitems(common.ord.ID).Count;
            dt.Columns.Add("dish_name",typeof(String));
            for (int i = 0; i < count; i++)
            {
                dt.Rows[i]["dish_name"] = d_dal.select_dish_by_ID(oits[i].dish_ID).dish_name;
            }
                dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Win_EatWay_InRes inres = new Win_EatWay_InRes();
            inres.Show();
            if (comboBox1.Text == "积分折扣，100积分抵10元哦！")
                common.cus.cus_score = 0;
            if(common.cus.ID!=0)
                common.cus.cus_score += Convert.ToInt32(Convert.ToDouble(label6.Content)/10);
            bll.Update_customer_score(common.cus.ID, common.cus.cus_score);
            this.Close();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Win_EatWay_Waimai waimai = new Win_EatWay_Waimai();
            waimai.Show();
            this.Close();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = comboBox1.SelectedItem as ComboBoxItem;
            if (comboBox1.SelectedItem.ToString() == "菜品8折优惠哦，亲！")
            {
                common.ord.actually_pay = common.ord.should_pay * (float)0.8;
            }
            else if (comboBox1.SelectedItem.ToString() == "满200减50哦，亲！")
            {
                if (common.ord.should_pay > 200)
                    common.ord.actually_pay = common.ord.should_pay - 50;
            }
            else if (comboBox1.SelectedItem.ToString() == "积分折扣，100积分抵10元哦！")
            {
                MessageBox.Show("您有积分:" + Convert.ToString(common.cus.cus_score));
                common.ord.actually_pay = common.ord.should_pay - (float)0.1 * common.cus.cus_score;

            }
            else if (item.Content.ToString() == "无" )
                common.ord.actually_pay = common.ord.should_pay;
            label6.Content = Convert.ToString(common.ord.actually_pay);
            o_dal.Update_order(common.ord,common.ord.ID);
        }
    }
}

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
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;
using System.IO;
using OrderSystemBLL;



namespace Login
{
    /// <summary>
    /// Win_more_dish.xaml 的交互逻辑
    /// </summary>

        public partial class Win_more_dish : Window
    {
          
        DishDAL d_dal = new DishDAL();
        OrderDAL o_dal = new OrderDAL();
        RestaurantBLL r_bll = new RestaurantBLL();
        List<Dish> dishes = new List<Dish>();
        PictureDAL p_dal = new PictureDAL();
        int count;
        //int n = 0;
        //int price = 0;
        //int total_prce;
        OrderItem_InformationDAL oit_dal=new OrderItem_InformationDAL();
        OrderItem_Information ordit = new OrderItem_Information();
        static int dish_id;
        static int button_times = 1;
        //static int add_or_not=0;

        public BitmapImage picture_show(int pic_style, int pic_owner)
        {
            Picture pic = new Picture();
            pic = p_dal.select_picture(pic_style, pic_owner);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(pic.image);
            image.EndInit();
            return image;
        }
        
        public Win_more_dish()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dishes = d_dal.select_dish(common.rest.ID);
            count = dishes.Count;
            DataTable dt = d_dal.select_dish_dt(common.rest.ID);
            dt.Columns.Add("dish_style", typeof(string));
            for (int i = 0; i < count; i++)
            {
                if ((int)dt.Rows[i]["dish_type"] == 1)
                    dt.Rows[i]["dish_style"] = "特色菜";
                else
                    dt.Rows[i]["dish_style"] = "非特色菜";
            }
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void Dish_Choose(object sender, MouseEventArgs e)
        {
            dish_id = Convert.ToInt16(((DataRowView)dataGrid1.CurrentItem).Row[0]);
            //MessageBox.Show(dish_id.ToString());
            image1.Source = picture_show(1, dish_id);
            lab_name.Content = d_dal.select_dish_by_ID(dish_id).dish_name;
            lab_price.Content = d_dal.select_dish_by_ID(dish_id).dish_price;
            lab_count.Content = "0";
            lab_total_price.Content = "0";
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        //添加菜，按钮变蓝
        private void mouse_down_add(object sender, RoutedEventArgs e)
        {
            if (image1.Source == null)
                MessageBox.Show("请选择菜色");
            else
            {
                tb_add.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                //n++;
                lab_count.Content = Convert.ToInt16(lab_count.Content) + 1;
                lab_total_price.Content = Convert.ToInt16(lab_total_price.Content) + Convert.ToInt16(lab_price.Content);
                //lab_total_price.Content = price;
                lab_all.Content = Convert.ToInt16(lab_all.Content) + Convert.ToInt16(lab_price.Content);
            }
        }
        //按钮变黑
        private void mouse_up_add(object sender, MouseButtonEventArgs e)
        {
            tb_add.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub(object sender, RoutedEventArgs e)
        {
            if (image1.Source == null)
                MessageBox.Show("请选择菜色");
            else
            {
                if (Convert.ToInt16(lab_count.Content) > 0)
                {
                    tb_sub.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                    //n--;
                    lab_count.Content = Convert.ToInt16(lab_total_price.Content) - Convert.ToInt16(lab_price.Content);
                    lab_total_price.Content = Convert.ToInt16(lab_total_price.Content) - Convert.ToInt16(lab_price.Content);
                    //lab_total_price.Content = price;
                    lab_all.Content = Convert.ToInt16(lab_all.Content) - Convert.ToInt16(lab_price.Content);
                }
                else
                    MessageBox.Show("您还未选择该菜");
            }

        }
        //按钮变黑
        private void mouse_up_sub(object sender, MouseButtonEventArgs e)
        {
            tb_sub.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        public void Make_Orderitem()
        {
            ordit.order_ID = common.ord.ID;
            ordit.dish_ID = dish_id; ;
            ordit.dish_amount = Convert.ToInt32(lab_count.Content);
            ordit.total_pay = (float)Convert.ToDouble(lab_total_price.Content);
            oit_dal.Add_orderitem(ordit);
        }

        public void Make_Order()
        {
            DataTable dt;
            dt = r_bll.Load_Service_dis(common.rest.ID);
            //Order ord = new Order();
            common.ord.customer_ID = common.cus.ID;
            common.ord.restaurant_ID = common.rest.ID;
            common.ord.should_pay = 0;
            common.ord.order_privilege = (int)dt.Rows[0]["rest_privilege"];
            common.ord.actually_pay = common.ord.should_pay;
            common.ord.score_use = 0;
            common.ord.order_description = "";
            common.ord.order_date = DateTime.Now;
            common.ord.order_state = 0;
            common.ord.meal_state = 0;
            common.ord.order_location = "";
            o_dal.Add_order(common.ord);
            common.ord = o_dal.select_order_by_restID_and_date(common.ord.restaurant_ID, common.ord.order_date);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (image1.Source == null)
                MessageBox.Show("请选择菜色");
            else
            {
                if (lab_all.Content.ToString() == "0")
                    MessageBox.Show("请选择菜色");
                else
                {
                    if (button_times == 1)
                    {
                        Make_Order();
                        Make_Orderitem();
                        //MessageBox.Show("成功吗？");
                    }
                    else
                    {
                        Make_Orderitem();
                    }
                    button_times++;
                    MessageBox.Show("加入成功");
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (lab_all.Content.ToString() == "0")
                MessageBox.Show("您未选择任何菜品");
            else if (button_times == 1)
            {
                MessageBox.Show("您未选择任何菜品");
            }
            else
            {
                common.ord.should_pay = common.ord.actually_pay = (float)Convert.ToDouble(lab_all.Content);
                common.ord.order_date = DateTime.Now;
                o_dal.Update_order(common.ord, common.ord.ID);
                button_times = 1;
                lab_all.Content = "0";
                Win_Pay win_pay = new Win_Pay();
                win_pay.Show();
            }
        }
    }
}

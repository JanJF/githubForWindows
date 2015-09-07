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
using System.IO;
using System.Data;
using OrderSystemBLL;

namespace Login
{
    /// <summary>
    /// Win_Owner1.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class Win_Owner1 : Window
    {
        int n=0;
        int price = 0;
        PictureDAL p_dal = new PictureDAL();
        List<Dish> dishes1 = new List<Dish>();
        List<Dish> dishes0 = new List<Dish>();
        DishDAL d_dal = new DishDAL();
        OrderDAL o_dal = new OrderDAL();
        OrderItem_InformationDAL oit_dal = new OrderItem_InformationDAL();
        CustomerDAL c_dal = new CustomerDAL();

        RestaurantBLL bll = new RestaurantBLL();

        

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


        public Win_Owner1()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            tb_show();
            this.lab_resNameel1.Content = common.rest.rest_name;
            dishes1 = d_dal.select_dish1_By_dish_restaurant(common.rest.ID);
            dishes0 = d_dal.select_dish0_By_dish_restaurant(common.rest.ID);
            int count1 = dishes1.Count;
            int count0 = dishes0.Count;
            int i=0;
            //if(o_dal.select_order_by_rest_id(common.rest.ID).Count!=0)
            Description_Show();
            LB_address_show.Content = common.rest.rest_district+" "+common.rest.rest_location;
            if (i < 3&&i<count1)
            {
                image1.Source = picture_show(1,dishes1[i].ID);
                label14.Content = dishes1[i].dish_name;
                label1.Content = dishes1[i].dish_price.ToString();
                i++;
            }
            if (i < 3 && i < count1)
            {
                image2.Source = picture_show(1, dishes1[i].ID);
                label15.Content = dishes1[i].dish_name;
                label2.Content = dishes1[i].dish_price.ToString();
                i++;
            }
            if (i < 3 && i < count1)
            {
                image3.Source = picture_show(1, dishes1[i].ID);
                label16.Content = dishes1[i].dish_name;
                label13.Content = dishes1[i].dish_price.ToString();
                i++;
            }
            i = 0;
            if (i < 6 && i < count0)
            {
                image4.Source = picture_show(1, dishes0[i].ID);
                label19.Content = dishes0[i].dish_name;
                label20.Content = dishes0[i].dish_price.ToString();
                i++;
            }
            if (i < 6 && i < count0)
            {
                image5.Source = picture_show(1, dishes0[i].ID);
                label21.Content = dishes0[i].dish_name;
                label22.Content = dishes0[i].dish_price.ToString();
                i++;
            }
            if (i < 6 && i < count0)
            {
                image6.Source = picture_show(1, dishes0[i].ID);
                label29.Content = dishes0[i].dish_name;
                label30.Content = dishes0[i].dish_price.ToString();
                i++;
            }
            if (i < 6 && i < count0)
            {
                image7.Source = picture_show(1, dishes0[i].ID);
                label23.Content = dishes0[i].dish_name;
                label24.Content = dishes0[i].dish_price.ToString();
                i++;
            }
            if (i < 6 && i < count0)
            {
                image8.Source = picture_show(1, dishes0[i].ID);
                label25.Content = dishes0[i].dish_name;
                label26.Content = dishes0[i].dish_price.ToString();
                i++;
            }
            if (i < 6 && i < count0)
            {
                image9.Source = picture_show(1, dishes0[i].ID);
                label27.Content = dishes0[i].dish_name;
                label28.Content = dishes0[i].dish_price.ToString();
                i++;
            }

            int id = common.rest.ID;
            Load_dis_ser(id);

        }




        private void mouse_down(object sender, MouseButtonEventArgs e)
        {
            tB_add1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label1.Content);
            lab_price.Content = price;
           
            //dishcount.DishCount1 = Convert.ToInt16(lab_count1.Content);
            common.dishcount[0]++;
            lab_count1.Content = common.dishcount[0];
        }

        private void mouse_up(object sender, MouseButtonEventArgs e)
        {
            tB_add1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            
        }
        
        private void mouse_down_sub1(object sender, RoutedEventArgs e)
        {
            tB_sub1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            if (n > 0 && common.dishcount[0] > 0)
            {
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label2.Content);
                lab_price.Content = price;
                common.dishcount[0]--;
                lab_count1.Content = common.dishcount[0];
            }
            else
                MessageBox.Show("您还未选择过本菜");
        }

        private void mouse_up_sub1(object sender, MouseButtonEventArgs e)
        {
            tB_sub1.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //添加菜，按钮变蓝
        private void mouse_down_add2(object sender, RoutedEventArgs e)
        {
            tB_add2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label2.Content);
            lab_price.Content = price;

            common.dishcount[1]++;
            lab_count2.Content = common.dishcount[1];
        }
        //按钮变黑
        private void mouse_up_add2(object sender, MouseButtonEventArgs e)
        {
            tB_add2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub2(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[1] > 0)
            {
                tB_sub2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label2.Content);
                lab_price.Content = price;

                common.dishcount[1]--;
                lab_count2.Content = common.dishcount[1];
            }
            else
                MessageBox.Show("您还未选择过本菜");

        }
        //按钮变黑
        private void mouse_up_sub2(object sender, MouseButtonEventArgs e)
        {
            tB_sub2.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //添加菜，按钮变蓝
        private void mouse_down_add3(object sender, RoutedEventArgs e)
        {
            tB_add3.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label13.Content);
            lab_price.Content = price;

            //本菜的数量
            common.dishcount[2]++;
            lab_count3.Content = common.dishcount[2];
        }
        //按钮变黑
        private void mouse_up_add3(object sender, MouseButtonEventArgs e)
        {
            tB_add3.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub3(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[2] > 0)
            {
                tB_sub3.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label13.Content);
                lab_price.Content = price;

                common.dishcount[2]--;
                lab_count3.Content = common.dishcount[2];
            }
            else
                MessageBox.Show("您还为选择过本菜");
        }
        //按钮变黑
        private void mouse_up_sub3(object sender, MouseButtonEventArgs e)
        {
            tB_sub3.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //添加菜，按钮变蓝
        private void mouse_down_add4(object sender, RoutedEventArgs e)
        {
            tB_add4.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label20.Content);
            lab_price.Content = price;
            //本菜的数量
            common.dishcount[3]++;
            lab_count4.Content = common.dishcount[3];
        }
        //按钮变黑
        private void mouse_up_add4(object sender, MouseButtonEventArgs e)
        {
            tB_add4.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub4(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[3] > 0)
            {
                tB_sub4.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label20.Content);
                lab_price.Content = price;

                common.dishcount[3]--;
                lab_count4.Content = common.dishcount[3];
            }
            else
                MessageBox.Show("您还未选择该菜");
        }
        //按钮变黑
        private void mouse_up_sub4(object sender, MouseButtonEventArgs e)
        {
            tB_sub4.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //添加菜，按钮变蓝
        private void mouse_down_add5(object sender, RoutedEventArgs e)
        {
            tB_add5.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label22.Content);
            lab_price.Content = price;

            //本菜的数量
            common.dishcount[4]++;
            lab_count5.Content = common.dishcount[4];
        }
        //按钮变黑
        private void mouse_up_add5(object sender, MouseButtonEventArgs e)
        {
            tB_add5.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub5(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[4] > 0)
            {
                tB_sub5.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label22.Content);
                lab_price.Content = price;

                common.dishcount[4]--;
                lab_count5.Content = common.dishcount[4];
            }
            else
                MessageBox.Show("您还未选择该菜");
        }
        //按钮变黑
        private void mouse_up_sub5(object sender, MouseButtonEventArgs e)
        {
            tB_sub5.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //添加菜，按钮变蓝
        private void mouse_down_add6(object sender, RoutedEventArgs e)
        {
            tB_add6.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label30.Content);
            lab_price.Content = price;
            //本菜的数量
            common.dishcount[5]++;
            lab_count6.Content = common.dishcount[5];
        }
        //按钮变黑
        private void mouse_up_add6(object sender, MouseButtonEventArgs e)
        {
            tB_add6.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub6(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[5] > 0)
            {
                tB_sub6.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label30.Content);
                lab_price.Content = price;

                common.dishcount[5]--;
                lab_count6.Content = common.dishcount[5];
            }
            else
                MessageBox.Show("您还未选择该菜");
        }
        //按钮变黑
        private void mouse_up_sub6(object sender, MouseButtonEventArgs e)
        {
            tB_sub6.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }


        //添加菜，按钮变蓝
        private void mouse_down_add7(object sender, RoutedEventArgs e)
        {
            tB_add7.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label24.Content);
            lab_price.Content = price;
            //本菜的数量
            common.dishcount[6]++;
            lab_count7.Content = common.dishcount[6];
        }
        //按钮变黑
        private void mouse_up_add7(object sender, MouseButtonEventArgs e)
        {
            tB_add7.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub7(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[6] > 0)
            {
                tB_sub7.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label24.Content);
                lab_price.Content = price;

                common.dishcount[6]--;
                lab_count7.Content = common.dishcount[6];
            }
            else
                MessageBox.Show("您还未选择该菜");
        }
        //按钮变黑
        private void mouse_up_sub7(object sender, MouseButtonEventArgs e)
        {
            tB_sub7.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }


        //添加菜，按钮变蓝
        private void mouse_down_add8(object sender, RoutedEventArgs e)
        {
            tB_add8.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label26.Content);
            lab_price.Content = price;
            //本菜的数量
            common.dishcount[7]++;
            lab_count8.Content = common.dishcount[7];
        }
        //按钮变黑
        private void mouse_up_add8(object sender, MouseButtonEventArgs e)
        {
            tB_add8.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub8(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[7] > 0)
            {
                tB_sub8.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label26.Content);
                lab_price.Content = price;

                common.dishcount[7]--;
                lab_count8.Content = common.dishcount[7];
            }
            else
                MessageBox.Show("您还未选择该菜");

        }
        //按钮变黑
        private void mouse_up_sub8(object sender, MouseButtonEventArgs e)
        {
            tB_sub8.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }


        //添加菜，按钮变蓝
        private void mouse_down_add9(object sender, RoutedEventArgs e)
        {
            tB_add9.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            n++;
            label6.Content = n;
            price += Convert.ToInt16(label28.Content);
            lab_price.Content = price;
            //本菜的数量
            common.dishcount[8]++;
            lab_count9.Content = common.dishcount[8];
        }
        //按钮变黑
        private void mouse_up_add9(object sender, MouseButtonEventArgs e)
        {
            tB_add9.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        //减少菜，按钮变蓝
        private void mouse_down_sub9(object sender, RoutedEventArgs e)
        {
            if (n > 0 && common.dishcount[8] > 0)
            {
                tB_sub9.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                n--;
                label6.Content = n;
                price -= Convert.ToInt16(label28.Content);
                lab_price.Content = price;

                common.dishcount[8]--;
                lab_count9.Content = common.dishcount[8];
            }
            else
                MessageBox.Show("您还未选择该菜");

        }
        //按钮变黑
        private void mouse_up_sub9(object sender, MouseButtonEventArgs e)
        {
            tB_sub9.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }


        

        

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (common.cus.ID == 0)
                MessageBox.Show("请先注册");
            else if (label6.Content.ToString() == "" || label6.Content.ToString() == "0")
                MessageBox.Show("你还未选择任何菜品");
            else
            {
                Made_Order();
                Win_Pay pay = new Win_Pay();
                pay.Show();
            }

        }

        private void image2_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mouse_change(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void mouse_hand(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void mouse_click(object sender, MouseEventArgs e)
        {
            if (common.cus.ID == 0)
                MessageBox.Show("请先注册");
            else
            {
                Win_more_dish more_dish = new Win_more_dish();
                more_dish.Show();
            }
        }


        private void mouse_change1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void mouse_hand1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void mouse_click1(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("点了");
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }


        //从数据库取得优惠信息
        private void Load_dis_ser(int id)
        {
            DataTable dt;
            id = common.rest.ID;
            dt = bll.Load_Service_dis(id);
            string service;
            string privilege;
            privilege = Convert.ToString( dt.Rows[0]["rest_privilege"]);
            if (privilege == "101")
                privilege = "菜品8折优惠哦，亲！";
            else if (privilege == "102")
                privilege = "满200减50哦，亲！";
            else if (privilege == "103")
                privilege = "积分折扣，100积分抵10元哦！";
            else
                privilege = "餐厅暂无优惠";
            service = Convert.ToString( dt.Rows[0]["rest_service"]);
            if (service == "1001")
                service = "本店支持送货上门哦，亲！";
            else if (service == "1002")
                service = "若本店无亲喜欢的菜，您可自带原料本店可以帮你烧哦";
            //MessageBox.Show(privilege);
            label_dis.Content = privilege;
            label_ser.Content = service;
        }

        //生成订单
        public void Made_Order()
        {
            DataTable dt;
            dt = bll.Load_Service_dis(common.rest.ID);
            //Order ord = new Order();
            common.ord.customer_ID = common.cus.ID;
            common.ord.restaurant_ID = common.rest.ID;
            common.ord.should_pay = Convert.ToInt32(lab_price.Content);
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
            OrderItem_Information ordit = new OrderItem_Information();
            if (lab_count1.Content.ToString() != ""&&lab_count1.Content.ToString()!="0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes1[0].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count1.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label1.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count2.Content.ToString() != "" && lab_count2.Content.ToString() != "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes1[1].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count2.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label2.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count3.Content.ToString() != "" && lab_count3.Content.ToString() != "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes1[2].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count3.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label13.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count4.Content.ToString() != "" && lab_count4.Content.ToString() != "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes0[0].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count4.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label20.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count5.Content.ToString() != "" && lab_count5.Content.ToString()!= "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes0[1].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count5.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label22.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count6.Content.ToString() != "" && lab_count6.Content.ToString()!= "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes0[2].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count6.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label24.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count7.Content.ToString() != "" && lab_count7.Content.ToString()!= "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes0[3].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count7.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label24.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count8.Content.ToString() != "" && lab_count8.Content.ToString()!= "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes0[4].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count8.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label26.Content);
                oit_dal.Add_orderitem(ordit);
            }
            if (lab_count9.Content.ToString() != "" && lab_count9.Content.ToString()!= "0")
            {
                ordit.order_ID = common.ord.ID;
                ordit.dish_ID = dishes0[5].ID;
                ordit.dish_amount = Convert.ToInt32(lab_count9.Content);
                ordit.total_pay = ordit.dish_amount * (float)Convert.ToDouble(label28.Content);
                oit_dal.Add_orderitem(ordit);
            }
        }
        //TextBox控件显示
        public void tb_show()
        {
            dishes1 = d_dal.select_dish1_By_dish_restaurant(common.rest.ID);
            dishes0 = d_dal.select_dish0_By_dish_restaurant(common.rest.ID);
            int count1 = dishes1.Count;
            int count0 = dishes0.Count;
            tB_add1.Visibility = Visibility.Hidden;
            tB_add2.Visibility = Visibility.Hidden;
            tB_add3.Visibility = Visibility.Hidden;
            tB_add4.Visibility = Visibility.Hidden;
            tB_add5.Visibility = Visibility.Hidden;
            tB_add9.Visibility = Visibility.Hidden;
            tB_add6.Visibility = Visibility.Hidden;
            tB_add7.Visibility = Visibility.Hidden;
            tB_add8.Visibility = Visibility.Hidden;
            tB_add9.Visibility = Visibility.Hidden;
            tB_sub1.Visibility = Visibility.Hidden;
            tB_sub2.Visibility = Visibility.Hidden;
            tB_sub3.Visibility = Visibility.Hidden;
            tB_sub4.Visibility = Visibility.Hidden;
            tB_sub5.Visibility = Visibility.Hidden;
            tB_sub6.Visibility = Visibility.Hidden;
            tB_sub7.Visibility = Visibility.Hidden;
            tB_sub8.Visibility = Visibility.Hidden;
            tB_sub9.Visibility = Visibility.Hidden;
            if (count1 >= 1)
            {
                tB_add1.Visibility = Visibility.Visible;
                tB_sub1.Visibility = Visibility.Visible;
            }
            if (count1 >= 2)
            {
                tB_add2.Visibility = Visibility.Visible;
                tB_sub2.Visibility = Visibility.Visible;
            }
            if (count1 >= 3)
            {
                tB_add3.Visibility = Visibility.Visible;
                tB_sub3.Visibility = Visibility.Visible;
            }
            if (count0 >= 1)
            {
                tB_add4.Visibility = Visibility.Visible;
                tB_sub4.Visibility = Visibility.Visible;
            }
            if (count0 >= 2)
            {
                tB_add5.Visibility = Visibility.Visible;
                tB_sub5.Visibility = Visibility.Visible;
            }
            if (count0 >= 3)
            {
                tB_add6.Visibility = Visibility.Visible;
                tB_sub6.Visibility = Visibility.Visible;
            }
            if (count0 >= 4)
            {
                tB_add9.Visibility = Visibility.Visible;
                tB_sub9.Visibility = Visibility.Visible;
            }
            if (count0 >= 5)
            {
                tB_add7.Visibility = Visibility.Visible;
                tB_sub7.Visibility = Visibility.Visible;
            }
            if (count0 >= 6)
            {
                tB_add8.Visibility = Visibility.Visible;
                tB_sub8.Visibility = Visibility.Visible;
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void Description_Show()
        {
            DataTable dt = new DataTable();
            List<Order> orders = new List<Order>();
            dt = o_dal.select_order_by_rest_id_dt(common.rest.ID);
            if (dt.Rows.ToString() != null)
            {
                orders = o_dal.select_order_by_rest_id(common.rest.ID);
                int count = orders.Count;
                dt.Columns.Add("cus_name", typeof(String));
                for (int i = 0; i < count; i++)
                {
                    dt.Rows[i]["cus_name"] = c_dal.select_customer(orders[i].customer_ID).cus_nickname;
                }
                dataGrid1.ItemsSource = dt.DefaultView;
            }
            else
                ;
        }

    }
}

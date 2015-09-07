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
using OrderSystem.DAL;
using OrderSystem.Model;
using System.IO;

namespace Login
{
    /// <summary>
    /// Win_Cus_logined.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Cus_logined : Window
    {
        static RestaurantBLL bll = new RestaurantBLL();
        static RestaurantDAL r_dal = new RestaurantDAL();
        PictureDAL p_dal = new PictureDAL();
        PictureBLL p_bll = new PictureBLL();
        static DishDAL d_dal = new DishDAL();
        static DishBLL d_bll = new DishBLL();
        Restaurant rest = new Restaurant();

        public const int s_district = 21;
        public const int s_restaurant = 22;
        public const int s_dish = 23;


        public int search = 20;
        public int district;


        List<Dish> dishes = d_dal.select_top_dish();
        List<Restaurant> rests = r_dal.select_top_restaurant();
        
        public Win_Cus_logined()
        {
            InitializeComponent();
            this.lab_User.Content = common.cus.cus_nickname;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            image1.Source = picture_show(1, dishes[0].ID);
            label2.Content = d_bll.select_dish_by_ID(dishes[0].ID).dish_name;
            image2.Source = picture_show(1, dishes[1].ID);
            label4.Content = d_bll.select_dish_by_ID(dishes[1].ID).dish_name;
            image3.Source = picture_show(1, dishes[2].ID);
            label6.Content = d_bll.select_dish_by_ID(dishes[2].ID).dish_name;
            image4.Source = picture_show(2, rests[0].ID);
            label10.Content = bll.select_restaurant(rests[0].ID).rest_name;
            image5.Source = picture_show(2, rests[1].ID);
            label12.Content = bll.select_restaurant(rests[1].ID).rest_name;
            image6.Source = picture_show(2, rests[2].ID);
            label14.Content = bll.select_restaurant(rests[2].ID).rest_name;
        }

        //图片显示
        public BitmapImage picture_show(int pic_style, int pic_owner)
        {
            Picture pic = new Picture();
            pic = p_bll.select_picture(pic_style, pic_owner);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(pic.image);
            image.EndInit();
            return image;
        }

        private void bt_myMenu_Click(object sender, RoutedEventArgs e)
        {
            Win_MyMenu menu = new Win_MyMenu();
            menu.Show();
        }


        private void img1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //点此进入该菜品商家详细页面
            rest = bll.select_restaurant(dishes[0].dish_restaurant);
            common.rest = rest;
            common.rest_search = bll.select_restaurant(dishes[0].dish_restaurant).rest_name;
            Win_Owner1 win_owner = new Win_Owner1();
            win_owner.Show();

        }

        private void img2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //点此进入该菜品商家详细页面
            rest = bll.select_restaurant(dishes[1].dish_restaurant);
            common.rest = rest;
            common.rest_search = bll.select_restaurant(dishes[1].dish_restaurant).rest_name;
            Win_Owner1 win_owner = new Win_Owner1();
            win_owner.Show();

        }

        private void img3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //点此进入该菜品商家详细页面
            rest = bll.select_restaurant(dishes[2].dish_restaurant);
            common.rest = rest;
            common.rest_search = bll.select_restaurant(dishes[2].dish_restaurant).rest_name;
            Win_Owner1 win_owner = new Win_Owner1();
            win_owner.Show();

        }

        private void img4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //点此进入该菜品商家详细页面
            rest = rests[0];
            common.rest = rest;
            common.rest_search = rests[0].rest_name;
            Win_Owner1 win_owner = new Win_Owner1();
            win_owner.Show();

        }

        private void img5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //点此进入该菜品商家详细页面
            rest = rests[1];
            common.rest = rest;
            common.rest_search = rests[1].rest_name;
            Win_Owner1 win_owner = new Win_Owner1();
            win_owner.Show();

        }

        private void img6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //点此进入该菜品商家详细页面
            rest = rests[2];
            common.rest = rest;
            common.rest_search = rests[2].rest_name;
            Win_Owner1 win_owner = new Win_Owner1();
            win_owner.Show();

        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwin = new MainWindow();
            mwin.Show();
            this.Close();
            
        }


        //用户查看自己信息

        private void UserLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Win_User_Info userInfo = new Win_User_Info();
            userInfo.Show();
        }

        private void mouse_hand(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void mouse_arrows(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void ima_mouse_hand(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ima_mouse_arrow(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void bt_Wsearch_Click(object sender, RoutedEventArgs e)
        {
            if (search == 20)
            {
                MessageBox.Show("请选择查询类型");
            }
            else
            {
                Restaurant rest = new Restaurant();
                List<Restaurant> rests = new List<Restaurant>();
                common.search_style = search;
                if (search == s_district)
                {
                    string rest_district = tb_WSearch.Text;
                    common.rest_search = rest_district;
                    Win_Search_location seaByLocation = new Win_Search_location();
                    seaByLocation.Show();
                }
                else if (search == s_restaurant)
                {
                    string rest_name = tb_WSearch.Text;
                    common.rest_search = rest_name;
                    Win_Search_location seaByLocation = new Win_Search_location();
                    seaByLocation.Show();
                }
                else if (search == s_dish)
                {
                    string dish_name = tb_WSearch.Text;
                    common.rest_search = dish_name;
                    Win_Search_location seaByLocation = new Win_Search_location();
                    seaByLocation.Show();
                }
            }
        }

        private void radioButton1_Checked_1(object sender, RoutedEventArgs e)
        {
            search = s_district;
        }

        private void radioButton2_Checked_1(object sender, RoutedEventArgs e)
        {
            search = s_restaurant;

        }

        private void radioButton3_Checked_1(object sender, RoutedEventArgs e)
        {
            search = s_dish;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void All_Rest_Show(object sender, MouseEventArgs e)
        {
            Win_All_Rest_Show win_all_rest_show = new Win_All_Rest_Show();
            win_all_rest_show.Show();
        }
    }
}

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
using System.IO;
using System.Threading.Tasks;
using Microsoft.Win32;
using OrderSystem.DAL;
//using OrderSystem.Model;


namespace Login
{
    /// <summary>
    /// Win_Owner_sign.xaml 的交互逻辑
    /// </summary>
    
    public partial class Win_Owner_sign : Window
    {

        PictureDAL dal = new PictureDAL();
        //RestaurantBLL dll = new RestaurantBLL();
        SeatsBLL s_bll = new SeatsBLL();

        public int WuYouHui = 100;


        public const int WaiMai = 1001;
        public const int WuWaiMai = 1002;


        public const int WeiShenHe = 0;


        public const int seat2 = 100001;
        public const int seat4 = 100002;
        public const int seat8 = 100003;
        public const int seat12 = 100004;


        RestaurantBLL bll = new RestaurantBLL();
        RestaurantDAL r_dal = new RestaurantDAL();
        List<Restaurant> rests = new List<Restaurant>();
        Restaurant rest = new Restaurant();
        Picture pic = new Picture();
        int serve=1000;
        public Win_Owner_sign()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            serve = WaiMai;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            serve = WuWaiMai;
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入小店名称。");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入密码。");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("请确认密码。");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("请输入验证问题。");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("请输入答案。");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("请输入小店描述。");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("请输入2人桌总数。");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("请输入4人桌总数。");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("请输入8人桌总数。");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("请输入12人桌总数。");
            }
            else if (textBox12.Text == "")
            {
                MessageBox.Show("请输入手机号。");
            }
            else if (textBox13.Text == "")
            {
                MessageBox.Show("请输入对外联系方式。");
            }
            else if (textBox14.Text == "")
            {
                MessageBox.Show("请输入详细地址。");
            }
            else if (serve == 1000)
            {
                MessageBox.Show("请选择是否配送外卖。");
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("密码输入错误，请重新输入密码");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("请输入图片");
            }
            else if (textBox12.Text.Length != 11)
            {
                MessageBox.Show("手机号码位数不正确，轻松重新输入");
                textBox12.Clear();
            }
            else
            {
                rests = r_dal.GetAllRestaurant();
                int amount = rests.Count;
                int j = 0;
                while (j < amount)
                {
                    if (textBox12.Text == rests[j].rest_telephone)
                    {
                        MessageBox.Show("该手机号已被注册，请重新输入");
                        break;
                    }
                    j++;
                }
                if (j == amount)
                {
                    rest.rest_name = textBox1.Text;
                    rest.rest_password = textBox2.Text;
                    rest.rest_question = textBox4.Text;
                    rest.rest_answer = textBox5.Text;
                    rest.rest_description = textBox6.Text;
                    rest.rest_telephone = textBox12.Text;
                    rest.rest_homephone = textBox13.Text;
                    rest.rest_location = textBox14.Text;
                    rest.rest_service = serve;
                    rest.rest_privilege = WuYouHui;
                    rest.begin_date = DateTime.Now;
                    rest.end_date = DateTime.Now;
                    rest.rest_state = WeiShenHe;
                    rest.rest_district = comboBox2.Text;
                    if (bll.Add_restaurant(rest))
                    {
                        int count = bll.GetAllRestaurant().Count;
                        List<Restaurant> restaurants = new List<Restaurant>();
                        restaurants = bll.GetAllRestaurant();
                        int i = 0;
                        while (i < count)
                        {
                            if (textBox12.Text == restaurants[i].rest_telephone)
                            {
                                if (textBox2.Text == restaurants[i].rest_password)
                                {
                                    common.rest = restaurants[i];
                                    break;
                                }

                            }
                            i++;
                        }
                        pic.pic_style = 2;                  //2
                        pic.pic_owner = common.rest.ID;
                        dal.Add_picture(pic);               //加入pic数据库
                        MessageBox.Show("添加成功");
                        restaurants = bll.GetAllRestaurant();
                        count = bll.GetAllRestaurant().Count;
                        for (i = 1; i < count; i++)
                        {
                            if (common.rest.rest_telephone == restaurants[i].rest_telephone)
                            {
                                common.rest = restaurants[i];
                                break;
                            }
                        }
                        Seats se = new Seats();
                        if (textBox8.Text != "")
                        {
                            se.restaurant_ID = common.rest.ID;
                            se.seat_style = seat2;
                            se.seat_all = Convert.ToInt16(textBox8.Text);
                            se.seat_use = 0;
                            s_bll.Add_Seat(se);
                        }
                        if (textBox9.Text != "")
                        {
                            se.restaurant_ID = common.rest.ID;
                            se.seat_style = seat4;
                            se.seat_all = Convert.ToInt32(textBox9.Text);
                            se.seat_use = 0;
                            s_bll.Add_Seat(se);
                        }
                        if (textBox10.Text != "")
                        {
                            se.restaurant_ID = common.rest.ID;
                            se.seat_style = seat8;
                            se.seat_all = Convert.ToInt16(textBox10.Text);
                            se.seat_use = 0;
                            s_bll.Add_Seat(se);
                        }
                        if (textBox11.Text != "")
                        {
                            se.restaurant_ID = common.rest.ID;
                            se.seat_style = seat12;
                            se.seat_all = Convert.ToInt16(textBox11.Text);
                            se.seat_use = 0;
                            s_bll.Add_Seat(se);
                        }
                        Win_Owner1 win_owner = new Win_Owner1();
                        win_owner.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
            }
        }

        private void textBox12_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        //上传照片
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Photo = new OpenFileDialog();
            Photo.Filter = "jpg图片|*.jpg|png图片|*.png";
            if (Photo.ShowDialog() == true)
            {
                string filename = Photo.FileName;
                textBox7.Text = filename;
                //pic = (Picture)picture.DataContext;
                byte[] img = File.ReadAllBytes(filename);
                pic.image = img;
            }
        }

        private void radioButton1_Checked_1(object sender, RoutedEventArgs e)
        {
            serve = WaiMai;
        }

        private void radioButton2_Checked_1(object sender, RoutedEventArgs e)
        {
            serve = WuWaiMai;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mWin = new MainWindow();
            mWin.Show();
           this.Close();
        }
    }
}

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

namespace Login
{
    /// <summary>
    /// Win_login.xaml 的交互逻辑
    /// </summary>
    public partial class Win_login : Window
    {
        CustomerBLL bll = new CustomerBLL();
        RestaurantBLL rbll = new RestaurantBLL();
        public static string mood;
        public Win_login()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void rb_Custom_Checked(object sender, RoutedEventArgs e)
        {
            mood = "客官";
        }

        private void rb_Owner_Checked(object sender, RoutedEventArgs e)
        {
            mood = "掌柜";
        }

        private void rb_Manager_Checked(object sender, RoutedEventArgs e)
        {
            mood = "管理员";
        }


        private void bt_Lsign_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入账户");
            }
            else if (password.Password == "")
            {
                MessageBox.Show("请输入密码");
            }

            else if (mood == "客官")
            {
                ///<summary>
                ///登陆程序,匹配完成后打开新窗口
                ///</summary>
                    int count = bll.GetAllCustomer().Count;
                    List<Customer> customers=new List<Customer>();
                    customers = bll.GetAllCustomer();
                    int i = 0;
                    while( i<count)
                    {
                        //textBox2.Text += customers[i].cus_telephone;
                        if (textBox1.Text == customers[i].cus_telephone)
                        {
                            if (password.Password == customers[i].cus_password)
                            {
                                MessageBox.Show("登陆成功");
                                common.cus = customers[i];
                                break;
                            }
                           
                        }
                        i++;
                    }
                    if (i < count)
                    {
                        Win_Cus_logined cus_logined = new Win_Cus_logined();
                        cus_logined.Show();
                        this.Close();
                    }
                    else
                    {
                     MessageBox.Show("账号错误或账号与密码不匹配，登录失败");
                     textBox1.Clear();
                     password.Clear();
                    }
                    //int count = bll.GetAllCustomer().Count;
                   // List<customer> customers = new List<customer>();
                    //customers = bll.GetAllCustomer();
                    //textBox2.Text = customers[5].ID.ToString();
                    //textBox2.Text = customers[7].cus_nickname;
                
            }
            else if (mood == "管理员")
            {

                ///<summary>
                ///登陆程序,匹配完成后打开新窗口
                ///</summary>
                if (textBox1.Text == "admin" && password.Password == "password")
                {
                    MessageBox.Show("登陆成功");
                    Win_Admin_logined admin = new Win_Admin_logined();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("您没有管理员权限！！！");
                }
            }
            else if (mood == "掌柜")
            {
                ///<summary>
                ///登陆程序,匹配完成后打开新窗口
                ///</summary>
                int count = rbll.GetAllRestaurant().Count;
                List<Restaurant> rests = new List<Restaurant>();
                rests = rbll.GetAllRestaurant();
                int i=0;
                while(i<count)
                {
                    if (textBox1.Text == rests[i].rest_telephone)
                        if (password.Password == rests[i].rest_password)
                        {
                            common.rest = rests[i];
                            MessageBox.Show("登陆成功");
                            break;
                        }
                    i++;
                }
                if (i < count)
                {
                    Win_Own_logined own_login = new Win_Own_logined();
                    own_login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("账号错误或账号与密码不匹配，登录失败");
                    textBox1.Clear();
                    password.Clear();
                }
            }
            else
            {
                MessageBox.Show("请选择登录类型");
            }
        }

        private void bt_Lexit_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mWin = new MainWindow();
            mWin.Show();
            this.Close();
            
        }


        private void forget_pass(object sender, MouseButtonEventArgs e)
        {
            //int i = 0;
            if (mood == null)
            {
                MessageBox.Show("请先选择身份！");
            }
            else if (mood == "客官")
            {
                Win_reset_pass rest_pass = new Win_reset_pass();
                rest_pass.Show();
                this.Close();
            }
            else if (mood == "掌柜")
            {
                Win_reset_pass_Res reset_pass_Res = new Win_reset_pass_Res();
                reset_pass_Res.Show();
                this.Close();
            }
            
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

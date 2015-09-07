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
using OrderSystemBLL;
using OrderSystem.Model;
using OrderSystem.DAL;
namespace Login
{
    /// <summary>
    /// Win_reset_pass.xaml 的交互逻辑
    /// </summary>
    public partial class Win_reset_pass : Window
    {
        CustomerDAL c_dal = new CustomerDAL();
        public Win_reset_pass()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        CustomerBLL c_bll = new CustomerBLL();

        static string question;
        static string answer;
        static string phoneNum;

        
        private void input_num(object sender, RoutedEventArgs e)
        {
            phoneNum = tb_num.Text;
            List<Customer> customers = new List<Customer>();
            customers = c_dal.GetAllCustomer();
            int count = customers.Count;
            DataTable dt;
            int i;
            for (i = 0; i < count; i++)
            {
                if (phoneNum == customers[i].cus_telephone)
                {
                    dt = c_bll.select_customer_by_telephone_dt(phoneNum);         //从电话号返回顾客信息表

                    question = dt.Rows[0]["cus_question"].ToString();             //获得用户表中的验证问题
                    lab_question.Content = question;
                    answer = dt.Rows[0]["cus_answer"].ToString();                 //获得用户表中的答案

                    textBlock3.Visibility = Visibility.Hidden;                    //输入手机号提示框隐藏
                    tb_num.Visibility = Visibility.Hidden;                        //手机号接收框隐藏
                    button2.Visibility = Visibility.Hidden;                       //提交手机号按钮隐藏
                    label1.Visibility = Visibility.Visible;                       //提示回答验证问题lable显示
                    lab_question.Visibility = Visibility.Visible;                 //问题内容lable显示
                    tb_answer.Visibility = Visibility.Visible;                    //接收答案文本框显示

                    button3.Visibility = Visibility.Visible;
                    break;
                }
           }
              if(i==count)
                {
                    MessageBox.Show("无该账户，请重新输入。");
                    tb_num.Clear();
                }
                               //提交答案按钮显示
            
        }

        private void show_Pass(object sender, RoutedEventArgs e)
        {
            if (answer == tb_answer.Text)
            {
                textBlock1.Visibility = Visibility.Visible;
                textBlock2.Visibility = Visibility.Visible;
                passwordBox1.Visibility = Visibility.Visible;
                passwordBox2.Visibility = Visibility.Visible;
                bt_confirm.Visibility = Visibility.Visible;                  //确认修改按钮显示

                label1.Visibility = Visibility.Hidden;                       //提示回答验证问题lable隐藏
                lab_question.Visibility = Visibility.Hidden;                 //问题内容lable隐藏
                tb_answer.Visibility = Visibility.Hidden;                    //接收答案文本框隐藏

                button3.Visibility = Visibility.Hidden;                       //提交答案按钮隐藏
                //MessageBox.Show("文本呗改变了");
            }
            else
            {
                MessageBox.Show("答案错误，请重新输入");
                tb_answer.Clear();
            }
        }

        
        //确认修改密码
        private void bt_confirm_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox1.Password == passwordBox2.Password)
            {
                c_bll.Update_customer_pass(phoneNum, passwordBox1.Password);
                MessageBox.Show("密码重置成功！");
            }
            else
            {
                MessageBox.Show("两次密码不一致，请重新输入");
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Win_login win_login = new Win_login();
            win_login.Show();
            this.Close();
        }

        
    }
}

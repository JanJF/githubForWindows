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
using System.Data;

namespace Login
{
    /// <summary>
    /// Win_reset_pass_Res.xaml 的交互逻辑
    /// </summary>
    public partial class Win_reset_pass_Res : Window
    {
        public Win_reset_pass_Res()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        static string question;
        static string answer;
        static string phoneNum;

        RestaurantBLL bll = new RestaurantBLL();

        
        private void input_num(object sender, RoutedEventArgs e)
        {
            phoneNum = tb_num.Text;
            DataTable dt;

            dt = bll.select_restaurant_by_telephone_dt(phoneNum);         //从电话号返回顾客信息表

            question = dt.Rows[0]["rest_question"].ToString();             //获得用户表中的验证问题
            lab_question.Content = question;        
            answer = dt.Rows[0]["rest_answer"].ToString();                 //获得用户表中的答案

            textBlock3.Visibility = Visibility.Hidden;                    //输入手机号提示框隐藏
            tb_num.Visibility = Visibility.Hidden;                        //手机号接收框隐藏
            bt_sub_phone.Visibility = Visibility.Hidden;                       //提交手机号按钮隐藏
            label1.Visibility = Visibility.Visible;                       //提示回答验证问题lable显示
            lab_question.Visibility = Visibility.Visible;                 //问题内容lable显示
            tb_answer.Visibility = Visibility.Visible;                    //接收答案文本框显示

            btn_sub_ans.Visibility = Visibility.Visible;                       //提交答案按钮显示
            //MessageBox.Show("文本呗改变了");
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

                btn_sub_ans.Visibility = Visibility.Hidden;                       //提交答案按钮隐藏
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
                bll.Update_Restaurant_pass(phoneNum, passwordBox1.Password);
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Win_login win_login = new Win_login();
            win_login.Show();
            this.Close();
        }
    }
}

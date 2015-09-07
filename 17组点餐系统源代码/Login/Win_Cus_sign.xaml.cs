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
using System.Data.SqlClient;
using System.Windows.Navigation;
using OrderSystemBLL;
using OrderSystem.Model;
using OrderSystem.DAL;


namespace Login
{
    /// <summary>
    /// Win_Cus_sign.xaml 的交互逻辑
    /// </summary>
    
    public partial class Win_Cus_sign : Window
    {
        CustomerBLL bll = new CustomerBLL();
        CustomerDAL c_dal = new CustomerDAL();
        public Win_Cus_sign()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

       
        //退出
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mWin = new MainWindow();
            mWin.Show();
            this.Close();
        }


        //注册
        private void bt_Wsign_Click(object sender, RoutedEventArgs e)
        {
                 List<Customer> cuses = new List<Customer>();    
                 cuses = c_dal.GetAllCustomer();
                int count = cuses.Count;
                int i = 0;            
                if(textBox1.Text=="")
                {
                    MessageBox.Show("请填写昵称");
                }
                else if (passwordBox1.Password == "")
                {
                    MessageBox.Show("请填写密码");
                }
                else if (passwordBox2.Password == "")
                {
                    MessageBox.Show("请确认密码");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("请填写手机号");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("请填写验证问题");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("请填写验证问题答案");
                }
                else if (passwordBox1.Password != passwordBox2.Password)
                {
                    MessageBox.Show("密码输入错误，请核对后重新输入");
                    textBox4.Clear();
                }
                else if (textBox4.Text.Length != 11)
                {
                    MessageBox.Show("手机号格式不正确，请重新输入");
                    textBox4.Clear();
                }
                else if (passwordBox1.Password == passwordBox2.Password)
                {
                    while (i < count)
                    {
                        if (textBox4.Text == cuses[i].cus_telephone)
                        {
                            MessageBox.Show("该电话号码已经被注册，请重新输入");
                            break;
                        }
                        i++;
                    }
                    if (i == count)
                    {
                        Customer cus = new Customer();
                        cus.cus_score = 0;
                        cus.cus_nickname = textBox1.Text;
                        cus.cus_password = passwordBox1.Password;
                        cus.cus_telephone = textBox4.Text;
                        cus.cus_question = textBox6.Text;
                        cus.cus_answer = textBox7.Text;
                        bll.Add_customer(cus);
                        common.cus = bll.Select_customer_By_Telephone(textBox4.Text); ;
                        MessageBox.Show("注册成功");
                        Win_Cus_logined cus_login = new Win_Cus_logined();
                        cus_login.Show();
                        this.Close();
                    }
                }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {

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

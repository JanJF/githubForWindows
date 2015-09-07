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
using OrderSystemBLL;
using OrderSystem.Model;
namespace Login.Page
{
    /// <summary>
    /// PageModifyInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PageModifyInfo : System.Windows.Controls.Page
    {
        CustomerBLL bll = new CustomerBLL();
        public PageModifyInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox1.Password == "")
                MessageBox.Show("请输入密码");
            else if(passwordBox2.Password == "")
                MessageBox.Show("请确认密码");
            else if (passwordBox1.Password != passwordBox2.Password)
            {
                MessageBox.Show("密码输入错误，请重新确认");
                passwordBox1.Clear();
                passwordBox2.Clear();
            }
            else
            {
                common.cus.cus_password = passwordBox1.Password;
                //common.cus.cus_telephone = textBox4.Text;
                if (bll.Update_customer(common.cus,common.cus.ID)) 
                {
                    MessageBox.Show("修改成功");
                    
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                passwordBox1.Clear();
                passwordBox2.Clear();
                //textBox4.Text = common.cus.ID.ToString();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

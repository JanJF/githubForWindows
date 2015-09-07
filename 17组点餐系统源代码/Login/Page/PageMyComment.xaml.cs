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
using OrderSystem.DAL;
using OrderSystem.Model;
using OrderSystemBLL;
using System.Data;

namespace Login.Page
{
    /// <summary>
    /// PageMyComment.xaml 的交互逻辑
    /// </summary>
    public partial class PageMyComment : System.Windows.Controls.Page
    {
        CustomerDAL c_dal = new CustomerDAL();
        
        public PageMyComment()
        {
            InitializeComponent();
            Customer cus = c_dal.select_customer(common.cus.ID);
            textBox1.Text = common.cus.cus_nickname;
            textBox2.Text = common.cus.cus_question;
            textBox3.Text = common.cus.cus_answer;
        }

        public void commit(object sender, MouseButtonEventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                common.cus.cus_nickname = textBox1.Text;
                common.cus.cus_question = textBox2.Text;
                common.cus.cus_answer = textBox3.Text;
                c_dal.Update_customer(common.cus, common.cus.ID);
                MessageBox.Show("修改完毕");
            }
            else
            {
                MessageBox.Show("请完善信息。");
            }
        }

        public void mouse_move(object sender, MouseEventArgs e)
        {
            textBlock2.FontSize=16;
        }


        public void mouse_leave(object sender, MouseEventArgs e)
        {
            textBlock2.FontSize = 12;
        }
    }
}

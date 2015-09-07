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

namespace Login
{
    /// <summary>
    /// Win_Own_logined.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Own_logined : Window
    {
        public Win_Own_logined()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void bt_Owner_home_Click(object sender, RoutedEventArgs e)
        {
            string str = "该登陆商家数据库不为空";
            //注意先检测该用户名的商家数据库是否存在，不存在则不显示其页面
            if (str != null)
            {
                Win_Owner1 owner1 = new Win_Owner1();
                owner1.Show();
            }
            else {
                MessageBox.Show("系统检测到您还为上传过菜品相关信息，请先上传后再进入");
            }
            //this.Close();
        }

        private void bt_Owner_back_Click(object sender, RoutedEventArgs e)
        {
            Win_Din_BackManager bm = new Win_Din_BackManager();
            bm.Show();

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

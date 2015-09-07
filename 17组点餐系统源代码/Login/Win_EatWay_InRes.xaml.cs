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
using OrderSystem.Model;
using OrderSystemBLL;
using System.Data;

namespace Login
{
    /// <summary>
    /// Win_EatWay_InRes.xaml 的交互逻辑
    /// </summary>
    public partial class Win_EatWay_InRes : Window
    {
        public Win_EatWay_InRes()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            int id = common.rest.ID;
            show_seat(id);
        }
        static int choose = 0;

        SeatsBLL bll = new SeatsBLL();
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (int.Parse(lab_2.Content.ToString()) > 0)
            {
                lab_choose.Content = "2人桌";
                choose = 2;
            }
            else
                MessageBox.Show("暂无座位！");
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            if (int.Parse(lab_4.Content.ToString()) > 0)
            {
                choose = 4;
                lab_choose.Content = "4人桌";
            }
            else
                MessageBox.Show("暂无座位！");
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            if (int.Parse(lab_8.Content.ToString()) > 0)
            {
                choose = 8;
                lab_choose.Content = "8人桌";
            }
            else
                MessageBox.Show("暂无座位！");
        }

        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            if (int.Parse(lab_12.Content.ToString()) > 0)
            {
                choose = 12;
                lab_choose.Content = "12人桌";
            }
            else
                MessageBox.Show("暂无座位！");
        }

        private void show_seat(int id)
        {
            DataTable dt;
            dt = bll.select_seat(id, 100001);
            int seat_2 = int.Parse(dt.Rows[0]["seat_left"].ToString());
            lab_2.Content = seat_2;
            dt = bll.select_seat(id, 100002);
            int seat_4 = int.Parse(dt.Rows[0]["seat_left"].ToString());
            lab_4.Content = seat_4;
            dt = bll.select_seat(id, 100003);
            int seat_8 = int.Parse(dt.Rows[0]["seat_left"].ToString());
            lab_8.Content = seat_8;
            dt = bll.select_seat(id, 100004);
            int seat_12 = int.Parse(dt.Rows[0]["seat_left"].ToString());
            lab_12.Content = seat_12;
        }

        //提交订单
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            if (choose == 0)
                MessageBox.Show("请选择重新座位");
            else if (choose == 2)
            {
                bll.Update_seat(common.rest.ID, 100001, int.Parse(lab_2.Content.ToString()) - 1);
                MessageBox.Show("下单成功");
                this.Close();
            }
            else if (choose == 4)
            {
                bll.Update_seat(common.rest.ID, 100002, int.Parse(lab_4.Content.ToString()) - 1);
                MessageBox.Show("下单成功");
                this.Close();
            }
            else if (choose == 8)
            {
                bll.Update_seat(common.rest.ID, 100003, int.Parse(lab_8.Content.ToString()) - 1);
                MessageBox.Show("下单成功");
                this.Close();
            }
            else if (choose == 12)
            {
                bll.Update_seat(common.rest.ID, 100004, int.Parse(lab_12.Content.ToString()) - 1);
                MessageBox.Show("下单成功");
                this.Close();
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

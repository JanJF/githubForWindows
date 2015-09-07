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
using System.Data;
using OrderSystemBLL;

namespace Login.Page
{
    /// <summary>
    /// PageOwnInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PageOwnInfo : System.Windows.Controls.Page
    {
        static RestaurantDAL r_dal = new RestaurantDAL();
        DataTable dt = r_dal.GetAllRestaurant_dt();
        RestaurantBLL o_bll = new RestaurantBLL();
        SeatsBLL s_bll = new SeatsBLL();
        DishBLL d_bll = new DishBLL();
        PictureBLL p_bll = new PictureBLL();
        static int id;

        public PageOwnInfo()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dt = r_dal.select_restaurant_by_telephone_dt(textBox1.Text);
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;

            var bl = dg.IsChecked;
            if (bl == true)
            {
                id = int.Parse(((DataRowView)dataGrid1.CurrentItem).Row[0].ToString());
            }
            DataTable dt = (dataGrid1.ItemsSource as DataView).Table;
            if(s_bll.Delete_Seat(id))
                if (d_bll.delete_Dish(id))
                    if (p_bll.delete_picture(2, id))
                        if(o_bll.Delete_restaurant(id))
                            MessageBox.Show("删除成功");
            DataTable dt1 = r_dal.GetAllRestaurant_dt();
            dataGrid1.ItemsSource = dt1.DefaultView;

        }
    }
}

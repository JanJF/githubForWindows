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
using System.Data;

namespace Login
{
    /// <summary>
    /// Win_All_Rest_Show.xaml 的交互逻辑
    /// </summary>
    public partial class Win_All_Rest_Show : Window
    {
        RestaurantBLL r_bll = new RestaurantBLL();
        DataTable dt = new DataTable();
        
        public Win_All_Rest_Show()
        {
            InitializeComponent();
            dt = r_bll.GetAllRestaurant_dt();
            dataGrid1.ItemsSource = dt.DefaultView;
        }

        public void Restaurant_Detail_Show(object sender, MouseEventArgs e)
        {
            int ID = Convert.ToInt16(((DataRowView)dataGrid1.CurrentItem).Row[0]);
            common.rest = r_bll.select_restaurant(ID);
            Win_Owner1 win_owner1 = new Win_Owner1();
            win_owner1.Show();
            this.Close();
        }
    }
}

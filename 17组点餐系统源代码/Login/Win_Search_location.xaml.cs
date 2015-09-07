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
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;

namespace Login
{
    /// <summary>
    /// Win_Search_location.xaml 的交互逻辑
    /// </summary>
    /// 
     
        

    public partial class Win_Search_location : Window
    {

        RestaurantDAL dal = new RestaurantDAL();
        DishDAL d_dal = new DishDAL();
        List<Dish> dishes = new List<Dish>();
        
        //public DataRow dr = new DataRow();
        
        
        public const int s_district = 21;
        public const int s_restaurant = 22;
        public const int s_dish = 23;

        public Win_Search_location()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (common.search_style == s_district)
            {
                DataTable dt;
                dt = dal.select_restaurant_by_district_dt(common.rest_search);
                if (dt.Rows.Count == 0)
                {
                    label5.Content = 0;
                    dataGrid1.Visibility = Visibility.Hidden;
                }
                else
                    dataGrid1.ItemsSource = dal.select_restaurant_by_district_dt(common.rest_search).DefaultView;
            }
            else if (common.search_style == s_restaurant)
            {
                DataTable dt;
                dt = dal.select_restaurant_by_name_dt(common.rest_search);
                if (dt.Rows.Count == 0)
                {
                    label5.Content = 0;
                    dataGrid1.Visibility = Visibility.Hidden;
                }
                else
                    dataGrid1.ItemsSource = dt.DefaultView;
                //if (dal.select_restaurant_by_name_dt(common.rest_search).DefaultView == null)
                //    dataGrid1.Visibility = Visibility.Hidden;
            }
            else if (common.search_style == s_dish)
            {
                //MessageBox.Show("aaaaa");
                dishes = d_dal.select_dish_by_name(common.rest_search);
                if (dishes.Count == 0)
                {
                    dataGrid1.Visibility = Visibility.Hidden;
                    label5.Content = "0";
                }
                else
                {
                    int count = dishes.Count;
                    int i = 1;
                    //MessageBox.Show(dishes[i].dish_restaurant.ToString());
                    DataTable dt = dal.select_restaurant_dt(dishes[0].dish_restaurant);
                    while (i < count)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ID"] = dal.select_restaurant_dr(dishes[i].dish_restaurant)["ID"];
                        dr["rest_name"] = dal.select_restaurant_dr(dishes[i].dish_restaurant)["rest_name"];
                        dr["rest_telephone"] = dal.select_restaurant_dr(dishes[i].dish_restaurant)["rest_telephone"];
                        dr["rest_district"] = dal.select_restaurant_dr(dishes[i].dish_restaurant)["rest_district"];
                        dr["rest_homephone"] = dal.select_restaurant_dr(dishes[i].dish_restaurant)["rest_homephone"];
                        //dr = dal.select_restaurant_dr(dishes[i].dish_restaurant);
                        //MessageBox.Show( dr["rest_name"].ToString());
                        dt.Rows.Add(dr);
                        i++;
                    }
                    dataGrid1.ItemsSource = dt.DefaultView;
                }
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sPick(object sender, MouseButtonEventArgs e)
        {
            int id = int.Parse(((DataRowView)dataGrid1.CurrentItem).Row[0].ToString());
            //MessageBox.Show(s);
            common.rest = dal.select_restaurant(id);
            Win_Owner1 owner = new Win_Owner1();
            owner.Show();
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

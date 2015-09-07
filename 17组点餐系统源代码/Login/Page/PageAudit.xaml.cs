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
using OrderSystem.Model;
using System.IO;



namespace Login.Page
{
    /// <summary>
    /// PageAudit.xaml 的交互逻辑
    /// </summary>
    


    public partial class PageAudit : System.Windows.Controls.Page
    {

        RestaurantBLL bll = new RestaurantBLL();
        RestaurantDAL dal = new RestaurantDAL();
        PictureDAL p_dal = new PictureDAL();

        public PageAudit()
        {
            InitializeComponent();
            dataGrid2.ItemsSource = dal.showAduit().DefaultView;
            dataGrid1.ItemsSource = dal.showUnAduit().DefaultView;
            //image1.Source=picture_show(2,Convert.ToInt16(((DataRowView)dataGrid1.CurrentItem).Row[0]));
        }

        public void pic_show(object sender,MouseButtonEventArgs e)
        {
            image1.Source = picture_show(2, Convert.ToInt16(((DataRowView)dataGrid1.CurrentItem).Row[0]));
        }
        
        public BitmapImage picture_show(int pic_style, int pic_owner)
        {
            Picture pic = new Picture();
            pic = p_dal.select_picture(pic_style, pic_owner);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(pic.image);
            image.EndInit();
            return image;
        }

        static int id;
        static int states;
        //static string name;
        //
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            bll.Update_info(id, states);
            dataGrid2.ItemsSource = dal.showAduit().DefaultView;
            dataGrid1.ItemsSource = dal.showUnAduit().DefaultView;
        }


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            //infomation info = new infomation();

            //获取该行的states  
            states = int.Parse(dg.Tag.ToString());
            var bl = dg.IsChecked;
            if (bl == true)
            {
                states = 1;

                id = int.Parse(((DataRowView)dataGrid1.CurrentItem).Row[0].ToString());


            }
            DataTable dt = (dataGrid1.ItemsSource as DataView).Table;
        }
    }
}

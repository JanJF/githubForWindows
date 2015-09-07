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
using Microsoft.Win32;
using System.IO;
using OrderSystem.DAL;
using System.Data;

namespace Login.Page
{
    /// <summary>
    /// PageUpDish.xaml 的交互逻辑
    /// </summary>
    public partial class PageUpDish : System.Windows.Controls.Page
    {
        DishBLL bll = new DishBLL();
        Dish dis = new Dish();
        int dish_type=2;


        //****插入图片
        Picture pic = new Picture();
        PictureDAL dal = new PictureDAL();
        //****插入图片


        public const int special_dish = 1;
        public const int common_dish = 0;


        public PageUpDish()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("请输入菜名");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("请输入价格");
            }
            else if (dish_type == 2)
            {
                MessageBox.Show("请选择是否是特色菜");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("请输入描述");
            }
            else
            {
                try
                {
                    dis.dish_name = textBox1.Text;
                
                    dis.dish_price = Convert.ToInt16(textBox2.Text);
               
                
                    dis.dish_type = dish_type;
                    dis.dish_description = textBox3.Text;
                    dis.dish_restaurant = common.rest.ID;
                    dis.dish_service = 0;
                
                    if(bll.Add_dish(dis))
                    {
                        DataTable dt;
                        dt = bll.findDishID_By_restId_dishN(common.rest.ID, textBox1.Text);
                        pic.pic_style = 1;                  //0代表客户，1代表菜品，2代表商家
                        int dishID = (int)dt.Rows[0]["ID"];
                        pic.pic_owner = dishID;             //客户id，菜品id，商家id
                        if(dal.Add_picture(pic) !=0 )
                             MessageBox.Show("菜色添加成功");
                    }
                    else
                    {
                        MessageBox.Show("菜色添加失败");
                    }
                }
                catch
                {
                    MessageBox.Show("价格输入有误，请重新输入");
                }
                
            }

        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            dish_type = special_dish;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            dish_type = common_dish;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Photo = new OpenFileDialog();
            Photo.Filter = "jpg图片|*.jpg|png图片|*.png";
            if (Photo.ShowDialog() == true)
            {
                string filename = Photo.FileName;
                textBox4.Text = filename;
                //pic = (Picture)picture.DataContext;
                byte[] img = File.ReadAllBytes(filename);
                pic.image = img;
            }
        }
    }
}

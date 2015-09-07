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

namespace Login.Page
{
    /// <summary>
    /// PageMyInfo.xaml 的交互逻辑
    /// </summary>
    public partial class PageMyInfo : System.Windows.Controls.Page
    {
        public PageMyInfo()
        {
            InitializeComponent();
            label4.Content = common.cus.cus_nickname;
            label3.Content = common.cus.cus_telephone;
            label5.Content = common.cus.cus_score;
        }
    }
}

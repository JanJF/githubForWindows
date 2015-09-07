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
    /// Win_Din_BackManager.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Din_BackManager : Window
    {
        public Win_Din_BackManager()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            frame1.Source = new Uri("page/" + "PageOrder.xaml", UriKind.Relative);

        }

        private void Button_CLick(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn != null)
            {
                frame1.Source = new Uri("page/" + btn.Tag, UriKind.Relative);
            }
        }

        


        
    }
}

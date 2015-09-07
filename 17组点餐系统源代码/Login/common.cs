using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;

namespace Login
{
    class common
    {
        public static Customer cus=new Customer();
        public static Restaurant rest;//=new Restaurant();
        public static List<Restaurant> rests=new List<Restaurant>();
        public static string rest_search;
        public static int search_style;
        public static int[] dishcount={0,0,0,0,0,0,0,0,0};
        public static Order ord = new Order();       
    }
}

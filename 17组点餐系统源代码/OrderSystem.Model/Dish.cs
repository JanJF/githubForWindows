using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OrderSystem.Model
{
    public class Dish
    {
        public int ID { get; set; }
        public string dish_name { get; set; }
        public int dish_price { get; set; }
        public int dish_type { get; set; }//1是特色菜，0不是特色菜
        public int dish_service { get; set; }
        public int dish_restaurant { get; set; }
        public string dish_description { get; set; }
    }
}

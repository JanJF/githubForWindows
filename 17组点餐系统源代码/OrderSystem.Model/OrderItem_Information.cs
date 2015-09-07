using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem.Model
{
    public class OrderItem_Information
    {
        public int ID { get; set; }
        public int order_ID { get; set; }
        public int dish_ID { get; set; }
        public int dish_amount { get; set; }
        public float total_pay { get; set; }
        public string dish_name { get; set; }
    }
}

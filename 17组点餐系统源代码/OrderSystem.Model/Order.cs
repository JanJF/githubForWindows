using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem.Model
{
    public class Order
    {
        public int ID { get; set; }
        public int customer_ID { get; set; }
        public int restaurant_ID { get; set; }
        public float should_pay { get; set; }
        public float actually_pay { get; set; }
        public int order_privilege { get; set; }//优惠类型
        public int score_use { get; set; }
        public string order_description { get; set; }
        public DateTime order_date { get; set; }
        public int order_state { get; set; }
        public int meal_state { get; set; }//区别顾客是到店用餐还是要求商家送外卖的变量
        public string order_location { get; set; }
    }
}

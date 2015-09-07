using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem.Model
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string rest_district { get; set; }
        //public int rest_license { get; set; }//营业执照照片
        public int rest_service { get; set; }
        public int rest_privilege { get; set; }
        public string rest_name { get; set; }
        public string rest_password { get; set; }
        public string rest_telephone { get; set; }
        public string rest_homephone { get; set; }
        public string rest_question { get; set; }
        public string rest_answer { get; set; }
        public string rest_description { get; set; }
        public string rest_location { get; set; }
        public DateTime begin_date { get; set; }
        public DateTime end_date { get; set; }
        public int rest_state { get; set; }
    }
}

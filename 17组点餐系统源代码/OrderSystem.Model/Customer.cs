using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public int cus_score { get; set; }
        public string cus_nickname { get; set; }//
        public string cus_password { get; set; }//
        public string cus_telephone { get; set; }//
        public string cus_question { get; set; }//
        public string cus_answer { get; set; }  //   
    }
}

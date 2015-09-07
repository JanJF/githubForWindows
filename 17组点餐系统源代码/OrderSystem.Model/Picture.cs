using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//0代表客户，1代表菜品，2代表商家
namespace OrderSystem.Model
{
    public class Picture
    {
        public int ID;
        public byte[] image;
        public int pic_style;           //0代表客户，1代表菜品，2代表商家
        public int pic_owner;           //客户id，菜品id，商家id
    }
}

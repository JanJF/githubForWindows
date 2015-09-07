using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;

namespace OrderSystemBLL
{
    public class OrderItem_InformationBLL
    {
        OrderItem_InformationDAL dal = new OrderItem_InformationDAL();
        public bool Add_orderitem(OrderItem_Information orderit)
        {
            return dal.Add_orderitem(orderit) > 0;
        }

        public bool Update_orderitem(OrderItem_Information orderit, int ID)
        {
            return dal.Update_orderitem(orderit, ID) > 0;
        }

        public List<OrderItem_Information> Select_Orderitems(int order_ID)
        {
            return dal.select_orderitems(order_ID);
        }

        public bool Delete_Orderitem(int order_ID)
        {
            return dal.delete_orderitem(order_ID) > 0;
        }
    }
}

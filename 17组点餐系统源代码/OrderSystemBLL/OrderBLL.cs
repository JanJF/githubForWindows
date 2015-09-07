using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;

namespace OrderSystemBLL
{
    public  class OrderBLL
    {
        OrderDAL dal = new OrderDAL();
        public bool Add_order(Order ord)
        {
            return dal.Add_order(ord) > 0;
        }

        public bool Update_order(Order ord, int ID)
        {
            return dal.Update_order(ord, ID) > 0;
        }

        public bool Delete_Order(int ID)
        {
            return dal.delete_order(ID) > 0;
        }

        public bool update_order_by_restID_and_date(int restaurant_ID, DateTime order_date,string location)
        {
            return dal.update_order_by_restID_and_date(restaurant_ID, order_date, location) > 0;
        }

        public DataTable select_order_dt(int order_ID,int state)
        { 
            return dal.select_order_dt( order_ID,state);
        }
        //根据菜单id查找顾客id
        public Order select_cus_ID_by_ord_ID(int order_ID)
        {
            return dal.select_cus_ID_by_ord_ID(order_ID);
        }

        //public Order select_cus_id_By_state_rest_list(int rest_ID, int state)
        //{
        //    return select_cus_id_By_state_rest_list(rest_ID, state);
        //}
        //上传评论
        public bool Update_Restaurant_pass(string comment, int ID)
        {
            return dal.Update_Restaurant_pass(comment, ID) > 0;
        }

        //根据订单ID查找餐厅ID
        public DataTable select_rest_ID_by_ord_ID(int order_ID)
        {
            return dal.select_rest_ID_by_ord_ID(order_ID);
        }

        //根据订单id返回评论
        public DataTable get_comment_by_ord_ID(int order_ID)
        {
            return dal.get_comment_by_ord_ID(order_ID);
        }
        //根据订单id接单
        public bool Update_Restaurant_pass(int ID)
        {
            return dal.Update_Restaurant_pass(ID) > 0;
        }
    }
}

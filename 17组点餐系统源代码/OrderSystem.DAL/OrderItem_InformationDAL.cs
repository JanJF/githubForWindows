using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;
using System.Data.SqlClient;
using System.Data;

namespace OrderSystem.DAL
{
    public class OrderItem_InformationDAL
    {
        //加入订单id,菜色id，数量，价格
        public int Add_orderitem(OrderItem_Information orderitem)
        {
            String sql = "insert into orderitem_information values(@order_ID,@dish_ID,@dish_amount,@total_pay)";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID",SqlDbType.Int),
                new SqlParameter("@dish_ID",SqlDbType.Int),
                new SqlParameter("@dish_amount",SqlDbType.Int),
                new SqlParameter("@total_pay",SqlDbType.Float)
            };
            param[0].Value = orderitem.order_ID;
            param[1].Value = orderitem.dish_ID;
            param[2].Value = orderitem.dish_amount;
            param[3].Value = orderitem.total_pay;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据菜单ID修改菜单项信息函数
        public int Update_orderitem(OrderItem_Information orderit, int ID)
        {
            String sql = "update orderitem_information set dish_ID=@dish_ID,dish_amount=@dish_amount,total_pay=@total_pay where order_ID=@ID";
            SqlParameter[] param =
             {
                 new SqlParameter("@dish_ID",SqlDbType.Int),
                 new SqlParameter("@dish_amount",SqlDbType.Int),
                 new SqlParameter("@total_pay",SqlDbType.Float),
                 new SqlParameter("@ID",SqlDbType.Int),
             };
            param[0].Value = orderit.dish_ID;
            param[1].Value = orderit.dish_amount;
            param[2].Value = orderit.total_pay;
            param[3].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据菜单ID查询菜单项
        public List<OrderItem_Information> select_orderitems(int order_ID)
        {
            List<OrderItem_Information> orderitems = new List<OrderItem_Information>();
            String sql = "select * from orderitem_information where order_ID=@order_ID";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID",SqlDbType.Int)
            };
            param[0].Value = order_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                OrderItem_Information orderit = DataRowToOrderitem(dr);
                orderitems.Add(orderit);
            }
            return orderitems;
        }

        //将数据行转化为Orderitem实例
        public OrderItem_Information DataRowToOrderitem(DataRow dr)
        {
            OrderItem_Information orderit = new OrderItem_Information();
            orderit.order_ID = (int)dr["order_ID"];
            orderit.dish_ID = (int)dr["dish_ID"];
            orderit.dish_amount = (int)dr["dish_amount"];
            orderit.total_pay = (float)Convert.ToDouble(dr["total_pay"]);
            return orderit;
        }

        //根据订单ID删除菜单项
        public int delete_orderitem(int order_ID)
        {
            String sql = "delete from orderitem_information where order_ID=@order_ID";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID",SqlDbType.Int)
            };
            param[0].Value = order_ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据菜单ID查询菜单项返回数据表
        public DataTable select_orderitems_dt(int order_ID)
        {
            String sql = "select * from orderitem_information where order_ID=@order_ID";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID",SqlDbType.Int)
            };
            param[0].Value = order_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }


    }
}

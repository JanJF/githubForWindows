using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;
using System.Data.SqlClient;
using System.Data;

namespace OrderSystem.DAL
{
    public class OrderDAL
    {

        //添加菜单函数
        public int Add_order(Order ord)
        {
            String sql = "insert into order_information values(@customer_ID,@restaurant_ID,@schould_pay,@actually_pay,@score_use,@order_privilege,@order_description,@order_date,@order_state,@meal_style,@order_location)";
            SqlParameter[] param =
            {
                new SqlParameter("@customer_ID",SqlDbType.Int),
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@schould_pay",SqlDbType.Float),
                new SqlParameter("@actually_pay",SqlDbType.Float),
                new SqlParameter("@score_use",SqlDbType.Int),
                new SqlParameter("@order_privilege",SqlDbType.Int),
                new SqlParameter("@order_description",SqlDbType.VarChar),
                new SqlParameter("@order_date",SqlDbType.DateTime),
                new SqlParameter("@order_state",SqlDbType.Int),
                new SqlParameter("@meal_style",SqlDbType.Int),
                new SqlParameter("@order_location",SqlDbType.VarChar)
                //new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ord.customer_ID;
            param[1].Value = ord.restaurant_ID;
            param[2].Value = ord.should_pay;
            param[3].Value = ord.actually_pay;
            param[4].Value = ord.score_use;
            param[5].Value = ord.order_privilege;
            param[6].Value = ord.order_description;
            param[7].Value = ord.order_date;
            param[8].Value = ord.order_state;
            param[9].Value = ord.meal_state;
            param[10].Value = ord.order_location;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据菜单ID修改菜单信息
        public int Update_order(Order ord, int ID)
        {
            String sql = "update order_information set customer_ID=@customer_ID,restaurant_ID=@restaurant_ID,should_pay=@should_pay,actually_pay=@actually_pay,score_use=@score_use,order_privilege=@order_privilege,order_description=@order_description,order_state=@order_state,meal_state=@meal_state,order_location=@order_location where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@customer_ID",SqlDbType.Int),
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@should_pay",SqlDbType.Float),
                new SqlParameter("@actually_pay",SqlDbType.Float),
                new SqlParameter("@score_use",SqlDbType.Int),
                new SqlParameter("@order_privilege",SqlDbType.Int),
                new SqlParameter("@order_description",SqlDbType.VarChar),
                new SqlParameter("@order_state",SqlDbType.Int),
                new SqlParameter("@meal_state",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int),
                new SqlParameter("@order_location",SqlDbType.VarChar)
            };
            param[0].Value = ord.customer_ID;
            param[1].Value = ord.restaurant_ID;
            param[2].Value = ord.should_pay;
            param[3].Value = ord.actually_pay;
            param[4].Value = ord.score_use;
            param[5].Value = ord.order_privilege;
            param[6].Value = ord.order_description;
            param[7].Value = ord.order_state;
            param[8].Value = ord.meal_state;
            param[9].Value = ID;
            param[10].Value = ord.order_location;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据ID删除菜单
        public int delete_order(int ID)
        {
            String sql = "delete from order_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }
        //根据日期和餐厅ID查找菜单
        public Order select_order_by_restID_and_date(int restaurant_ID, DateTime order_date)
        {
            String sql = "select * from order_information where restaurant_ID=@restaurant_ID and order_date=@order_date";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@order_date",SqlDbType.DateTime)
            };
            param[0].Value = restaurant_ID;
            param[1].Value = order_date;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            Order ord = DataRowToOrder(dt.Rows[0]);
            return ord;
        }
        //数据行转化为Order实例
        public Order DataRowToOrder(DataRow dr)
        {
            Order ord = new Order();
            ord.ID = (int)dr["ID"];
            ord.customer_ID = (int)dr["customer_ID"];
            ord.restaurant_ID = (int)dr["restaurant_ID"];
            ord.should_pay = (float)Convert.ToDouble(dr["should_pay"]);
            ord.actually_pay = (float)Convert.ToDouble(dr["actually_pay"]);
            ord.score_use = (int)dr["score_use"];
            ord.order_privilege = (int)dr["order_privilege"];
            ord.order_description = dr["order_description"].ToString();
            ord.order_date = (DateTime)dr["order_date"];
            ord.order_state = (int)dr["order_state"];
            ord.meal_state = (int)dr["meal_state"];
            ord.order_location =Convert.ToString( dr["order_location"]);
            return ord;
        }
        //根据顾客ID查询菜单返回数据表
        public DataTable select_order_by_cus_id_dt(int customer_ID)
        {
            String sql = "select * from order_information where customer_ID=@customer_ID";
            SqlParameter param = new SqlParameter("@customer_ID",SqlDbType.Int);
            param.Value = customer_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql,param);
            return dt;
        }
        //根据顾客ID查询菜单
        public List<Order> select_order_by_cus_id(int customer_ID)
        {
            String sql = "select * from order_information where customer_ID=@customer_ID";
            SqlParameter param = new SqlParameter("@customer_ID", SqlDbType.Int);
            param.Value = customer_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            List<Order> orders = new List<Order>();
            Order ord = new Order();
            foreach (DataRow dr in dt.Rows)
            {
                ord = DataRowToOrder(dr);
                orders.Add(ord);
            }
            return orders;
        }

        //根据日期和餐厅ID更新菜单
        public int update_order_by_restID_and_date(int restaurant_ID, DateTime order_date,string location)
        {
            String sql = "update order_information set order_location=@location where restaurant_ID=@restaurant_ID and order_date=@order_date";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@order_date",SqlDbType.DateTime),
                new SqlParameter("@location",SqlDbType.VarChar)
            };
            param[0].Value = restaurant_ID;
            param[1].Value = order_date;
            param[2].Value = location;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据菜单ID查找顾客ID
        public Order select_cus_ID_by_ord_ID(int order_ID)
        {
            String sql = "select customer_ID from order_information where ID=@order_ID1";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID1",SqlDbType.Int)
            };
            param[0].Value = order_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            Order ord = DataRowToOrder(dt.Rows[0]);
            return ord;
        }

        //根据菜单ID查询菜单返回数据表
        public DataTable select_order_dt(int rest_ID,int state)
        {
            String sql = "select * from order_information where restaurant_ID=@rest_ID and order_state=@state";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_ID",SqlDbType.Int),
                new SqlParameter("@state",SqlDbType.Int)
            };
            param[0].Value = rest_ID;
            param[1].Value = state;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }
        //返回list
        public List<Order> select_order_list(int rest_ID, int state)
        {
            Order order = new Order();
            List<Order> orders=new List<Order>();
            String sql = "select * from order_information where restaurant_ID=@rest_ID and order_state=@state";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_ID",SqlDbType.Int),
                new SqlParameter("@state",SqlDbType.Int)
            };
            param[0].Value = rest_ID;
            param[1].Value = state;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                order = DataRowToOrder(dr);
                orders.Add(order);
            }
            return orders;
        }

        //根据菜单ID查询菜单返回数据表
        public DataTable select_cus_id_By_state_rest(int rest_ID, int state)
        {
            String sql = "select customer_ID from order_information where restaurant_ID=@rest_ID and order_state=@state";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_ID",SqlDbType.Int),
                new SqlParameter("@state",SqlDbType.Int)
            };
            param[0].Value = rest_ID;
            param[1].Value = state;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }
        public Order select_customer_phone(int rest_ID, int state)
        {
            String sql = "select customer_ID from order_information where restaurant_ID=@rest_ID and order_state=@state";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_ID",SqlDbType.Int),
                new SqlParameter("@state",SqlDbType.Int)
            };
            param[0].Value = rest_ID;
            param[1].Value = state;
            Order order = new Order();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                order = DataRowToOrder(dr);
            }
            return order;
        }

        //根据订单ID上传评论
        public int Update_Restaurant_pass(string comment, int ID)
        {
            String sql = "update order_information set order_description=@order_description where ID=@ID1";
            SqlParameter[] param =
            {
                new SqlParameter("@order_description",SqlDbType.VarChar),
                new SqlParameter("@ID1",SqlDbType.VarChar),
            };
            param[0].Value = comment;
            param[1].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据订单id，返回餐厅ID
        public DataTable select_rest_ID_by_ord_ID(int order_ID)
        {
            String sql = "select restaurant_ID from order_information where ID=@order_ID1";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID1",SqlDbType.Int)
            };
            param[0].Value = order_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据订单id返回用户评价
        public DataTable get_comment_by_ord_ID(int order_ID)
        {
            String sql = "select order_description from order_information where ID=@order_ID1";
            SqlParameter[] param =
            {
                new SqlParameter("@order_ID1",SqlDbType.Int)
            };
            param[0].Value = order_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据订单ID接单
        public int Update_Restaurant_pass( int ID)
        {
            String sql = "update order_information set order_state='1' where ID=@ID1";
            SqlParameter[] param =
            {
               
                new SqlParameter("@ID1",SqlDbType.Int),
            };
            param[0].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据餐厅ID查询菜单
        public List<Order> select_order_by_rest_id(int restaurant_ID)
        {
            String sql = "select * from order_information where restaurant_ID=@restaurant_ID and order_state=1";
            SqlParameter param = new SqlParameter("@restaurant_ID", SqlDbType.Int);
            param.Value = restaurant_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            List<Order> orders = new List<Order>();
            Order ord = new Order();
            foreach (DataRow dr in dt.Rows)
            {
                ord = DataRowToOrder(dr);
                orders.Add(ord);
            }
            return orders;
        }

        //根据餐厅ID查询菜单返回数据表
        public DataTable select_order_by_rest_id_dt(int restaurant_ID)
        {
            String sql = "select * from order_information where restaurant_ID=@restaurant_ID and order_state='1'";
            SqlParameter param = new SqlParameter("@restaurant_ID", SqlDbType.Int);
            param.Value = restaurant_ID;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }
    }
}

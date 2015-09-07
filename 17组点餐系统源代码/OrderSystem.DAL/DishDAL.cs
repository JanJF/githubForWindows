using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;
using System.Data.SqlClient;
using System.Data;

namespace OrderSystem.DAL
{
    public class DishDAL
    {
        //加入菜品函数
        public int Add_dish(Dish dis)
        {
            String sql = "insert into dish_information values(@dish_name,@dish_restaurant,@dish_price,@dish_type,@dish_description,@dish_service)";
            SqlParameter[] param =
            {
                new SqlParameter("@dish_name",SqlDbType.VarChar),
                new SqlParameter("@dish_restaurant",SqlDbType.Int),
                new SqlParameter("@dish_price",SqlDbType.Int),
                new SqlParameter("@dish_type",SqlDbType.Int),
                new SqlParameter("@dish_description",SqlDbType.VarChar),
                new SqlParameter("@dish_service",SqlDbType.Int)

            };
            param[0].Value = dis.dish_name;
            param[1].Value = dis.dish_restaurant;
            param[2].Value = dis.dish_price;
            param[3].Value = dis.dish_type;
            param[4].Value = dis.dish_description;
            param[5].Value = dis.dish_service;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据菜品ID修改菜色信息
        public int Update_dish(Dish dis, int ID)
        {
            String sql = "update dish_information set dish_name=@dish_name,dish_restaurant=@dish_restaurant,dish_price=@dish_price,dish_type=@dish_type,dish_description=@dish_description,dish_service=@dish_service where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@dish_name",SqlDbType.VarChar),
                new SqlParameter("@dish_restaurant",SqlDbType.VarChar),
                new SqlParameter("@dish_price",SqlDbType.Int),
                new SqlParameter("@dish_type",SqlDbType.Int),
                new SqlParameter("@dish_description",SqlDbType.VarChar),
                new SqlParameter("@dish_service",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = dis.dish_name;
            param[1].Value = dis.dish_restaurant;
            param[2].Value = dis.dish_price;
            param[3].Value = dis.dish_type;
            param[4].Value = dis.dish_description;
            param[5].Value = dis.dish_service;
            param[6].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        

        //根据餐厅ID查询菜色
        public List<Dish> select_dish(int dish_restaurant)
        {
            List<Dish> dishes = new List<Dish>();
            String sql = "select * from dish_information where dish_restaurant=@dish_restaurant";
            SqlParameter[] param =
            {
                new SqlParameter("@dish_restaurant",SqlDbType.Int)
            };
            param[0].Value = dish_restaurant;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                Dish dis = DataRowToDish(dr);
                dishes.Add(dis);
            }
            return dishes;
        }

        //将数据行转化为dish实例
        public Dish DataRowToDish(DataRow dr)
        {
            Dish dis = new Dish();
            dis.ID = (int)dr["ID"];
            dis.dish_name = dr["dish_name"].ToString();
            dis.dish_restaurant = (int)dr["dish_restaurant"];
            dis.dish_price = (int)dr["dish_price"];
            dis.dish_type = (int)dr["dish_type"];
            dis.dish_description = dr["dish_description"].ToString();
            dis.dish_service = (int)dr["dish_service"];
            return dis;
        }

        //根据菜名查询菜色以及（餐厅信息）
        public List<Dish> select_dish_by_name(string dish_name)
        {
            List<Dish> dishes = new List<Dish>();
            String sql = "select * from dish_information where dish_name=@dish_name";
            SqlParameter[] param =
            {
                new SqlParameter("@dish_name",SqlDbType.VarChar)
            };
            param[0].Value = dish_name;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                Dish dis = DataRowToDish(dr);
                dishes.Add(dis);
            }
            return dishes;
        }

        //根据餐厅id和菜品名称查找菜品ID
        public DataTable findDishID_By_restId_dishN(int resId, string dishName)
        {
            //int dishID;
            String sql = "select ID from dish_information where dish_name=@dishName and dish_restaurant=@resId";
            SqlParameter[] param =
            {
                new SqlParameter("@dishName",SqlDbType.VarChar),
                new SqlParameter("@resId",SqlDbType.Int)
            };
            param[0].Value = dishName;
            param[1].Value = resId;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            //dishID = (int)dt.Rows[0]["ID"];
            //return dt;
            //return dishID;
            return dt;
        }

        //根据菜品ID查询菜品
        public Dish select_dish_by_ID(int ID)
        {
            String sql = "select * from dish_information where ID=@ID";
            SqlParameter param = new SqlParameter("@ID",SqlDbType.Int);
            param.Value = ID;
            Dish dis = new Dish();
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteSelect(sql,param);
            return dis = DataRowToDish(dt.Rows[0]);
        }


        //根据餐厅ID查找特色菜
        public List<Dish> select_dish1_By_dish_restaurant(int dish_restaurant)
        {
            String sql = "select * from dish_information where dish_restaurant=@dish_restaurant and dish_type=1";
            SqlParameter param = new SqlParameter("@dish_restaurant",SqlDbType.Int);
            param.Value = dish_restaurant;
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteSelect(sql,param);
            List<Dish> dishes = new List<Dish>();
            Dish dis = new Dish();
            foreach(DataRow dr in dt.Rows)
            {
                dis = DataRowToDish(dr);
                dishes.Add(dis);
            }
            return dishes;
               
        }

        //根据餐厅ID查找非特色菜
        public List<Dish> select_dish0_By_dish_restaurant(int dish_restaurant)
        {
            String sql = "select * from dish_information where dish_restaurant=@dish_restaurant and dish_type=0";
            SqlParameter param = new SqlParameter("@dish_restaurant", SqlDbType.Int);
            param.Value = dish_restaurant;
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteSelect(sql, param);
            List<Dish> dishes = new List<Dish>();
            Dish dis = new Dish();
            foreach (DataRow dr in dt.Rows)
            {
                dis = DataRowToDish(dr);
                dishes.Add(dis);
            }
            return dishes;

        }

        //选择菜色表前3行
        public List<Dish> select_top_dish()
        {
            String sql = "select top 3 * from dish_information";
            Dish dis = new Dish();
            List<Dish> dishes = new List<Dish>();
            DataTable dt = new DataTable();
            dt = SqlHelper.Execute_Select(sql);
            foreach (DataRow dr in dt.Rows)
            {
                dis = DataRowToDish(dr);
                dishes.Add(dis);
            }
            return dishes;
        }

        //根据餐厅ID删除菜单信息
        public int delete_dish(int restaurant_ID)
        {
            String sql = "delete from dish_information where dish_restaurant=@restaurant_ID1";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID1",SqlDbType.Int)
            };
            param[0].Value = restaurant_ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据餐厅ID查询菜色返回数据表
        public DataTable select_dish_dt(int dish_restaurant)
        {
            String sql = "select * from dish_information where dish_restaurant=@dish_restaurant";
            SqlParameter[] param =
            {
                new SqlParameter("@dish_restaurant",SqlDbType.Int)
            };
            param[0].Value = dish_restaurant;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }
        //获取所有菜色信息
        public List<Dish> GetAllDish()
        {
            String sql = "select * from dish_information where dish_restaurant=@dish_restaurant";
            List<Dish> dishes = new List<Dish>();
            Dish dish = new Dish();
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                dish = DataRowToDish(dr);
                dishes.Add(dish);
            }
            return dishes;
        }
    }
}

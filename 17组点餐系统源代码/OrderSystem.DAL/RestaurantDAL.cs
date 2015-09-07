using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OrderSystem.DAL
{
    public class RestaurantDAL
    {
        //加入餐馆函数
        public int Add_restaurant(Restaurant rest)
        {
            String sql = "insert into rest_information values(@rest_name,@rest_district,@rest_password,@rest_telephone,@rest_homephone,@rest_question,@rest_answer,@rest_description,@rest_service,@rest_privilege,@rest_location,@begin_date,@end_date,@rest_state)";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_name",SqlDbType.VarChar),
                new SqlParameter("@rest_district",SqlDbType.VarChar),
                new SqlParameter("@rest_password",SqlDbType.VarChar),
                new SqlParameter("@rest_telephone",SqlDbType.VarChar),
                new SqlParameter("@rest_homephone",SqlDbType.VarChar),
                new SqlParameter("@rest_question",SqlDbType.VarChar),
                new SqlParameter("@rest_answer",SqlDbType.VarChar),
                new SqlParameter("@rest_description",SqlDbType.VarChar),
                new SqlParameter("@rest_service",SqlDbType.Int),
                new SqlParameter("@rest_privilege",SqlDbType.Int),
                new SqlParameter("@rest_location",SqlDbType.VarChar),
                new SqlParameter("@begin_date",SqlDbType.DateTime),
                new SqlParameter("@end_date",SqlDbType.DateTime),
                new SqlParameter("@rest_state",SqlDbType.Int),
            };
            param[0].Value = rest.rest_name;
            param[1].Value = rest.rest_district;
            param[2].Value = rest.rest_password;
            param[3].Value = rest.rest_telephone;
            param[4].Value = rest.rest_homephone;
            param[5].Value = rest.rest_question;
            param[6].Value = rest.rest_answer;
            param[7].Value = rest.rest_description;
            param[8].Value = rest.rest_service;
            param[9].Value = rest.rest_privilege;
            param[10].Value = rest.rest_location;
            param[11].Value = rest.begin_date;
            param[12].Value = rest.end_date;
            param[13].Value = rest.rest_state;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据餐厅ID修改餐厅信息
        public int Update_restaurant(Restaurant rest, int ID)
        {
            String sql = "update rest_information set rest_name=@rest_name,rest_district=@rest_district,rest_password=@rest_password,rest_telephone=@rest_telephone,rest_homephone=@rest_homephone,rest_question=@rest_question,rest_answer=@rest_answer,rest_description=@rest_description,rest_service=@rest_service,rest_privilege=@rest_privilege,rest_location=@rest_location,begin_date=@begin_date,end_date=@end_date,rest_state=@rest_state where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_name",SqlDbType.VarChar),
                new SqlParameter("@rest_district",SqlDbType.VarChar),
                new SqlParameter("@rest_password",SqlDbType.VarChar),
                new SqlParameter("@rest_telephone",SqlDbType.VarChar),
                new SqlParameter("@rest_homephone",SqlDbType.VarChar),
                new SqlParameter("@rest_question",SqlDbType.VarChar),
                new SqlParameter("@rest_answer",SqlDbType.VarChar),
                new SqlParameter("@rest_description",SqlDbType.VarChar),
                new SqlParameter("@rest_service",SqlDbType.Int),
                new SqlParameter("@rest_privilege",SqlDbType.Int),
                new SqlParameter("@rest_location",SqlDbType.VarChar),
                new SqlParameter("@begin_date",SqlDbType.DateTime),
                new SqlParameter("@end_date",SqlDbType.DateTime),
                new SqlParameter("@rest_state",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = rest.rest_name;
            param[1].Value = rest.rest_district;
            param[2].Value = rest.rest_password;
            param[3].Value = rest.rest_telephone;
            param[4].Value = rest.rest_homephone;
            param[5].Value = rest.rest_question;
            param[6].Value = rest.rest_answer;
            param[7].Value = rest.rest_description;
            param[8].Value = rest.rest_service;
            param[9].Value = rest.rest_privilege;
            param[10].Value = rest.rest_location;
            param[11].Value = rest.begin_date;
            param[12].Value = rest.end_date;
            param[13].Value = rest.rest_state;
            param[14].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据ID号查询餐厅信息
        public Restaurant select_restaurant(int ID)
        {
            String sql = "select * from rest_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            Restaurant rest = new Restaurant();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                rest = DataRowToRestaurant(dr);
            }
            return rest;
        }

        //餐厅数据行转化为restaurant实例
        public Restaurant DataRowToRestaurant(DataRow dr)
        {
            Restaurant rest = new Restaurant();
            rest.ID = (int)dr["ID"];
            rest.rest_name = dr["rest_name"].ToString();
            rest.rest_district = dr["rest_district"].ToString();
            rest.rest_password = dr["rest_password"].ToString();
            rest.rest_telephone = dr["rest_telephone"].ToString();
            rest.rest_homephone = dr["rest_homephone"].ToString();
            rest.rest_question = dr["rest_question"].ToString();
            rest.rest_answer = dr["rest_answer"].ToString();
            rest.rest_description = dr["rest_description"].ToString();
            rest.rest_service = (int)dr["rest_service"];
            rest.rest_privilege = (int)dr["rest_privilege"];
            rest.rest_location = dr["rest_location"].ToString();
            rest.begin_date = DateTime.Parse(dr["begin_date"].ToString());
            rest.end_date = DateTime.Parse(dr["end_date"].ToString());
            rest.rest_state = (int)dr["rest_state"];
            return rest;
        }

        //根据ID号删除餐厅
        public int delete_restaurant(int ID)
        {
            String sql = "delete from rest_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //提取所有餐厅信息
        public List<Restaurant> GetAllRestaurant()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            String sql = "select * from rest_information";
            DataTable dt = SqlHelper.ExecuteSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Restaurant rest = DataRowToRestaurant(dr);
                restaurants.Add(rest);
            }
            return restaurants;
        }

        //根据店名查询餐厅信息
        public List<Restaurant> select_restaurant_by_name(string rest_name)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            String sql = "select * from rest_information where rest_name=@rest_name";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_name",SqlDbType.VarChar)
            };
            param[0].Value = rest_name;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                Restaurant rest = DataRowToRestaurant(dr);
                restaurants.Add(rest);
            }
            return restaurants;
        }
        //根据地区查询餐厅
        public List<Restaurant> select_restaurant_by_district(string rest_district)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            String sql = "select * from rest_information where rest_district=@rest_district";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_district",SqlDbType.VarChar)
            };
            param[0].Value = rest_district;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                Restaurant rest = DataRowToRestaurant(dr);
                restaurants.Add(rest);
            }
            return restaurants;
        }

        //根据地区查询餐厅返回数据表
        public DataTable select_restayrant_by_district_dt(string rest_district)
        {
            String sql = "select * from rest_information where rest_district=@rest_district1";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_district1",SqlDbType.VarChar)
            };
            param[0].Value = rest_district;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据地区查询餐厅返回数据表
        public DataTable select_restaurant_by_district_dt(string rest_district)
        {
            String sql = "select * from rest_information where rest_district=@rest_district1";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_district1",SqlDbType.VarChar)
            };
            param[0].Value = rest_district;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据名称查询餐厅返回数据表
        public DataTable select_restaurant_by_name_dt(string rest_name)
        {
            String sql = "select * from rest_information where rest_name=@rest_name";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_name",SqlDbType.VarChar)
            };
            param[0].Value = rest_name;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }
        //根据ID号查询餐厅信息返回数据行
        public DataRow select_restaurant_dr(int ID)
        {
            String sql = "select * from rest_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            Restaurant rest = new Restaurant();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            DataRow dr = dt.Rows[0];
            return dr;
        }
        //根据ID号查询餐厅信息返回数据表
        public DataTable select_restaurant_dt(int ID)
        {
            String sql = "select * from rest_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            Restaurant rest = new Restaurant();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //获取未通过审核餐厅信息
        public DataTable showUnAduit()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            DataTable table0 = new DataTable();

            using (SqlConnection sqlcon = new SqlConnection(connStr))
            {
                sqlcon.Open();
                string sql2 = @"select ID,rest_name,rest_telephone,rest_state from rest_information where rest_state=0";

                SqlDataAdapter sqlada1 = new SqlDataAdapter(sql2, sqlcon);
                DataSet ds = new DataSet();
                ds.Clear();

                sqlada1.Fill(ds, "table1");

                table0 = ds.Tables["table1"];
            }
            return table0;
        }

        //获取已通过审核餐厅信息
        public DataTable showAduit()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            DataTable table0 = new DataTable();

            using (SqlConnection sqlcon = new SqlConnection(connStr))
            {
                sqlcon.Open();
                string sql2 = @"select ID,rest_name,rest_telephone from rest_information where rest_state=1";

                SqlDataAdapter sqlada1 = new SqlDataAdapter(sql2, sqlcon);
                DataSet ds = new DataSet();
                ds.Clear();

                sqlada1.Fill(ds, "table1");

                table0 = ds.Tables["table1"];
            }
            return table0;
        }

        //修改餐厅审核状态
        public int Update_info(int ID, int states)
        {
            String sql = "update rest_information set rest_state=@rest_state where ID=@ID";
            SqlParameter[] param =
            {
                
                new SqlParameter("@rest_state",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int)
            };

            param[0].Value = states;
            param[1].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //上传服务及优惠信息
        public int Up_service_dis(int rest_privilege, int rest_service1, DateTime begin, DateTime end, int ID)
        {

            string sql = "update rest_information set rest_service=@rest_service1,rest_privilege=@rest_privilege1,begin_date=@begin_date1,end_date=@end_date1 where ID=@id";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_privilege1",SqlDbType.Int),
                new SqlParameter("@rest_service1",SqlDbType.Int),
                new SqlParameter("@begin_date1",SqlDbType.Date),
                new SqlParameter("@end_date1",SqlDbType.Date),
                new SqlParameter("@id",ID)
            };
            param[0].Value = rest_privilege;
            param[1].Value = rest_service1;
            param[2].Value = begin;
            param[3].Value = end;
            param[4].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //查找餐厅表前3项
        public List<Restaurant> select_top_restaurant()
        {
            String sql = "select top 3 * from rest_information";
            List<Restaurant> rests = new List<Restaurant>();
            Restaurant rest = new Restaurant();
            DataTable dt = SqlHelper.Execute_Select(sql);
            foreach (DataRow dr in dt.Rows)
            {
                rest = DataRowToRestaurant(dr);
                rests.Add(rest);
            }
            return rests;
        }

        //根据餐厅ID获取优惠信息
        public DataTable Load_Service_dis(int id)
        {
            string sql = "select rest_privilege,rest_service from rest_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = id;
            return SqlHelper.ExecuteSelect(sql, param);
        }

        //提取所有餐厅信息返回信息表
        public DataTable GetAllRestaurant_dt()
        {
            String sql = "select * from rest_information";
            DataTable dt = SqlHelper.ExecuteSelect(sql);
            return dt;
        }

        //根据手机账号查询餐厅信息返回数据表
        public DataTable select_restaurant_by_telephone_dt(string rest_telephone)
        {
            String sql = "select * from rest_information where rest_telephone=@rest_telephone";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_telephone",SqlDbType.VarChar)
            };
            param[0].Value = rest_telephone;
            Restaurant rest = new Restaurant();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据手机号重置密码
        public int Update_Restaurant_pass(string phone, string new_pass)
        {
            String sql = "update rest_information set rest_password=@rest_password where rest_telephone=@new_phone";
            SqlParameter[] param =
            {
                new SqlParameter("@rest_password",SqlDbType.VarChar),
                new SqlParameter("@new_phone",SqlDbType.VarChar),
            };
            param[0].Value = new_pass;
            param[1].Value = phone;
            return SqlHelper.ExecuteQuery(sql, param);
        }
    }
}

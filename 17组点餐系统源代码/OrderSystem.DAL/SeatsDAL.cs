using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;
using System.Data.SqlClient;
using System.Data;

namespace OrderSystem.DAL
{
    public class SeatsDAL
    {
        //加入座位函数
        public int Add_seat(Seats se)
        {
            String sql = "insert into seat_information values(@restaurant_ID,@seat_style,@seat_use,@seat_left,@seat_all)";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@seat_style",SqlDbType.Int),
                new SqlParameter("@seat_use",SqlDbType.Int),
                new SqlParameter("@seat_left",SqlDbType.Int),
                new SqlParameter("@seat_all",SqlDbType.Int),
            };
            param[0].Value = se.restaurant_ID;
            param[1].Value = se.seat_style;
            param[2].Value = se.seat_use;
            param[3].Value = se.seat_all - se.seat_use;
            param[4].Value = se.seat_all;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据餐厅号删除座位
        public int delete_seat(int restaurant_ID)
        {
            String sql = "delete from seat_information where restaurant_ID=@restaurant_ID";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int)
            };
            param[0].Value = restaurant_ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }
        //数据行转化为seat实例
        public Seats DataRowToSeat(DataRow dr)
        {
            Seats se = new Seats();
            se.restaurant_ID = (int)dr["restaurant_ID"];
            se.seat_style = (int)dr["seat_style"];
            se.seat_use = (int)dr["seat_use"];
            se.seat_left = (int)dr["seat_left"];
            se.seat_all = (int)dr["seat_all"];
            return se;
        }
        //根据餐厅ID查询座位
        public Seats select_seat(int restaurant_ID)
        {
            String sql = "select * from seat_information where restaurant_ID=@restaurant_ID";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int)
            };
            param[0].Value = restaurant_ID;
            Seats se = new Seats();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                se = DataRowToSeat(dr);
            }
            return se;
        }
        //根据餐厅ID修改座位
        public int update_seat(int restaurant_ID, Seats se)
        {
            String sql = "update seat_information set seat_style=@seat_style,seat_use=@seat_use,seat_left=@seat_left where restaurant_ID=@restaurant_ID";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@seat_style",SqlDbType.Int),
                new SqlParameter("@seat_use",SqlDbType.Int),
                new SqlParameter("@seat_left",SqlDbType.Int),
                new SqlParameter("@seat_all",SqlDbType.Int)
            };
            param[0].Value = restaurant_ID;
            param[1].Value = se.seat_style;
            param[2].Value = se.seat_use;
            param[3].Value = se.seat_all - se.seat_use;
            param[4].Value = se.seat_all;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据餐厅ID和座位类型修改座位数量
        public DataTable Update_seat(int restaurant_ID, int seat_style, int seat_left)
        {
            String sql = "update seat_information set seat_left=@new_seat_left where restaurant_ID=@restaurant_ID and seat_style=@seat_style";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@seat_style",SqlDbType.Int),
                new SqlParameter("@new_seat_left",SqlDbType.Int) 
            };
            param[0].Value = restaurant_ID;
            param[1].Value = seat_style;
            param[2].Value = seat_left;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据餐厅ID和座位类型查询座位
        public DataTable select_seat(int restaurant_ID, int seat_style)
        {
            String sql = "select * from seat_information where restaurant_ID=@restaurant_ID and seat_style=@seat_style";
            SqlParameter[] param =
            {
                new SqlParameter("@restaurant_ID",SqlDbType.Int),
                new SqlParameter("@seat_style",SqlDbType.Int)         
            };
            param[0].Value = restaurant_ID;
            param[1].Value = seat_style;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }
        
    }
}

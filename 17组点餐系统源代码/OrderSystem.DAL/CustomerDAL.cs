using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.Model;
using System.Data.SqlClient;
using System.Data;

namespace OrderSystem.DAL
{
    public class CustomerDAL
    {
        //加入顾客函数
        public int Add_customer(Customer cus)
        {
            String sql = "insert into customer_information(cus_nickname,cus_password,cus_telephone,cus_question,cus_answer,cus_score) values(@cus_nickname,@cus_password,@cus_telephone,@cus_question,@cus_answer,@cus_score)";

            SqlParameter[] param =
            {
                new SqlParameter("@cus_nickname",SqlDbType.VarChar),
                new SqlParameter("@cus_password",SqlDbType.VarChar),
                new SqlParameter("@cus_telephone",SqlDbType.VarChar),
                new SqlParameter("@cus_question",SqlDbType.VarChar),
                new SqlParameter("@cus_answer",SqlDbType.VarChar),
                new SqlParameter("@cus_score",SqlDbType.Int),
            };
            param[0].Value = cus.cus_nickname;
            param[1].Value = cus.cus_password;
            param[2].Value = cus.cus_telephone;
            param[3].Value = cus.cus_question;
            param[4].Value = cus.cus_answer;
            param[5].Value = cus.cus_score;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //修改顾客信息函数
        public int Update_customer(Customer cus, int ID)
        {
            String sql = "update customer_information set cus_nickname=@cus_nickname,cus_password=@cus_password,cus_telephone=@cus_telephone,cus_question=@cus_question,cus_answer=@cus_answer,cus_score=@cus_score where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@cus_nickname",SqlDbType.VarChar),
                new SqlParameter("@cus_password",SqlDbType.VarChar),
                new SqlParameter("@cus_telephone",SqlDbType.VarChar),
                new SqlParameter("@cus_question",SqlDbType.VarChar),
                new SqlParameter("@cus_answer",SqlDbType.VarChar),
                new SqlParameter("@cus_score",SqlDbType.Int),
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = cus.cus_nickname;
            param[1].Value = cus.cus_password;
            param[2].Value = cus.cus_telephone;
            param[3].Value = cus.cus_question;
            param[4].Value = cus.cus_answer;
            param[5].Value = cus.cus_score;
            param[6].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }


        //根据ID号查询顾客信息
        public Customer select_customer(int ID)
        {
            String sql = "select * from customer_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            Customer cus = new Customer();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                cus = DataRowToCustomer(dr);
            }
            return cus;
        }


        //提取所有顾客信息
        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            String sql = "select * from customer_information";
            DataTable dt = SqlHelper.ExecuteSelect(sql);
            foreach (DataRow dr in dt.Rows)
            {
                Customer cus = DataRowToCustomer(dr);
                customers.Add(cus);
            }
            return customers;
        }
        //顾客信息数据行转化为customer实例
        public Customer DataRowToCustomer(DataRow dr)
        {
            Customer cus = new Customer();
            cus.ID = (int)dr["ID"];
            cus.cus_nickname = dr["cus_nickname"].ToString();
            cus.cus_password = dr["cus_password"].ToString();
            cus.cus_telephone = dr["cus_telephone"].ToString();
            cus.cus_question = dr["cus_question"].ToString();
            cus.cus_answer = dr["cus_answer"].ToString();
            cus.cus_score = (int)dr["cus_score"];
            return cus;
        }

        //根据ID号删除顾客
        public int delete_customer(int ID)
        {
            String sql = "delete from customer_information where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //提取所有顾客信息返回数据表
        public DataTable GetAllCustomer_dt()
        {
            String sql = "select * from customer_information";
            DataTable dt = SqlHelper.ExecuteSelect(sql);
            return dt;
        }

        //根据电话号选择顾客返回数据表
        public DataTable select_customer_by_telephone_dt(string cus_telephone)
        {
            String sql = "select * from customer_information where cus_telephone=@cus_telephone";
            SqlParameter[] param =
            {
                new SqlParameter("@cus_telephone",SqlDbType.VarChar)
            };
            param[0].Value = cus_telephone;
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            return dt;
        }

        //根据手机号重置密码函数
        public int Update_customer_pass(string phone,string new_pass)
        {
            String sql = "update customer_information set cus_password=@cus_password where cus_telephone=@new_phone";
            SqlParameter[] param =
            {
                new SqlParameter("@cus_password",SqlDbType.VarChar),
                new SqlParameter("@new_phone",SqlDbType.VarChar),
            };
            param[0].Value = new_pass;
            param[1].Value = phone;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        //根据顾客ID上传积分信息
        public int Update_customer_score(int ID, int cus_score)
        {
            String sql = "update customer_information set cus_score=@cus_score where ID=@ID";
            SqlParameter[] param =
            {
                new SqlParameter("@cus_score",SqlDbType.VarChar),
                new SqlParameter("@ID",SqlDbType.VarChar),
            };
            param[0].Value = cus_score;
            param[1].Value = ID;
            return SqlHelper.ExecuteQuery(sql, param);
        }
        //根据电话号码查询顾客
        public Customer select_customer_by_teleohone(string tele)
        {
            String sql = "select * from customer_information where cus_telephone=@cus_telephone";
            SqlParameter param = new SqlParameter("@cus_telephone",SqlDbType.VarChar);
            Customer cus = new Customer();
            param.Value = tele;
            DataTable dt = SqlHelper.ExecuteSelect(sql,param);
            return  cus = DataRowToCustomer(dt.Rows[0]);
        }
    }
}

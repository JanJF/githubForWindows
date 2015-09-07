using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;

namespace OrderSystemBLL
{
    public class RestaurantBLL
    {
        RestaurantDAL dal = new RestaurantDAL();
        public bool Add_restaurant(Restaurant rest)
        {
            return dal.Add_restaurant(rest) > 0;
        }

        public bool Update_restaurant(Restaurant rest, int ID)
        {
            return dal.Update_restaurant(rest, ID) > 0;
        }

        public Restaurant Select_restaurant(int ID)
        {
            return dal.select_restaurant(ID);
        }

        public bool Delete_restaurant(int ID)
        {
            return dal.delete_restaurant(ID) > 0;
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return dal.GetAllRestaurant();
        }

        public List<Restaurant> Select_Restaurant_By_Name(string rest_name)
        {
            return dal.select_restaurant_by_name(rest_name);
        }
        public List<Restaurant> Select_Restaurant_By_District(string rest_district)
        {
            return dal.select_restaurant_by_district(rest_district);
        }

        //修改餐厅审核信息
        public bool Update_info(int ID, int states)
        {
            return dal.Update_info(ID, states) > 0;
        }

        //上传服务及优惠信息
        public bool Up_service_dis(int rest_privilege, int rest_service1, DateTime begin, DateTime end, int ID)
        {
            return dal.Up_service_dis(rest_privilege, rest_service1, begin, end, ID) > 0;
        }

        //获取优惠信息
        public DataTable Load_Service_dis(int id)
        {
            return dal.Load_Service_dis(id);
        }

        //根据手机号获取餐厅信息
        public DataTable select_restaurant_by_telephone_dt(string rest_telephone)
        {
            return dal.select_restaurant_by_telephone_dt(rest_telephone);
        }

        //根据手机号重置密码
        public bool Update_Restaurant_pass(string phone, string new_pass)
        {
            return dal.Update_Restaurant_pass(phone, new_pass) > 0;
        }

        //查找餐厅表前3项
        public List<Restaurant> select_top_restaurant()
        {
            return dal.select_top_restaurant();
        }

        //根据ID号查询餐厅信息
        public Restaurant select_restaurant(int ID)
        {
            return dal.select_restaurant(ID);
        }

        //提取所有餐厅信息返回信息表
        public DataTable GetAllRestaurant_dt()
        {
            return dal.GetAllRestaurant_dt();
        }

        
    }
    
}

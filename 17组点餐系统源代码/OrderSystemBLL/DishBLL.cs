using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;

namespace OrderSystemBLL
{
    public class DishBLL
    {
        DishDAL dal = new DishDAL();
        public bool Add_dish(Dish dis)
        {
            return dal.Add_dish(dis) > 0;
        }

        public bool Update_dish(Dish dis, int ID)
        {
            return dal.Update_dish(dis, ID) > 0;
        }

        public List<Dish> Select_Dish(int dish_restaurant)
        {
            return dal.select_dish(dish_restaurant);
        }
        public List<Dish> Select_Dish_By_Name(string dish_name)
        {
            return dal.select_dish_by_name(dish_name);
        }

        //根据菜名和餐厅ID查找菜品ID
        public DataTable findDishID_By_restId_dishN(int resId, string dishName)
        {
            
            return dal.findDishID_By_restId_dishN(resId,dishName) ;
        }

        //根据餐厅ID删除菜品信息
        public bool delete_Dish(int restaurant_id)
        {
            return dal.delete_dish(restaurant_id) > 0;
        }
        //选择菜色表前3行
        public List<Dish> select_top_dish()
        {
            return dal.select_top_dish();
        }
        //根据菜品ID查询菜品
        public Dish select_dish_by_ID(int ID)
        {
            return dal.select_dish_by_ID(ID);
        }

        //根据餐厅ID查找非特色菜
        public List<Dish> select_dish0_By_dish_restaurant(int dish_restaurant)
        {
            return dal.select_dish0_By_dish_restaurant(dish_restaurant);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;

namespace OrderSystemBLL
{
    public class SeatsBLL
    {
        SeatsDAL dal = new SeatsDAL();
        public bool Add_Seat(Seats dat)
        {
            return dal.Add_seat(dat) > 0;
        }
        public bool Delete_Seat(int restaurant_ID)
        {
            return dal.delete_seat(restaurant_ID) > 0;
        }
        public Seats Select_Seat(int restaurant_ID)
        {
            return dal.select_seat(restaurant_ID);
        }
        //public bool Update_Seat(int restaurant_ID, Seats se)
        //{
        //    return dal.update_seat(restaurant_ID, se) > 0;
        //}

        //根据餐厅ID和座位类型修改座位数量
        public DataTable Update_seat(int restaurant_ID, int seat_style, int seat_left)
        {
            return dal.Update_seat(restaurant_ID, seat_style, seat_left);
        }

        public DataTable select_seat(int restaurant_ID, int seat_style)
        {
            return dal.select_seat(restaurant_ID, seat_style);
        }
    }
}

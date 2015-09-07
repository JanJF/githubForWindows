using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;
using System.Data;

namespace OrderSystemBLL
{
    public class CustomerBLL
    {
        CustomerDAL dal = new CustomerDAL();

        public bool Add_customer(Customer cus)
        {
            return dal.Add_customer(cus) > 0;
        }

        public bool Update_customer(Customer cus, int ID)
        {
            return dal.Update_customer(cus, ID) > 0;
        }

        public Customer Select_customer(int ID)
        {
            return dal.select_customer(ID);
        }

        public bool Delete_customer(int ID)
        {
            return dal.delete_customer(ID) > 0;
        }

        public List<Customer> GetAllCustomer()
        {
            return dal.GetAllCustomer();
        }

        public DataTable select_customer_by_telephone_dt(string cus_telephone)
        {
            return dal.select_customer_by_telephone_dt(cus_telephone);
        }

        public bool Update_customer_pass(string phone, string new_pass)
        {
            return dal.Update_customer_pass(phone,new_pass) > 0;
        }

        public bool Update_customer_score(int ID, int cus_score)
        {
            return dal.Update_customer_score(ID, cus_score) > 0;
        }
        public Customer Select_customer_By_Telephone(String Telephone)
        {
            return dal.select_customer_by_teleohone(Telephone);
        }
    }
}

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
    public class PictureDAL
    {
        public int Add_picture(Picture pic)
        {
            String sql = "insert into picture_information values(@picture,@pic_style,@pic_owner)";
            SqlParameter[] param =
            {
                new SqlParameter("@picture",SqlDbType.VarBinary),
                new SqlParameter("@pic_style",SqlDbType.Int),
                new SqlParameter("@pic_owner",SqlDbType.Int)
            };
            param[0].Value = pic.image;
            param[1].Value = pic.pic_style;
            param[2].Value = pic.pic_owner;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        public int Update_picture(Picture pic, int ID)
        {
            String sql = "update picture_information set picture=@picture,pic_style=@pic_style,pic_owner=@pic_owner";
            SqlParameter[] param =
            {
                new SqlParameter("@picture",SqlDbType.VarBinary),
                new SqlParameter("@pic_style",SqlDbType.Int),
                new SqlParameter("@pic_owner",SqlDbType.Int)
            };
            param[0].Value = pic.image;
            param[1].Value = pic.pic_style;
            param[2].Value = pic.pic_owner;
            return SqlHelper.ExecuteQuery(sql, param);
        }

        public Picture select_picture(int pic_style, int pic_owner)
        {
            String sql = "select * from picture_information where pic_style=@pic_style and pic_owner=@pic_owner";
            SqlParameter[] param =
            {
                new SqlParameter("@pic_style",SqlDbType.Int),
                new SqlParameter("@pic_owner",SqlDbType.Int)
            };
            param[0].Value = pic_style;
            param[1].Value = pic_owner;
            Picture pic = new Picture();
            DataTable dt = SqlHelper.ExecuteSelect(sql, param);
            foreach (DataRow dr in dt.Rows)
            {
                pic = DataRowToPicture(dr);
            }
            return pic;
        }

        public Picture DataRowToPicture(DataRow dr)
        {
            Picture pic = new Picture();
            pic.image = (byte[])dr["picture"];
            pic.pic_owner = (int)dr["pic_owner"];
            pic.pic_style = (int)dr["pic_style"];
            return pic;
        }

        public int delete_picture(int picture_style, int picture_owner)
        {
            String sql = "delete from picture_information where pic_style=@picture_style and pic_owner=@picture_owner";
            SqlParameter[] param =
          {
            new SqlParameter("@picture_style",SqlDbType.Int),
            new SqlParameter("@picture_owner",SqlDbType.Int)
          };
            param[0].Value = picture_style;
            param[1].Value = picture_owner;
            return SqlHelper.ExecuteQuery(sql, param);

        }
    
    
     }
}

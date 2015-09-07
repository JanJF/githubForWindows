using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrderSystem.DAL;
using OrderSystem.Model;

namespace OrderSystemBLL
{
    public class PictureBLL
    {
        PictureDAL dal = new PictureDAL();
        public bool delete_picture(int picture_style, int picture_owner)
        {
            return dal.delete_picture(picture_style, picture_owner) > 0;
        }

        public Picture select_picture(int pic_style, int pic_owner)
        {
            return dal.select_picture(pic_style,pic_owner);
        }

    }
}

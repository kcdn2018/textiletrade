using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.IO;

namespace 纺织贸易管理系统
{
    public static class MadanPictureService
    {
        public static List<MadanPicture> GetMadanPicturelst(Expression<Func<MadanPicture, bool>> func)
         {
            return  Connect.CreatConnect().Query<MadanPicture>(func);
         }
        public static MadanPicture GetOneMadanPicture(Expression<Func<MadanPicture, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<MadanPicture>(func);
         }
        public static void InsertMadanPicturelst(List<MadanPicture> MadanPictureObjs)
         {
            foreach(MadanPicture OBJ in MadanPictureObjs)
             {
              Connect.CreatConnect().Insert<MadanPicture>(OBJ);
             }
         }
        public static void InsertMadanPicture(MadanPicture MadanPictureObj)
         {
            Connect.CreatConnect().Insert(MadanPictureObj);
         }
        public static void UpdateMadanPicture(MadanPicture MadanPictureObj,Expression<Func<MadanPicture, bool>> func)
         {
              Connect.CreatConnect().Update<MadanPicture>(MadanPictureObj, func);
         }
        public static void DeleteMadanPicture(Expression<Func<MadanPicture, bool>> func)
         {
              Connect.CreatConnect().Delete<MadanPicture>(func);
         }
        public static byte[] ExcelToByte(string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    byte[] infbytes = new byte[(int)fs.Length];
                    fs.Read(infbytes, 0, infbytes.Length);
                    fs.Close();
                    return infbytes;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}

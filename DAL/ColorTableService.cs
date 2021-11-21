using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ColorTableService
    {
        public static List<ColorTable> GetColorTablelst(Expression<Func<ColorTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<ColorTable>(func);
         }
        public static ColorTable GetOneColorTable(Expression<Func<ColorTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ColorTable>(func);
         }
        public static void InsertColorTablelst(List<ColorTable> ColorTableObjs)
         {
            foreach(ColorTable OBJ in ColorTableObjs)
             {
              Connect.CreatConnect().Insert<ColorTable>(OBJ);
             }
         }
        public static void InsertColorTable(ColorTable ColorTableObj)
         {
              Connect.CreatConnect().Insert<ColorTable>(ColorTableObj);
         }
        public static void UpdateColorTable(ColorTable ColorTableObj,Expression<Func<ColorTable, bool>> func)
         {
              Connect.CreatConnect().Update<ColorTable>(ColorTableObj, func);
         }
        public static void DeleteColorTable(Expression<Func<ColorTable, bool>> func)
         {
              Connect.CreatConnect().Delete<ColorTable>(func);
         }
    }
}

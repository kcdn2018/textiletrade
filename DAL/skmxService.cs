using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class skmxService
    {
        public static List<skmx> Getskmxlst(Expression<Func<skmx, bool>> func)
         {
            return  Connect.CreatConnect().Query<skmx>(func);
         }
        public static skmx GetOneskmx(Expression<Func<skmx, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<skmx>(func);
         }
        public static void Insertskmxlst(List<skmx> skmxObjs)
         {
            foreach(skmx OBJ in skmxObjs)
             {
              Connect.CreatConnect().Insert<skmx>(OBJ);
             }
         }
        public static void Insertskmx(skmx skmxObj)
         {
              Connect.CreatConnect().Insert<skmx>(skmxObj);
         }
        public static void Updateskmx(skmx skmxObj,Expression<Func<skmx, bool>> func)
         {
              Connect.CreatConnect().Update<skmx>(skmxObj, func);
         }
        public static void Deleteskmx(Expression<Func<skmx, bool>> func)
         {
              Connect.CreatConnect().Delete<skmx>(func);
         }
    }
}

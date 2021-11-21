using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class shengchandanqitayaoqiuService
    {
        public static List<shengchandanqitayaoqiu> Getshengchandanqitayaoqiulst(Expression<Func<shengchandanqitayaoqiu, bool>> func)
         {
            return  Connect.CreatConnect().Query<shengchandanqitayaoqiu>(func);
         }
        public static shengchandanqitayaoqiu GetOneshengchandanqitayaoqiu(Expression<Func<shengchandanqitayaoqiu, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<shengchandanqitayaoqiu>(func);
         }
        public static void Insertshengchandanqitayaoqiulst(List<shengchandanqitayaoqiu> shengchandanqitayaoqiuObjs)
         {
            foreach(shengchandanqitayaoqiu OBJ in shengchandanqitayaoqiuObjs)
             {
              Connect.CreatConnect().Insert<shengchandanqitayaoqiu>(OBJ);
             }
         }
        public static void Insertshengchandanqitayaoqiu(shengchandanqitayaoqiu shengchandanqitayaoqiuObj)
         {
              Connect.CreatConnect().Insert<shengchandanqitayaoqiu>(shengchandanqitayaoqiuObj);
         }
        public static void Updateshengchandanqitayaoqiu(shengchandanqitayaoqiu shengchandanqitayaoqiuObj,Expression<Func<shengchandanqitayaoqiu, bool>> func)
         {
              Connect.CreatConnect().Update<shengchandanqitayaoqiu>(shengchandanqitayaoqiuObj, func);
         }
        public static void Deleteshengchandanqitayaoqiu(Expression<Func<shengchandanqitayaoqiu, bool>> func)
         {
              Connect.CreatConnect().Delete<shengchandanqitayaoqiu>(func);
         }
    }
}

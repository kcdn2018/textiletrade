using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class GongYiYaoqiuService
    {
        public static List<GongYiYaoqiu> GetGongYiYaoqiulst(Expression<Func<GongYiYaoqiu, bool>> func)
         {
            return  Connect.CreatConnect().Query<GongYiYaoqiu>(func);
         }
        public static List<GongYiYaoqiu> GetGongYiYaoqiulst()
        {
            return Connect.CreatConnect().Query<GongYiYaoqiu>();
        }
        public static GongYiYaoqiu GetOneGongYiYaoqiu(Expression<Func<GongYiYaoqiu, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<GongYiYaoqiu>(func);
         }
        public static void InsertGongYiYaoqiulst(List<GongYiYaoqiu> GongYiYaoqiuObjs)
         {
            foreach(GongYiYaoqiu OBJ in GongYiYaoqiuObjs)
             {
              Connect.CreatConnect().Insert<GongYiYaoqiu>(OBJ);
             }
         }
        public static void InsertGongYiYaoqiu(GongYiYaoqiu GongYiYaoqiuObj)
         {
              Connect.CreatConnect().Insert<GongYiYaoqiu>(GongYiYaoqiuObj);
         }
        public static void UpdateGongYiYaoqiu(GongYiYaoqiu GongYiYaoqiuObj,Expression<Func<GongYiYaoqiu, bool>> func)
         {
              Connect.CreatConnect().Update<GongYiYaoqiu>(GongYiYaoqiuObj, func);
         }
        public static void DeleteGongYiYaoqiu(Expression<Func<GongYiYaoqiu, bool>> func)
         {
              Connect.CreatConnect().Delete<GongYiYaoqiu>(func);
         }
    }
}

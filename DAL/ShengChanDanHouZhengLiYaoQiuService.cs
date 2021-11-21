using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ShengChanDanHouZhengLiYaoQiuService
    {
        public static List<ShengChanDanHouZhengLiYaoQiu> GetShengChanDanHouZhengLiYaoQiulst(Expression<Func<ShengChanDanHouZhengLiYaoQiu, bool>> func)
         {
            return  Connect.CreatConnect().Query<ShengChanDanHouZhengLiYaoQiu>(func);
         }
        public static ShengChanDanHouZhengLiYaoQiu GetOneShengChanDanHouZhengLiYaoQiu(Expression<Func<ShengChanDanHouZhengLiYaoQiu, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ShengChanDanHouZhengLiYaoQiu>(func);
         }
        public static void InsertShengChanDanHouZhengLiYaoQiulst(List<ShengChanDanHouZhengLiYaoQiu> ShengChanDanHouZhengLiYaoQiuObjs)
         {
            foreach(ShengChanDanHouZhengLiYaoQiu OBJ in ShengChanDanHouZhengLiYaoQiuObjs)
             {
              Connect.CreatConnect().Insert<ShengChanDanHouZhengLiYaoQiu>(OBJ);
             }
         }
        public static void InsertShengChanDanHouZhengLiYaoQiu(ShengChanDanHouZhengLiYaoQiu ShengChanDanHouZhengLiYaoQiuObj)
         {
              Connect.CreatConnect().Insert<ShengChanDanHouZhengLiYaoQiu>(ShengChanDanHouZhengLiYaoQiuObj);
         }
        public static void UpdateShengChanDanHouZhengLiYaoQiu(ShengChanDanHouZhengLiYaoQiu ShengChanDanHouZhengLiYaoQiuObj,Expression<Func<ShengChanDanHouZhengLiYaoQiu, bool>> func)
         {
              Connect.CreatConnect().Update<ShengChanDanHouZhengLiYaoQiu>(ShengChanDanHouZhengLiYaoQiuObj, func);
         }
        public static void DeleteShengChanDanHouZhengLiYaoQiu(Expression<Func<ShengChanDanHouZhengLiYaoQiu, bool>> func)
         {
              Connect.CreatConnect().Delete<ShengChanDanHouZhengLiYaoQiu>(func);
         }
    }
}

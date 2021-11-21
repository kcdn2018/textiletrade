using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class YuanGongTableService
    {
        public static List<YuanGongTable> GetYuanGongTablelst(Expression<Func<YuanGongTable ,bool >> func)
         {
            return  Connect.CreatConnect().Query<YuanGongTable>(func);
         }
        public static List<YuanGongTable> GetYuanGongTablelst()
        {
            return Connect.CreatConnect().Query<YuanGongTable>();
        }
        public static YuanGongTable GetOneYuanGongTable(Expression<Func<YuanGongTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<YuanGongTable>(func);
         }
        public static void InsertYuanGongTablelst(List<YuanGongTable> YuanGongTableObjs)
         {
            foreach(YuanGongTable OBJ in YuanGongTableObjs)
             {
              Connect.CreatConnect().Insert<YuanGongTable>(OBJ);
             }
         }
        public static void InsertYuanGongTable(YuanGongTable YuanGongTableObj)
         {
              Connect.CreatConnect().Insert<YuanGongTable>(YuanGongTableObj);
         }
        public static void UpdateYuanGongTable(YuanGongTable YuanGongTableObj, Expression<Func<YuanGongTable, bool>> func)
         {
              Connect.CreatConnect().Update<YuanGongTable>(YuanGongTableObj,func);
         }
        public static void DeleteYuanGongTable(Expression<Func<YuanGongTable, bool>> func)
         {
              Connect.CreatConnect().Delete<YuanGongTable>(func);
         }
        /// <summary>
        /// 加载所有部门
        /// </summary>
        /// <returns></returns>
        public static List <string> 加载部门()
        {
           var l= Connect.CreatConnect().Query<YuanGongTable>();
            return l.Select(x => x.Department).Distinct().ToList();
        }
    }
}

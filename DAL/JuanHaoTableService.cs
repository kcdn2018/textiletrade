using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class JuanHaoTableService
    {
        public static List<JuanHaoTable> GetJuanHaoTablelst(Expression<Func<JuanHaoTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<JuanHaoTable>(func);
         }
        public static JuanHaoTable GetOneJuanHaoTable(Expression<Func<JuanHaoTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<JuanHaoTable>(func);
         }
        public static void InsertJuanHaoTablelst(List<JuanHaoTable> JuanHaoTableObjs)
         {
            foreach(JuanHaoTable OBJ in JuanHaoTableObjs)
             {
              Connect.CreatConnect().Insert<JuanHaoTable>(OBJ);
             }
         }
        public static void InsertJuanHaoTable(JuanHaoTable JuanHaoTableObj)
         {
              Connect.CreatConnect().Insert<JuanHaoTable>(JuanHaoTableObj);
         }
        /// <summary>
        /// 批量修改卷号
        /// </summary>
        /// <param name="Setfunc"></param>
        /// <param name="func"></param>
        public static void UpdateJuanHaoTable(string setstr, Expression<Func<JuanHaoTable , bool>> func)
        {
              var ret=Connect.CreatConnect().Update<JuanHaoTable>(setstr, func);
        }
        /// <summary>
        /// 批量修改卷号
        /// </summary>
        /// <param name="Setfunc"></param>
        /// <param name="func"></param>
        public static void UpdateJuanHaoTableList(Expression<Func<JuanHaoTable, bool>> func,List<JuanHaoTable > juanHaoTables )
        {
            var ret = Connect.CreatConnect().Update<JuanHaoTable>(func,juanHaoTables );
        }
        public static void UpdateJuanHaoTable(JuanHaoTable JuanHaoTableObj, Expression<Func<JuanHaoTable, bool>> func)
         {
              Connect.CreatConnect().Update<JuanHaoTable>(JuanHaoTableObj,func);
         }
        public static void DeleteJuanHaoTable(Expression<Func<JuanHaoTable, bool>> func)
         {
              Connect.CreatConnect().Delete<JuanHaoTable>(func);
         }
    }
}

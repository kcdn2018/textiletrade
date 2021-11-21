using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public  class TechnologyTableService
    {
        public static List<TechnologyTable> GetTechnologyTablelst(string WhereString)
         {
            return  Connect.CreatConnect().Query<TechnologyTable>(WhereString);
         }
        public static List<TechnologyTable> GetTechnologyTablelst()
        {
            return Connect.CreatConnect().Query<TechnologyTable>();
        }
        public static TechnologyTable GetOneTechnologyTable(string WhereString)
         {
            return  Connect.CreatConnect().QueryOneResult<TechnologyTable>(WhereString);
         }
        public static void InsertTechnologyTablelst(List<TechnologyTable> TechnologyTableObjs)
         {
            foreach(TechnologyTable OBJ in TechnologyTableObjs)
             {
              Connect.CreatConnect().Insert<TechnologyTable>(OBJ);
             }
         }
        public static void InsertTechnologyTable(TechnologyTable TechnologyTableObj)
         {
              Connect.CreatConnect().Insert<TechnologyTable>(TechnologyTableObj);
         }
        public static void UpdateTechnologyTable(TechnologyTable TechnologyTableObj,string WhereString)
         {
              Connect.CreatConnect().Update<TechnologyTable>(TechnologyTableObj,WhereString);
         }
        public static void DeleteTechnologyTable(string WhereString)
         {
              Connect.CreatConnect().Delete<TechnologyTable>(WhereString);
         }
        public static List<TechnologyTable> GetTechnologyTablelst(Expression<Func<TechnologyTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<TechnologyTable>(func);
         }
        public static TechnologyTable GetOneTechnologyTable(Expression<Func<TechnologyTable ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<TechnologyTable>(func);
         }
        public static void UpdateTechnologyTable(TechnologyTable TechnologyTableObj,Expression<Func<TechnologyTable ,bool>> func)
         {
              Connect.CreatConnect().Update<TechnologyTable>(TechnologyTableObj,func);
         }
        public static void UpdateTechnologyTable(Expression<Func<TechnologyTable ,bool >> TechnologyTableObj, Expression<Func<TechnologyTable, bool>> func)
        {
            Connect.CreatConnect().Update<TechnologyTable>(TechnologyTableObj, func);
        }
        public static void DeleteTechnologyTable(Expression<Func<TechnologyTable ,bool>> func)
         {
              Connect.CreatConnect().Delete<TechnologyTable>(func);
         }
    }
}

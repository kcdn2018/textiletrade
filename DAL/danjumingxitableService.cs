using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class danjumingxitableService
    {
        public static List<danjumingxitable> Getdanjumingxitablelst(string sql)
        {
            return Connect.CreatConnect().Query<danjumingxitable>(sql);
        }
        public static List<danjumingxitable> Getdanjumingxitablelst(Expression<Func<danjumingxitable ,bool >> func)
         {
            return  Connect.CreatConnect().Query<danjumingxitable>(func );
         }
        public static danjumingxitable GetOnedanjumingxitable(Expression<Func<danjumingxitable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<danjumingxitable>(func);
         }
        public static void Insertdanjumingxitablelst(List<danjumingxitable> danjumingxitableObjs)
         {     
              Connect.CreatConnect().Insert<danjumingxitable>(danjumingxitableObjs);
         }
        public static void Insertdanjumingxitable(danjumingxitable danjumingxitableObj)
         {
              Connect.CreatConnect().Insert<danjumingxitable>(danjumingxitableObj);
         }
        public static void Updatedanjumingxitable(danjumingxitable danjumingxitableObj, Expression<Func<danjumingxitable, bool>> func)
         {
              Connect.CreatConnect().Update<danjumingxitable>(danjumingxitableObj,func);
         }
        public static void Updatedanjumingxitable(Expression<Func<danjumingxitable, bool>> UpdateFun, Expression<Func<danjumingxitable, bool>> func)
        {
            Connect.CreatConnect().Update<danjumingxitable>(UpdateFun , func);
        }
        public static void Updatedanjumingxitable(string  UpdateString, Expression<Func<danjumingxitable, bool>> func)
        {
            Connect.CreatConnect().Update<danjumingxitable>(UpdateString , func);
        }
        public static void Deletedanjumingxitable(Expression<Func<danjumingxitable, bool>> func)
         {
              Connect.CreatConnect().Delete<danjumingxitable>(func);
         }
    }
}

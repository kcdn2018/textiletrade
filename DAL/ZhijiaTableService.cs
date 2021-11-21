using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class ZhijiaTableService
    {
        public static List<ZhijiaTable> GetZhijiaTablelst(Expression<Func<ZhijiaTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<ZhijiaTable>(func);
         }
        public static List<ZhijiaTable> GetZhijiaTablelst()
        {
            return Connect.CreatConnect().Query<ZhijiaTable>();
        }
        public static ZhijiaTable GetOneZhijiaTable(Expression<Func<ZhijiaTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<ZhijiaTable>(func);
         }
        public static void InsertZhijiaTablelst(List<ZhijiaTable> ZhijiaTableObjs)
         {
            foreach(ZhijiaTable OBJ in ZhijiaTableObjs)
             {
              Connect.CreatConnect().Insert<ZhijiaTable>(OBJ);
             }
         }
        public static void InsertZhijiaTable(ZhijiaTable ZhijiaTableObj)
         {
              Connect.CreatConnect().Insert<ZhijiaTable>(ZhijiaTableObj);
         }
        public static void UpdateZhijiaTable(ZhijiaTable ZhijiaTableObj,Expression<Func<ZhijiaTable ,bool>> func)
         {
              Connect.CreatConnect().Update<ZhijiaTable>(ZhijiaTableObj,func);
         }
        public static void DeleteZhijiaTable(Expression<Func<ZhijiaTable ,bool>> func)
         {
              Connect.CreatConnect().Delete<ZhijiaTable>(func);
         }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace DAL
{
    public class ZhijiaMingxiTableService
    {
        public static List<ZhijiaMingxiTable> GetZhijiaMingxiTablelst(string WhereString)
        {
            return Connect.CreatConnect().Query<ZhijiaMingxiTable>(WhereString);
        }
        public static ZhijiaMingxiTable GetOneZhijiaMingxiTable(string WhereString)
        {
            return Connect.CreatConnect().QueryOneResult<ZhijiaMingxiTable>(WhereString);
        }
        public static void InsertZhijiaMingxiTablelst(List<ZhijiaMingxiTable> ZhijiaMingxiTableObjs)
        {
            foreach (ZhijiaMingxiTable OBJ in ZhijiaMingxiTableObjs)
            {
                Connect.CreatConnect().Insert<ZhijiaMingxiTable>(OBJ);
            }
        }
        public static void InsertZhijiaMingxiTable(ZhijiaMingxiTable ZhijiaMingxiTableObj)
        {
            Connect.CreatConnect().Insert<ZhijiaMingxiTable>(ZhijiaMingxiTableObj);
        }
        public static void UpdateZhijiaMingxiTable(ZhijiaMingxiTable ZhijiaMingxiTableObj, string WhereString)
        {
            Connect.CreatConnect().Update<ZhijiaMingxiTable>(ZhijiaMingxiTableObj, WhereString);
        }
        public static void DeleteZhijiaMingxiTable(string WhereString)
        {
            Connect.CreatConnect().Delete<ZhijiaMingxiTable>(WhereString);
        }
        public static List<ZhijiaMingxiTable> GetZhijiaMingxiTablelst(Expression<Func<ZhijiaMingxiTable, bool>> func)
        {
            return Connect.CreatConnect().Query<ZhijiaMingxiTable>(func);
        }
        public static ZhijiaMingxiTable GetOneZhijiaMingxiTable(Expression<Func<ZhijiaMingxiTable, bool>> func)
        {
            return Connect.CreatConnect().QueryOneResult<ZhijiaMingxiTable>(func);
        }
        public static void UpdateZhijiaMingxiTable(ZhijiaMingxiTable ZhijiaMingxiTableObj, Expression<Func<ZhijiaMingxiTable, bool>> func)
        {
            Connect.CreatConnect().Update<ZhijiaMingxiTable>(ZhijiaMingxiTableObj, func);
        }
        public static void DeleteZhijiaMingxiTable(Expression<Func<ZhijiaMingxiTable, bool>> func)
        {
            Connect.CreatConnect().Delete<ZhijiaMingxiTable>(func);
        }
    }
}

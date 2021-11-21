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
    public class JiaziTableService
    {
        public static List<JiaziTable> GetJiaziTablelst(string WhereString)
        {
            return Connect.CreatConnect().Query<JiaziTable>(WhereString);
        }
        public static List<JiaziTable> GetJiaziTablelst()
        {
            return Connect.CreatConnect().Query<JiaziTable>();
        }
        public static JiaziTable GetOneJiaziTable(string WhereString)
        {
            return Connect.CreatConnect().QueryOneResult<JiaziTable>(WhereString);
        }
        public static void InsertJiaziTablelst(List<JiaziTable> JiaziTableObjs)
        {
            foreach (JiaziTable OBJ in JiaziTableObjs)
            {
                Connect.CreatConnect().Insert<JiaziTable>(OBJ);
            }
        }
        public static void InsertJiaziTable(JiaziTable JiaziTableObj)
        {
            Connect.CreatConnect().Insert<JiaziTable>(JiaziTableObj);
        }
        public static void UpdateJiaziTable(JiaziTable JiaziTableObj, string WhereString)
        {
            Connect.CreatConnect().Update<JiaziTable>(JiaziTableObj, WhereString);
        }
        public static void DeleteJiaziTable(string WhereString)
        {
            Connect.CreatConnect().Delete<JiaziTable>(WhereString);
        }
        public static List<JiaziTable> GetJiaziTablelst(Expression<Func<JiaziTable, bool>> func)
        {
            return Connect.CreatConnect().Query<JiaziTable>(func);
        }
        public static JiaziTable GetOneJiaziTable(Expression<Func<JiaziTable, bool>> func)
        {
            return Connect.CreatConnect().QueryOneResult<JiaziTable>(func);
        }
        public static void UpdateJiaziTable(JiaziTable JiaziTableObj, Expression<Func<JiaziTable, bool>> func)
        {
            Connect.CreatConnect().Update<JiaziTable>(JiaziTableObj, func);
        }
        public static void UpdateJiaziTable(string  Updatestring, Expression<Func<JiaziTable, bool>> func)
        {
            Connect.CreatConnect().Update<JiaziTable>(Updatestring , func);
        }
        public static void DeleteJiaziTable(Expression<Func<JiaziTable, bool>> func)
        {
            Connect.CreatConnect().Delete<JiaziTable>(func);
        }
    }
 }

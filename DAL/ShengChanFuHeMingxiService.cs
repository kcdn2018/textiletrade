using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace 纺织贸易管理系统
{
    public class ShengChanFuHeMingxiService
    {
        public static List<ShengChanFuHeMingxi> GetShengChanFuHeMingxilst(string WhereString)
        {
            return Connect.CreatConnect().Query<ShengChanFuHeMingxi>(WhereString);
        }
        public static ShengChanFuHeMingxi GetOneShengChanFuHeMingxi(string WhereString)
        {
            return Connect.CreatConnect().QueryOneResult<ShengChanFuHeMingxi>(WhereString);
        }
        public static void InsertShengChanFuHeMingxilst(List<ShengChanFuHeMingxi> ShengChanFuHeMingxiObjs)
        {
            foreach (ShengChanFuHeMingxi OBJ in ShengChanFuHeMingxiObjs)
            {
                Connect.CreatConnect().Insert<ShengChanFuHeMingxi>(OBJ);
            }
        }
        public static void InsertShengChanFuHeMingxi(ShengChanFuHeMingxi ShengChanFuHeMingxiObj)
        {
            Connect.CreatConnect().Insert<ShengChanFuHeMingxi>(ShengChanFuHeMingxiObj);
        }
        public static void UpdateShengChanFuHeMingxi(ShengChanFuHeMingxi ShengChanFuHeMingxiObj, string WhereString)
        {
            Connect.CreatConnect().Update<ShengChanFuHeMingxi>(ShengChanFuHeMingxiObj, WhereString);
        }
        public static void DeleteShengChanFuHeMingxi(string WhereString)
        {
            Connect.CreatConnect().Delete<ShengChanFuHeMingxi>(WhereString);
        }
        public static List<ShengChanFuHeMingxi> GetShengChanFuHeMingxilst(Expression<Func<ShengChanFuHeMingxi, bool>> func)
        {
            return Connect.CreatConnect().Query<ShengChanFuHeMingxi>(func);
        }
        public static ShengChanFuHeMingxi GetOneShengChanFuHeMingxi(Expression<Func<ShengChanFuHeMingxi, bool>> func)
        {
            return Connect.CreatConnect().QueryOneResult<ShengChanFuHeMingxi>(func);
        }
        public static void UpdateShengChanFuHeMingxi(ShengChanFuHeMingxi ShengChanFuHeMingxiObj, Expression<Func<ShengChanFuHeMingxi, bool>> func)
        {
            Connect.CreatConnect().Update<ShengChanFuHeMingxi>(ShengChanFuHeMingxiObj, func);
        }
        public static void DeleteShengChanFuHeMingxi(Expression<Func<ShengChanFuHeMingxi, bool>> func)
        {
            Connect.CreatConnect().Delete<ShengChanFuHeMingxi>(func);
        }
    }
}

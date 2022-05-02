using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class dbService
    {
        public static List<db> Getdblst(Expression<Func<db, bool>> func)
         {            
            return  Connect.CreatConnect().Query<db>(func).OrderByDescending (x=>x.rq).ToList ();
         }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <param name="pagenum">合计页数</param>
        /// <param name="rownum">每页行数</param>
        /// <param name="currenpage">当前页</param>
        /// <returns></returns>
        public static List<db> Getdblst(Expression<Func<db, bool>> func,int pagenum,int rownum,int currenpage,int peixv)
        {
            string wherestring = SQLHelper.SqlSugor.GetWhereByLambda<db>(func,"sqlserver");
            if (peixv == 0)
            {
                string selectstring = "select * from db where " + wherestring + $" order by id desc offset ({currenpage }-1)*{rownum } row fetch next {rownum } row only";
                return Connect.CreatConnect().Query<db>(selectstring);
            }
            else
            {
                string selectstring = "select * from db where " + wherestring + $" order by id desc offset ({currenpage }-1)*{rownum } row fetch next {rownum } row only";
                return Connect.CreatConnect().Query<db>(selectstring);
            }
        }
        public static List<db> Getdblst()
        {
            return Connect.CreatConnect().Query<db>().OrderByDescending(x => x.rq).ToList();
        }
        public static db GetOnedb(Expression<Func<db, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<db>(func);
         }
        public static void Insertdblst(List<db> dbObjs)
         {
            foreach(db OBJ in dbObjs)
             {
              Connect.CreatConnect().Insert<db>(OBJ);
             }
         }
        public static void Insertdb(db dbObj)
         {
              Connect.CreatConnect().Insert<db>(dbObj);
         }
        public static void Updatedb(db dbObj,Expression<Func<db, bool>> func)
         {
              Connect.CreatConnect().Update<db>(dbObj, func);
         }
        public static void Updatedb(string sql)
        {
            Connect.CreatConnect().Update(sql);
        }
        public static void Deletedb(Expression<Func<db, bool>> func)
         {
              Connect.CreatConnect().Delete<db>(func);
         }
        /// <summary>
        /// 检查编号是否重复 重复返回FALSE否则返回TRUE
        /// </summary>
        /// <param name="bianhao"></param>
        /// <returns></returns>
        public static Boolean CheckBianhao(string bianhao)
        {
            var d = GetOnedb(x => x.bh == bianhao);
            return d.bh == string.Empty;
        }
    }
}

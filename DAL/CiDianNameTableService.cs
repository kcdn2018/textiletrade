using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class CiDianNameTableService
    {
        public static List<CiDianNameTable> GetCiDianNameTablelst(Expression<Func<CiDianNameTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<CiDianNameTable>(func);
         }
        public static List<CiDianNameTable> GetCiDianNameTablelst()
        {
            return Connect.CreatConnect().Query<CiDianNameTable>();
        }
        public static CiDianNameTable GetOneCiDianNameTable(Expression<Func<CiDianNameTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<CiDianNameTable>(func);
         }
        public static void InsertCiDianNameTablelst(List<CiDianNameTable> CiDianNameTableObjs)
         {
            foreach(CiDianNameTable OBJ in CiDianNameTableObjs)
             {
              Connect.CreatConnect().Insert<CiDianNameTable>(OBJ);
             }
         }
        public static void InsertCiDianNameTable(CiDianNameTable CiDianNameTableObj)
         {       
                 Connect.CreatConnect().Insert<CiDianNameTable>(CiDianNameTableObj);        
         }
        public static void UpdateCiDianNameTable(CiDianNameTable CiDianNameTableObj,Expression<Func<CiDianNameTable ,bool>> func)
         {
              Connect.CreatConnect().Update<CiDianNameTable>(CiDianNameTableObj,func);
         }
        public static void DeleteCiDianNameTable(Expression<Func<CiDianNameTable, bool>> func)
         {
              Connect.CreatConnect().Delete<CiDianNameTable>( func);
         }
       /// <summary>
       /// 检测疵点名称是否已经有相同的，有返回false 否则返回True
       /// </summary>
       /// <param name="CiDianNameTableObj"></param>
       /// <returns></returns>
        public  static Boolean CheckName(CiDianNameTable CiDianNameTableObj)
        {
            var c = GetOneCiDianNameTable(x => x.CiDianName == CiDianNameTableObj.CiDianName);
            if (! string.IsNullOrEmpty(c.CiDianName ) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

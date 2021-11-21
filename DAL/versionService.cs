using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class versionService
    {
        public static List<version> Getversionlst()
         {
            return  Connect.CreatConnect().Query<version>();
         }
        public static version GetOneversion(Expression<Func<version, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<version>(func);
         }
        public static void Insertversionlst(List<version> versionObjs)
         {
            foreach(version OBJ in versionObjs)
             {
              Connect.CreatConnect().Insert<version>(OBJ);
             }
         }
        public static void Insertversion(version versionObj)
         {
              Connect.CreatConnect().Insert<version>(versionObj);
         }
        public static void Updateversion(version versionObj,Expression<Func<version, bool>> func)
         {
              Connect.CreatConnect().Update<version>(versionObj, func);
         }
        public static void Deleteversion(Expression<Func<version, bool>> func)
         {
              Connect.CreatConnect().Delete<version>(func);
         }
    }
}

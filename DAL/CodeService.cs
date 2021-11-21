using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class CodeService
    {
        public static List<Code> GetCodelst(Expression<Func<Code, bool>> func)
         {
            return  Connect.CreatConnect().Query<Code>(func);
         }
        public static Code GetOneCode(Expression<Func<Code, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<Code>(func);
         }
        public static void InsertCodelst(List<Code> CodeObjs)
         {
            foreach(Code OBJ in CodeObjs)
             {
              Connect.CreatConnect().Insert<Code>(OBJ);
             }
         }
        public static void InsertCode(Code CodeObj)
         {
              Connect.CreatConnect().Insert<Code>(CodeObj);
         }
        public static void UpdateCode(Code CodeObj,Expression<Func<Code, bool>> func)
         {
              Connect.CreatConnect().Update<Code>(CodeObj, func);
         }
        public static void DeleteCode(Expression<Func<Code, bool>> func)
         {
              Connect.CreatConnect().Delete<Code>(func);
         }
    }
}

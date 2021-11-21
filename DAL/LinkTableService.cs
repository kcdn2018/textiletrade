using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class LinkTableService
    {
        public static List<LinkTable> GetLinkTablelst(Expression<Func<LinkTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<LinkTable>(func);
         }
        public static LinkTable GetOneLinkTable(Expression<Func<LinkTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<LinkTable>(func);
         }
        public static void InsertLinkTablelst(List<LinkTable> LinkTableObjs)
         {
            foreach(LinkTable OBJ in LinkTableObjs)
             {
              Connect.CreatConnect().Insert<LinkTable>(OBJ);
             }
         }
        public static void InsertLinkTable(LinkTable LinkTableObj)
         {
              Connect.CreatConnect().Insert<LinkTable>(LinkTableObj);
         }
        public static void UpdateLinkTable(LinkTable LinkTableObj,Expression<Func<LinkTable, bool>> func)
         {
              Connect.CreatConnect().Update<LinkTable>(LinkTableObj, func);
         }
        public static void DeleteLinkTable(Expression<Func<LinkTable, bool>> func)
         {
              Connect.CreatConnect().Delete<LinkTable>(func);
         }
    }
}

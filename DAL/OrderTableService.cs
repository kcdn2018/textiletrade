using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class OrderTableService
    {
        public static List<OrderTable> GetOrderTablelst(string Sqlstring)
        {
            return Connect.CreatConnect().Query<OrderTable>(Sqlstring);
        }
        public static List<OrderTable> GetOrderTablelst(Expression<Func<OrderTable ,bool >> func)
         {
            return  Connect.CreatConnect().Query<OrderTable>(func).OrderByDescending(x => x.delivery ).ToList();
         }
        public static OrderTable GetOneOrderTable(Expression<Func<OrderTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<OrderTable>(func);
         }
        public static void InsertOrderTablelst(List<OrderTable> OrderTableObjs)
         {
            foreach(OrderTable OBJ in OrderTableObjs)
             {
              Connect.CreatConnect().Insert<OrderTable>(OBJ);
             }
         }
        public static void InsertOrderTable(OrderTable OrderTableObj)
         {
              Connect.CreatConnect().Insert<OrderTable>(OrderTableObj);
         }
        public static void UpdateOrderTable(OrderTable OrderTableObj, Expression<Func<OrderTable, bool>> func)
         {
              Connect.CreatConnect().Update<OrderTable>(OrderTableObj,func);
         }
        public static void UpdateOrderTable(string updatestring, Expression<Func<OrderTable, bool>> func)
        {
            Connect.CreatConnect().Update<OrderTable>(updatestring, func);
        }
        public static void DeleteOrderTable(Expression<Func<OrderTable, bool>> func)
         {
              Connect.CreatConnect().Delete<OrderTable>(func);
         }
    }
}

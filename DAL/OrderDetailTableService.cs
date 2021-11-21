using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class OrderDetailTableService
    {
        public static List<OrderDetailTable> GetOrderDetailTablelst(Expression<Func<OrderDetailTable ,bool >>  func)
         {
            return  Connect.CreatConnect().Query<OrderDetailTable>(func);
         }
        public static List<OrderDetailTable> GetOrderDetailTablelst(string querySql)
        {
            return Connect.CreatConnect().Query<OrderDetailTable>(querySql );
        }
        public static OrderDetailTable GetOneOrderDetailTable(Expression<Func<OrderDetailTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<OrderDetailTable>(func);
         }
        public static void InsertOrderDetailTablelst(List<OrderDetailTable> OrderDetailTableObjs)
         {
            foreach(OrderDetailTable OBJ in OrderDetailTableObjs)
             {
              Connect.CreatConnect().Insert<OrderDetailTable>(OBJ);
             }
         }
        public static void InsertOrderDetailTable(OrderDetailTable OrderDetailTableObj)
         {
              Connect.CreatConnect().Insert<OrderDetailTable>(OrderDetailTableObj);
         }
        public static void UpdateOrderDetailTable(OrderDetailTable OrderDetailTableObj, Expression<Func<OrderDetailTable, bool>> func)
         {
              Connect.CreatConnect().Update<OrderDetailTable>(OrderDetailTableObj,func );
         }
        public static void UpdateOrderDetailTable(string UpdateString, Expression<Func<OrderDetailTable, bool>> func)
        {
            Connect.CreatConnect().Update<OrderDetailTable>(UpdateString , func);
        }
        public static void DeleteOrderDetailTable(Expression<Func<OrderDetailTable, bool>> func)
         {
              Connect.CreatConnect().Delete<OrderDetailTable>(func);
         }
    }
}

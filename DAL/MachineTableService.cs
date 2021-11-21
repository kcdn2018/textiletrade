using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public  class MachineTableService
    {
        public static List<MachineTable> GetMachineTablelst(string WhereString)
         {
            return  Connect.CreatConnect().Query<MachineTable>(WhereString);
         }
        public static List<MachineTable> GetMachineTablelst()
        {
            return Connect.CreatConnect().Query<MachineTable>();
        }
        public static MachineTable GetOneMachineTable(string WhereString)
         {
            return  Connect.CreatConnect().QueryOneResult<MachineTable>(WhereString);
         }
        public static void InsertMachineTablelst(List<MachineTable> MachineTableObjs)
         {
            foreach(MachineTable OBJ in MachineTableObjs)
             {
              Connect.CreatConnect().Insert<MachineTable>(OBJ);
             }
         }
        public static void InsertMachineTable(MachineTable MachineTableObj)
         {
              Connect.CreatConnect().Insert<MachineTable>(MachineTableObj);
         }
        public static void UpdateMachineTable(MachineTable MachineTableObj,string WhereString)
         {
              Connect.CreatConnect().Update<MachineTable>(MachineTableObj,WhereString);
         }
        public static void DeleteMachineTable(string WhereString)
         {
              Connect.CreatConnect().Delete<MachineTable>(WhereString);
         }
        public static List<MachineTable> GetMachineTablelst(Expression<Func<MachineTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<MachineTable>(func);
         }
        public static MachineTable GetOneMachineTable(Expression<Func<MachineTable ,bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<MachineTable>(func);
         }
        public static void UpdateMachineTable(MachineTable MachineTableObj,Expression<Func<MachineTable ,bool>> func)
         {
              Connect.CreatConnect().Update<MachineTable>(MachineTableObj,func);
         }
        public static void DeleteMachineTable(Expression<Func<MachineTable ,bool>> func)
         {
              Connect.CreatConnect().Delete<MachineTable>(func);
         }
    }
}

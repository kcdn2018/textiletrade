using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class LwDetailService
    {
        public static List<LwDetail> GetLwDetaillst(Expression<Func<LwDetail ,bool>>func)
         {
            return  Connect.CreatConnect().Query<LwDetail>(func).OrderByDescending(x => x.rq).ToList();
         }
        public static LwDetail GetOneLwDetail(Expression<Func<LwDetail, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<LwDetail>(func);
         }
        public static void InsertLwDetaillst(List<LwDetail> LwDetailObjs)
         {
            foreach(LwDetail OBJ in LwDetailObjs)
             {
              Connect.CreatConnect().Insert<LwDetail>(OBJ);
             }
         }
        public static void InsertLwDetail(LwDetail LwDetailObj)
         {
              Connect.CreatConnect().Insert<LwDetail>(LwDetailObj);
         }
        public static void UpdateLwDetail(LwDetail LwDetailObj, Expression<Func<LwDetail, bool>> func)
         {
              Connect.CreatConnect().Update<LwDetail>(LwDetailObj,func);
         }
        public static void UpdateLwDetailLst(List<LwDetail >lwDetails )
        {
            Connect.CreatConnect().Update<LwDetail>(lwDetails );
        }
        public static void UpdateLwDetail(string UpdateString, Expression<Func<LwDetail, bool>> func)
        {
            Connect.CreatConnect().Update<LwDetail>(UpdateString , func);
        }
        public static void DeleteLwDetail(Expression<Func<LwDetail, bool>> func)
         {
              Connect.CreatConnect().Delete<LwDetail>(func);
         }
    }
}

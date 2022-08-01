using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace 纺织贸易管理系统
{
    public static class danjumingxitableService
    {
        public static List<danjumingxitable> Getdanjumingxitablelst(string sql)
        {
            return Connect.CreatConnect().Query<danjumingxitable>(sql);
        }
        public static List<danjumingxitable> Getdanjumingxitablelst(Expression<Func<danjumingxitable ,bool >> func)
         {
            return  Connect.CreatConnect().Query<danjumingxitable>(func );
         }
        public static danjumingxitable GetOnedanjumingxitable(Expression<Func<danjumingxitable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<danjumingxitable>(func);
         }
        public static void Insertdanjumingxitablelst(List<danjumingxitable> danjumingxitableObjs)
         {     
              Connect.CreatConnect().Insert<danjumingxitable>(danjumingxitableObjs);
         }
        public static void Insertdanjumingxitable(danjumingxitable danjumingxitableObj)
         {
              Connect.CreatConnect().Insert<danjumingxitable>(danjumingxitableObj);
         }
        public static void Updatedanjumingxitable(danjumingxitable danjumingxitableObj, Expression<Func<danjumingxitable, bool>> func)
         {
              Connect.CreatConnect().Update<danjumingxitable>(danjumingxitableObj,func);
         }
        public static void Updatedanjumingxitable(Expression<Func<danjumingxitable, bool>> UpdateFun, Expression<Func<danjumingxitable, bool>> func)
        {
            Connect.CreatConnect().Update<danjumingxitable>(UpdateFun , func);
        }
        public static void Updatedanjumingxitable(string  UpdateString, Expression<Func<danjumingxitable, bool>> func)
        {
            Connect.CreatConnect().Update<danjumingxitable>(UpdateString , func);
        }
        public static void Deletedanjumingxitable(Expression<Func<danjumingxitable, bool>> func)
         {
              Connect.CreatConnect().Delete<danjumingxitable>(func);
         }
        public static StockTable ToStockTable(danjumingxitable mingxi,DanjuTable danjuTable )
        {
            StockTable stock = new StockTable();
            stock.AvgPrice = mingxi.hanshuidanjia;
            stock.BH = mingxi.Bianhao;
            stock.biaoqianmishu = 0;
            stock.CF = mingxi.chengfeng;
            stock.CKMC = danjuTable.ckmc;
            stock.ContractNum = mingxi.ContractNum;
            stock.CustomName = mingxi.CustomName;
            stock.GG = mingxi.guige;
            stock.GH = mingxi.ganghao;
            stock.houzhengli = mingxi.houzhengli;
            stock.JS = mingxi.chengpingjuanshu;
            stock.kaijianmishu = 0;
            stock.kuanhao = mingxi.kuanhao;
            stock.Kuwei = mingxi.Kuwei;
            stock.KZ = mingxi.kezhong;
            stock.MF = mingxi.menfu;
            stock.MS = mingxi.chengpingmishu;
            stock.orderNum = mingxi.OrderNum;
            stock.own = danjuTable.own;
            stock.PM = mingxi.pingming;
            stock.RKDH = danjuTable.ksmc;
            stock.RQ = danjuTable.rq;
            stock.TotalMoney = mingxi.chengpingmishu * stock.AvgPrice;
            stock.YS = mingxi.yanse;
            stock.Huahao = mingxi.Huahao;
            stock.ColorNum = mingxi.ColorNum;
            stock.CustomerColorNum = mingxi.CustomerColorNum;
            stock.CustomerPingMing = mingxi.CustomerPingMing;
            stock.RukuNum = mingxi.chengpingmishu;
            stock.Rangchang = mingxi.Rangchang;
            stock.PibuChang = mingxi.PiBuChang;
            stock.Pihao = mingxi.Pihao;
            stock.LiuzhuanCard = danjuTable.LiuzhuanCard;
            stock.Remarkers = mingxi.beizhu;
            stock.FrabicWidth = mingxi.FrabicWidth;
            stock.EnglishName = mingxi.EnglishName;
            return stock;
        }
    }
}

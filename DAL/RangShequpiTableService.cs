using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace 纺织贸易管理系统
{
    public static class RangShequpiTableService
    {
        public static List<RangShequpiTable> GetRangShequpiTablelst(Expression<Func<RangShequpiTable, bool>> func)
         {
            return  Connect.CreatConnect().Query<RangShequpiTable>(func);
         }
        public static RangShequpiTable GetOneRangShequpiTable(Expression<Func<RangShequpiTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<RangShequpiTable>(func);
         }
        public static void InsertRangShequpiTablelst(List<RangShequpiTable> RangShequpiTableObjs)
         {       
              Connect.CreatConnect().Insert<RangShequpiTable>(RangShequpiTableObjs);
         }
        public static void InsertRangShequpiTable(RangShequpiTable RangShequpiTableObj)
         {
              Connect.CreatConnect().Insert<RangShequpiTable>(RangShequpiTableObj);
         }
        public static void UpdateRangShequpiTable(RangShequpiTable RangShequpiTableObj,Expression<Func<RangShequpiTable, bool>> func)
         {
              Connect.CreatConnect().Update<RangShequpiTable>(RangShequpiTableObj, func);
         }
        public static void DeleteRangShequpiTable(Expression<Func<RangShequpiTable, bool>> func)
         {
              Connect.CreatConnect().Delete<RangShequpiTable>(func);
         }
        public static StockTable ToStockTable(RangShequpiTable mingxi,DanjuTable danjuTable )
        {
            StockTable stock = new StockTable();
            stock.AvgPrice = 0;
            stock.BH = mingxi.SampleNum;
            stock.biaoqianmishu = 0;
            stock.CF = mingxi.chengfeng;
            stock.CKMC = danjuTable.ckmc;
            stock.ContractNum = mingxi.ContractNum;
            stock.CustomName = mingxi.CustomName;
            stock.GG = mingxi.Specifications;
            stock.GH = mingxi.ganghao;
            stock.houzhengli = mingxi.houzhengli;
            stock.JS = mingxi.ToupiJuanshu;
            stock.kaijianmishu = 0;
            stock.kuanhao = mingxi.kuanhao;
            stock.Kuwei = mingxi.Remarkers;
            stock.KZ = mingxi.kezhong;
            stock.MF = mingxi.menfu;
            stock.MS =  mingxi.ToupiMishu;
            stock.orderNum = mingxi.OrderNum;
            stock.own = danjuTable.own;
            stock.PM = mingxi.sampleName;
            stock.RKDH = mingxi.CaigouDanhao;
            stock.RQ = danjuTable.rq;
            stock.TotalMoney = 0;
            stock.YS = mingxi.color;
            stock.Huahao = mingxi.Huahao;
            stock.ColorNum = mingxi.ColorNum;
            stock.CustomerColorNum = mingxi.CustomerColorNum;
            stock.CustomerPingMing = mingxi.CustomerPingMing;
            stock.RukuNum =  mingxi.ToupiMishu;
            stock.PibuChang = mingxi.PibuChang;
            stock.Pihao = mingxi.Pihao;
            stock.Remarkers = mingxi.Remarkers;
            stock.FrabicWidth = mingxi.FrabicWidth;
            stock.EnglishName = mingxi.EnglishName;
            return stock;
        }
    }
}

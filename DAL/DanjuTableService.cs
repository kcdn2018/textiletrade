using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace 纺织贸易管理系统
{
    public static class DanjuTableService
    {
        public static List<DanjuTable> GetDanjuTablelst(Expression<Func<DanjuTable ,bool>> func)
         {
            return  Connect.CreatConnect().Query<DanjuTable>(func).OrderByDescending(x => x.rq).ToList();
         }
        public static List<DanjuTable> GetDanjuTablelst()
        {
            return Connect.CreatConnect().Query<DanjuTable>().OrderByDescending(x => x.rq).ToList();
        }
        public static DanjuTable GetOneDanjuTable(Expression<Func<DanjuTable, bool>> func)
         {
            return  Connect.CreatConnect().QueryOneResult<DanjuTable>(func);
         }
        public static void InsertDanjuTablelst(List<DanjuTable> DanjuTableObjs)
         {
            foreach(DanjuTable OBJ in DanjuTableObjs)
             {
                InsertDanjuTable(OBJ);
             }
         }
        public static void InsertDanjuTable(DanjuTable DanjuTableObj)
        {
            Connect.CreatConnect().Insert<DanjuTable>(DanjuTableObj);
            RemainMoneyTableService.InsertRemainMoneyTable(new RemainMoneyTable()
            {
                DanJuJinE = DanjuTableObj.je,
                ReceiptNum = DanjuTableObj.dh,
                ShengYuMoney = DanjuTableObj.je,
                MachineType = DanjuTableObj.djlx,
                Rq = DanjuTableObj.rq,
                SupplierName = DanjuTableObj.ksmc,
                SupplierNum = DanjuTableObj.ksbh
            });
            if(DanjuTableObj.djlx==DanjuLeiXing.打样工艺单 )
            {
                RemainMoneyTableService.InsertRemainMoneyTable(new RemainMoneyTable()
                {
                    DanJuJinE = DanjuTableObj.je,
                    ReceiptNum = DanjuTableObj.dh,
                    ShengYuMoney = DanjuTableObj.je,
                    MachineType = DanjuTableObj.djlx,
                    Rq = DanjuTableObj.rq,
                    SupplierName = DanjuTableObj.SaleMan ,
                    SupplierNum = DanjuTableObj.wuliuBianhao 
                });
            }
        }
        /// <summary>
        /// 创建一个新的单号
        /// </summary>
        /// <param name="danjuleixing">单号首字母</param>
        /// <returns></returns>
        private  static string CreatDanhao(string danjuleixing)
        {
            var list = DanjuTableService.GetDanjuTablelst(x => x.dh.Contains(danjuleixing) && x.rq == DateTime.Now.Date);
            if (list.Count > 0)
            {
                return danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + (int.Parse(list[list.Count - 1].dh.Substring(list[list.Count - 1].dh.Length - 3, 3)) + 1).ToString();
            }
            else
            {
                if (list[0].dh == string.Empty)
                {
                    return danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "101";
                }
                else
                {
                    return danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "102";
                }
            }
            //var danhao = danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            //danhao += DateTime.Now.Second.ToString() + userid;
            //return danhao;          
        }
        public static void UpdateDanjuTable(string Updatestring, Expression<Func<DanjuTable, bool>> func)
        {
            Connect.CreatConnect().Update<DanjuTable>(Updatestring, func);
        }
        public static void UpdateDanjuTableList(List<DanjuTable> danjuTables )
        {
            Connect.CreatConnect().Update<DanjuTable>(danjuTables);
        }
        public static void UpdateDanjuTable(Expression<Func<DanjuTable,bool>> Updatefunc, Expression<Func<DanjuTable, bool>> func)
        {
            Connect.CreatConnect().Update<DanjuTable>(Updatefunc , func);
        }
        public static void UpdateDanjuTable(DanjuTable DanjuTableObj, Expression<Func<DanjuTable, bool>> func)
         {
            Connect.CreatConnect().Update<DanjuTable>(DanjuTableObj,func);
            if (DanjuTableObj.djlx != DanjuLeiXing.报价单)
            {
                if (!string.IsNullOrEmpty(DanjuTableObj.ksbh))
                {
                    var remain = RemainMoneyTableService.GetOneRemainMoneyTable(x => x.ReceiptNum == DanjuTableObj.dh && x.SupplierNum == DanjuTableObj.ksbh);
                    RemainMoneyTableService.UpdateRemainMoneyTable(new RemainMoneyTable()
                    {
                        DanJuJinE = DanjuTableObj.je,
                        ReceiptNum = DanjuTableObj.dh,
                        ShengYuMoney = DanjuTableObj.je - (remain.DanJuJinE - remain.ShengYuMoney),
                        MachineType = DanjuTableObj.djlx,
                        Rq = DanjuTableObj.rq,
                        SupplierName = DanjuTableObj.ksmc,
                        SupplierNum = DanjuTableObj.ksbh
                    }, x => x.ReceiptNum == DanjuTableObj.dh && x.SupplierNum == DanjuTableObj.ksbh);
                }
            }
            if (DanjuTableObj.djlx == DanjuLeiXing.打样工艺单)
            {
                if (!string.IsNullOrEmpty(DanjuTableObj.ksbh))
                { 
                    var remaikehu = RemainMoneyTableService.GetOneRemainMoneyTable(x => x.ReceiptNum == DanjuTableObj.dh && x.SupplierNum == DanjuTableObj.ksbh);
                RemainMoneyTableService.UpdateRemainMoneyTable(new RemainMoneyTable()
                {
                    DanJuJinE = DanjuTableObj.je,
                    ReceiptNum = DanjuTableObj.dh,
                    ShengYuMoney = DanjuTableObj.je - (remaikehu.DanJuJinE - remaikehu.ShengYuMoney),
                    MachineType = DanjuTableObj.djlx,
                    Rq = DanjuTableObj.rq,
                    SupplierName = DanjuTableObj.SaleMan,
                    SupplierNum = DanjuTableObj.wuliuBianhao
                }, x => x.ReceiptNum == DanjuTableObj.dh && x.SupplierNum == DanjuTableObj.wuliuBianhao);
            }
            }
        }
        public static void DeleteDanjuTable(Expression<Func<DanjuTable, bool>> func)
         {           
            var list = GetDanjuTablelst(func);
            foreach (var l in list)
            {
                RemainMoneyTableService.DeleteRemainMoneyTable(x=>x.ReceiptNum==l.dh );
            }
            Connect.CreatConnect().Delete<DanjuTable>(func);
         }
        public static List<string> GetGongYiList()
        {
            List<string> gongyilist = new List<string>();
          var dt=  Connect.CreatConnect().Query($"select distinct yaoqiu from danjutable where djlx='{DanjuLeiXing.打样工艺单}'");
            for(int i=0;i<dt.Rows.Count;i++)
            {
                gongyilist.Add(dt.Rows[i][0].ToString());
            }
            return gongyilist;
        }
    }
}

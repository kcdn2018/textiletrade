using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 订单进度BLL
    {
        public static void  新增进度(List<danjumingxitable > danjumingxitables,DanjuTable danju  )
        {
            List<ProcessTable> processTables = new List<ProcessTable>();
            foreach (var mingxi in danjumingxitables)
            {
                if (mingxi.OrderNum != null)
                {
                    processTables.Add (new ProcessTable()
                    {
                        OrderNum = mingxi.OrderNum,
                        color = mingxi.yanse,
                        Component = mingxi.chengfeng,
                        Currency = mingxi.bizhong,
                        Documenttype = danju.djlx,
                        Dyelot = mingxi.ganghao,
                        price = mingxi.hanshuidanjia,
                        rax = danju.Hanshui,
                        TelphoneNum = danju.lianxidianhua,
                        logisticsName = danju.wuliugongsi,
                        Num = mingxi.chengpingmishu,
                        Remarkers = danju.bz,
                        rq = danju.rq,
                        own = danju.own,
                        sampleName = mingxi.pingming,
                        supplierName = danju.ksmc,
                        Fhdd = danju.ckmc,
                        TotalMoney = mingxi.hanshuiheji,
                        SampleRemarkers = mingxi.beizhu,
                        sampleNum = mingxi.Bianhao,
                        Specifications = mingxi.guige,
                        TotalNum = mingxi.chengpingmishu,
                        TotalVolumn = mingxi.chengpingjuanshu,
                        Volumn = mingxi.chengpingjuanshu,
                        Total = mingxi.chengpingmishu,
                        Unit = mingxi.danwei,
                        width = mingxi.menfu,
                        weight = mingxi.kezhong,
                        supplierNum = danju.ksbh,
                        Freight = danju.yunfei,
                        receiptnum = danju.dh,
                        MachineType = danju.jiagongleixing,
                        Huahao=mingxi.Huahao 
                    });
                }
            }
            ProcessTableService.InsertProcessTablelst(processTables);
        }
        public static void 删除进度(string danhao )
        {
            ProcessTableService.DeleteProcessTable(x => x.receiptnum == danhao);
        }
        public static void 新增进度(List<ProcessTable > processTables )
        {  
                ProcessTableService.InsertProcessTablelst(processTables);         
        }
        public static void 新增进度(DanjuTable danju )
        {
            ProcessTableService.InsertProcessTable(new ProcessTable()
            {
                OrderNum = danju.ordernum,
                Documenttype = danju.jiagongleixing,
                rax = danju.Hanshui,
                TelphoneNum = danju.lianxidianhua,
                logisticsName = danju.wuliugongsi,
                Remarkers = danju.bz,
                rq = danju.rq,
                own = danju.own,
                supplierName = danju.ksmc,
                Fhdd = danju.ckmc,
                TotalMoney = danju.je,
                supplierNum = danju.ksbh,
                Freight = danju.yunfei,
                receiptnum = danju.dh,
                MachineType = danju.jiagongleixing,
                sampleNum = danju.CarLeixing,
                sampleName = danju.StockName,
                Specifications = danju.CarNum,
                Component = danju.ckmc,
                Currency = "人民币",
                
            }) ;
        }
    }
}

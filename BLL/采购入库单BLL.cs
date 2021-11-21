using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tools;
using 纺织贸易管理系统;

namespace BLL
{
    public static class 采购入库单BLL
    {
        public static void 保存单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
        {
            if (SysInfo.GetInfo.own != "审核制")
            {
                danju.zhuangtai = "已审核";
            }
            else
            {
                danju.zhuangtai = "未审核";
            }
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            foreach (var m in danjumingxitables.Where(x => !string.IsNullOrEmpty (x.Bianhao )).ToList())
            {
                m.rkdh = m.ID.ToString ();
                m.danhao = danju.dh;
                m.houzhengli = danju.jiagongleixing;
                m.PiBuChang = danju.ksmc;            
            }
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }
            else
            {
                单据审核(danju.dh);
            }          
        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
        {
           
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danju.dh);
                }
            }
            else
            {
                单据反审核(danju.dh);
            }
            Thread.Sleep(200);
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            foreach (var m in danjumingxitables.Where(x => !string.IsNullOrWhiteSpace (x.Bianhao )).ToList())
            {
                m.danhao = danju.dh;
                m.houzhengli = danju.jiagongleixing;
                m.PiBuChang = danju.ksmc;              
            }
            danjumingxitableService.Insertdanjumingxitablelst (danjumingxitables.Where(x => !string.IsNullOrWhiteSpace(x.Bianhao)).ToList());
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }
             
        }
        public static void 删除单据(string danhao)
        {
          
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao);
                }
            }
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
        }
        public static async  void 单据审核(string danhao)
        {
           await  Task.Run(() =>
           {
               var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
               var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
               DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);
               来往明细BLL.增加来往记录(danju);
               财务BLL.增加应付款(danju);
               财务BLL.增加应收发票(danju);
               订单BLL.增加费用(danjumingxitables, danju);
               库存BLL.增加库存(danjumingxitables, danju);
               单据BLL.审核(danhao);
               订单进度BLL.新增进度(danjumingxitables, danju);
               foreach (var m in danjumingxitables)
               {
                   //修改采购通知库单已采购信息
                   int ID = m.rkdh.TryToInt();
                   danjumingxitable mingxi = danjumingxitableService.GetOnedanjumingxitable(x => x.ID == ID);
                   decimal TotalMishu = DanjuTableService.GetOneDanjuTable(x => x.dh == mingxi.danhao).toupimishu ;
                   decimal TotalJuanshu = DanjuTableService.GetOneDanjuTable(x => x.dh == mingxi.danhao).toupijuanshu;
                   TotalMishu += m.chengpingmishu;
                   TotalJuanshu += m.chengpingjuanshu;
                   DanjuTableService.UpdateDanjuTable(x => x.toupimishu == TotalMishu && x.totaljuanshu == TotalJuanshu, x => x.dh == mingxi.danhao);
                   decimal mishu =mingxi.toupimishu + m.chengpingmishu;
                   danjumingxitableService.Updatedanjumingxitable(X => X.toupimishu == mishu, x => x.ID == ID);
                   ///////
                   if (danju.jiagongleixing == "白坯采购")
                   {
                       订单BLL.增加已投米数(m);
                   }
                   dbService.Updatedb($"Update db set PBprice='{m.hanshuidanjia}' where bh='{m.Bianhao}'");
               }
           });
        }
        public static async  void 单据反审核(string danhao)
        {
            await Task.Run(() =>
            {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                foreach (var m in danjumingxitables)
                {
                    //修改采购通知库单已采购信息
                    int ID = m.rkdh.TryToInt();
                    danjumingxitable mingxi = danjumingxitableService.GetOnedanjumingxitable(x => x.ID == ID);
                    decimal TotalMishu = DanjuTableService.GetOneDanjuTable(x => x.dh == mingxi.danhao).toupimishu;
                    decimal TotalJuanshu = DanjuTableService.GetOneDanjuTable(x => x.dh == mingxi.danhao).toupijuanshu;
                    TotalMishu -= m.chengpingmishu;
                    TotalJuanshu -= m.chengpingjuanshu;
                    DanjuTableService.UpdateDanjuTable(x => x.toupimishu == TotalMishu && x.totaljuanshu == TotalJuanshu, x => x.dh == mingxi.danhao);
                    decimal mishu = mingxi.toupimishu - m.chengpingmishu;
                    danjumingxitableService.Updatedanjumingxitable(X => X.toupimishu == mishu, x => x.ID == ID);
                    ///////
                    if (danju.jiagongleixing == "白坯采购")
                    {
                        订单BLL.减少已投米数(m);
                    }
                }
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
                来往明细BLL.删除来往记录(danju);
                财务BLL.减少应付款(danju);
                财务BLL.减少应收发票(danju);
                订单BLL.减少费用(danjumingxitables, danju);
                库存BLL.减少库存(danjumingxitables, danju);
                单据BLL.未审核(danhao);
                订单进度BLL.删除进度(danju.dh);
            });
        }
    }
}

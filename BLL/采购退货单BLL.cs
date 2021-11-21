using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 采购退货单BLL
    {
        public static void 保存单据(DanjuTable danju,List<danjumingxitable > danjumingxitables, List<JuanHaoTable> juanHaoTables)
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
                  danju.je = 0 - danju.je;
                  DanjuTableService.InsertDanjuTable(danju);
                  foreach (var d in danjumingxitables.Where(x => x.Bianhao != null).ToList())
                  {
                      d.danhao = danju.dh;
                      d.chengpingmishu = 0 - d.chengpingmishu;
                      d.chengpingjuanshu = 0 - d.chengpingjuanshu;
                      d.hanshuidanjia = 0 - d.hanshuidanjia;
                      d.hanshuiheji = 0 - d.hanshuiheji;
                     
                  } 
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());
            ////
            List<FahuoDan> fahuoDans = new List<FahuoDan>();
            foreach (var j in juanHaoTables)
            {
                fahuoDans.Add ( new FahuoDan()
                {
                    bh = j.SampleNum,
                    pm = j.SampleName,
                    GG = j.guige,
                    gh = j.GangHao,
                    ys = j.yanse,
                    jh = j.JuanHao,
                    mis = j.biaoqianmishu.ToString(),
                    color = j.yanse,
                    Gangjuanhao = j.PiHao.ToString(),
                    dh = danju.dh,
                    rq = danju.rq,
                });            
                j.Danhao = danju.dh;
                if (j.state == 0)
                {
                    j.state = 1;
                }
            }
            Connect.DbHelper().Updateable(juanHaoTables).ExecuteCommand();
            FahuoDanService.InsertFahuoDanlst(fahuoDans);
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
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables, List<JuanHaoTable> juanHaoTables)
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
            danju.je = 0 - danju.je;
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            /////
            FahuoDanService.DeleteFahuoDan(x => x.dh == danju.dh);        
            //清除卷号状态
            JuanHaoTableService.UpdateJuanHaoTable($"state='0',Danhao=''", x => x.Danhao == danju.dh);
            // 
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            foreach (var m in danjumingxitables.Where(x => x.Bianhao != null).ToList())
            {
                m.danhao = danju.dh;
                m.chengpingmishu = 0 - m.chengpingmishu;
                m.chengpingjuanshu = 0 - m.chengpingjuanshu;
                m.hanshuidanjia = 0 - m.hanshuidanjia;
                m.hanshuiheji = 0 - m.hanshuiheji;
                
            }
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());
            ////
            List<FahuoDan> fahuoDans = new List<FahuoDan>();
            foreach (var j in juanHaoTables)
            {
               fahuoDans.Add ( new FahuoDan()
                {
                    bh = j.SampleNum,
                    pm = j.SampleName,
                    GG = j.guige,
                    gh = j.GangHao,
                    ys = j.yanse,
                    jh = j.JuanHao,
                    mis = j.biaoqianmishu.ToString(),
                    color = j.yanse,
                    Gangjuanhao = j.PiHao.ToString(),
                    dh = danju.dh,
                    rq = danju.rq,
                });
                j.Danhao = danju.dh;
                if (j.state == 0)
                {
                    j.state = 1;
                }
            }
            Connect.DbHelper().Updateable(juanHaoTables).ExecuteCommand();
            FahuoDanService.InsertFahuoDanlst(fahuoDans);
            ////
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }
        }
        /// <summary>
        /// 审核单据 由于是负数 原本减少变增加
        /// </summary>
        /// <param name="danhao"></param>
        public static async  void 单据审核(string danhao)
        {
            await Task.Run(() => { 
            //采购入库单BLL.单据反审核(danhao);
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                //库存BLL.清零库存();
                //var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
                来往明细BLL.增加来往记录(danju);
                库存BLL.增加库存(danjumingxitables, danju);
                财务BLL.增加应付款 (danju);
                财务BLL.增加应收发票 (danju);
                订单BLL.增加费用(danjumingxitables, danju);
                //库存BLL.增加库存  (danjumingxitables, danju);
                单据BLL.审核(danhao);
                订单进度BLL.新增进度(danjumingxitables, danju);
            });
        }
        /// <summary>
        /// 审核单据 由于是负数 原本增加变减少
        /// </summary>
        /// <param name="danhao"></param>
        public static async  void 单据反审核(string danhao)
        {
           await Task.Run(() => { 
            可发卷BLL.卷入库(danhao);
            //采购入库单BLL.单据审核 (danhao);
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                //danju.zhuangtai = "未审核";
                //DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danhao);
                来往明细BLL.删除来往记录(danju);
                财务BLL.减少应付款(danju);
                财务BLL.减少应收发票(danju);
                //订单BLL.增加费用 (danjumingxitables, danju);
                库存BLL.减少库存(danjumingxitables, danju);
                单据BLL.未审核(danhao);
                foreach (var mingxi in danjumingxitables)
                {
                    订单进度BLL.删除进度(mingxi.OrderNum );
                }
           });
        }
        public static void 删除单据(string danhao)
        {
            采购入库单BLL.删除单据(danhao);
            /////
            FahuoDanService.DeleteFahuoDan(x => x.dh == danhao );

            JuanHaoTableService.UpdateJuanHaoTable($"state='0',Danhao=''", x => x.Danhao ==danhao);
            // 
        }
    }
}

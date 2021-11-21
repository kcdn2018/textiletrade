using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
  public   class 来货退卷单BLL
    {
        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="danhao">要删除的单号</param>
        public static void Delete(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var mingxis = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
            Task.Run(new Action(() => {
                单据反审核(danju.dh);
            }));
            Thread.Sleep(200);
            Connect.CreatConnect().Delete<DanjuTable>(x => x.dh  == danhao);
            Connect.CreatConnect().Delete<danjumingxitable>(x => x.danhao == danhao);
        }
        /// <summary>
        /// 保存单据
        /// </summary>
        /// <param name="danju"></param>
        /// <param name="danjumingxitables"></param>
        public static void 保存(DanjuTable danju,List<danjumingxitable > danjumingxitables )
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
            foreach (var m in danjumingxitables.Where(x => x.pingming != null).ToList())
            {
                m.danhao = danju.dh;
                m.CustomName  = danju.ksmc ;
                danjumingxitableService.Insertdanjumingxitable(m);
            }
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
        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="danhao"></param>
        public static void 单据审核(string danhao)
        {
            Task.Run(() =>
            {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                danju.zhuangtai = "已审核";
                DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danhao);
                来往明细BLL.增加来往记录(danju);
                //财务BLL.增加应付款(danju);
                //财务BLL.增加应收发票(danju);
                //订单BLL.增加费用(danjumingxitables, danju);
                库存BLL.减少库存 (danjumingxitables, danju);
                减少入库数量(danju , danjumingxitables);
                单据BLL.审核(danhao);
                //订单进度BLL.新增进度(danjumingxitables, danju);
                //foreach (var m in danjumingxitables)
                //{
                //    if (danju.jiagongleixing == "白坯采购")
                //    {
                //        订单BLL.增加已投米数(m);
                //    }
                //    dbService.Updatedb($"Update db set PBprice='{m.hanshuidanjia}' where bh='{m.Bianhao}'");
                //}
            });
        }
        /// <summary>
        /// 单据反审核
        /// </summary>
        /// <param name="danhao"></param>
        public static void 单据反审核(string danhao)
        {
            Task.Run(new Action(() => { 
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
            //foreach (var m in danjumingxitables)
            //{
            //    if (danju.jiagongleixing == "白坯采购")
            //    {
            //        订单BLL.减少已投米数(m);
            //    }
            //}
            danju.zhuangtai = "未审核";
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danhao);
                来往明细BLL.删除来往记录(danju);
                //财务BLL.减少应付款(danju);
                //财务BLL.减少应收发票(danju);
                //订单BLL.减少费用(danjumingxitables, danju);
                库存BLL.增加库存  (danjumingxitables, danju);
            增加入库数量(danju, danjumingxitables);
            单据BLL.未审核(danhao);
            //订单进度BLL.删除进度(danju.dh);
            }));
        }
        /// <summary>
        /// 修改单据
        /// </summary>
        /// <param name="danju"></param>
        /// <param name="danjumingxitables"></param>
        public static void 修改单据(DanjuTable danju ,List<danjumingxitable >danjumingxitables )
        {
            Task.Run(() => {
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
                DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
                danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
                foreach (var m in danjumingxitables.Where(x => x.pingming  != null).ToList())
                {
                    m.danhao = danju.dh;
                    m.CustomName = danju.ksmc;
                    danjumingxitableService.Insertdanjumingxitable(m);
                }
                if (SysInfo.GetInfo.own != string.Empty)
                {
                    if (SysInfo.GetInfo.own != "审核制")
                    {
                        单据审核(danju.dh);
                    }
                }
            });
        }
        private static  void 减少入库数量(DanjuTable danjuTable , List<danjumingxitable > danjumingxitables )
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.YS == mingxi.yanse &&
                    x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.PM == mingxi.pingming && x.CF == mingxi.chengfeng && x.KZ == mingxi.kezhong);
                if(!string.IsNullOrEmpty (stock.PM  ))
                {
                    stock.RukuNum -= mingxi.chengpingmishu;
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);
                }
            }
        }
        private static  void 增加入库数量(DanjuTable danjuTable, List<danjumingxitable> danjumingxitables)
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.YS == mingxi.yanse &&
                    x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.PM == mingxi.pingming && x.CF == mingxi.chengfeng && x.KZ == mingxi.kezhong);
                if (!string.IsNullOrEmpty(stock.PM))
                {
                    stock.RukuNum+= mingxi.chengpingmishu;
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);
                }
            }
        }
    
    }
}

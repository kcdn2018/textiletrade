using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
    public static class 产量登记单BLL
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
            foreach (var m in danjumingxitables.Where(x => x.Bianhao != null).ToList())
            {
                m.danhao = danju.dh;
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
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
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
            foreach (var m in danjumingxitables.Where(x => x.Bianhao != null).ToList())
            {
                m.danhao = danju.dh;
                m.houzhengli = danju.jiagongleixing;
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
        public static void 删除单据(string danhao)
        {
            Task.Run(() => { 
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao);
                }
            }
                Thread.Sleep(500);
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            });
        }
        public static void 单据审核(string danhao)
        {
            Task.Run(() =>
            {
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);             
                单据BLL.审核(danhao);
                foreach (var m in danjumingxitables)
                {
                    var stock =StockTableService.GetOneStockTable (x=>x.ID == m.suolv);
                    stock.biaoqianmishu += m.chengpingmishu;
                    stock.yijianjuanshu += m.chengpingjuanshu;
                    StockTableService.UpdateStockTable($"biaoqianmishu='{stock.biaoqianmishu }',yijianjuanshu='{stock.yijianjuanshu }'", x => x.ID == m.suolv);
                }
            });
        }
        public static void 单据反审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
            foreach (var m in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.ID == m.suolv);
                stock.biaoqianmishu -= m.chengpingmishu;
                stock.yijianjuanshu -= m.chengpingjuanshu;
                StockTableService.UpdateStockTable($"biaoqianmishu='{stock.biaoqianmishu }',yijianjuanshu='{stock.yijianjuanshu }'", x => x.ID == m.suolv);
            }
            单据BLL.未审核(danhao);
        }
    }
}

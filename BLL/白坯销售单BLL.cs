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
   public  class 白坯销售单BLL
    {
        public static void 保存单据(DanjuTable danju, List<danjumingxitable> danjumingxitables, List<FabricMadan> juanHaoTables)
        {
            if (SysInfo.GetInfo.own != "审核制")
            {
                danju.zhuangtai = "已审核";
            }
            else
            {
                danju.zhuangtai = "未审核";
            }
            danju.Profit = danjumingxitables.Sum(x => x.Profit);
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            juanHaoTables.ForEach(X => X.Danhao = danju.dh);
            ///保存到单据明细      
            foreach (var d in danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList())
            {
                d.danhao = danju.dh;
                d.bizhong = danju.Bizhong;
                d.rq = danju.rq;
            }
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            ///保存卷号
            Connect.CreatConnect().Insert<FabricMadan>(juanHaoTables);
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    var danhao = danju.dh;
                    单据审核(danhao);
                }
            }
        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables, List<FabricMadan > juanHaoTables)
        {
            //删除信息
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    var danhao = danju.dh;
                    单据反审核(danhao);
                }
            }
            Thread.Sleep(200);
            Connect.CreatConnect().Delete<FabricMadan>(x => x.Danhao == danju.dh );
            ///删除信息
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            danju.Profit = danjumingxitables.Sum(x => x.Profit);
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            danjumingxitables.ForEach(x => x.bizhong = danju.Bizhong);
            danjumingxitables.ForEach(x => x.rq = danju.rq);
            ///  
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            Connect.CreatConnect().Insert<FabricMadan>(juanHaoTables);
            /////         
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    var danhao = danju.dh;
                    单据审核(danhao);
                }
            }
        }
        public static void 删除单据(string deldanhao)
        {
            var danhao = deldanhao;
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao);
                }
            }
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            Connect.CreatConnect().Delete<FabricMadan>(x => x.Danhao == danhao);
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
        }
        public static List<danjumingxitable> GetFahuodanMingxi(string danhao)
        {
            return danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
        }
        public static void 单据审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
            订单BLL.增加已发货数量(danjumingxitables);
            DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);
            来往明细BLL.增加来往记录(danju);
            财务BLL.增加应收款(danju);
            财务BLL.增加应开发票(danjumingxitables, danju);
            订单BLL.增加费用(danjumingxitables, danju);
            库存BLL.减少库存(danjumingxitables, danju);
            单据BLL.审核(danhao);
            订单进度BLL.新增进度(danjumingxitables, danju);
            //可发卷BLL.卷出库(juanhaos);
            订单BLL.增加发货金额(danjumingxitables);
            订单BLL.增加剩余金额(danjumingxitables);
            财务BLL.减少剩余额度(danju.ksbh, danju.je);
            库存BLL.增加发货数量(danju, danjumingxitables);
            //return "审核成功";
        }
        public static void 单据反审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
            DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
            Connect.CreatConnect().Delete<FabricMadan>(x => x.Danhao == danhao);
            来往明细BLL.删除来往记录(danju);
            财务BLL.减少应收款(danju);
            财务BLL.减少应开发票(danju, danjumingxitables);
            订单BLL.减少费用(danjumingxitables, danju);
            库存BLL.增加库存(danjumingxitables, danju);
            单据BLL.未审核(danhao);
            订单进度BLL.删除进度(danju.dh);
            订单BLL.减少已发货数量(danjumingxitables);
            订单BLL.减少发货金额(danjumingxitables);
            订单BLL.减少剩余金额(danjumingxitables);
            财务BLL.增加剩余额度(danju.ksbh, danju.je);
            库存BLL.减少发货数量(danju, danjumingxitables);
        }
        /// <summary>
        /// 检查销售出库单是否已经填写过该订单的其他费用
        /// </summary>
        /// <param name="OrderNum">订单号</param>
        /// <returns>已经收过返回True,没有返回False</returns>
        public static Boolean CheckDanjuMingxiContainOtherCost(string OrderNum)
        {
            var sql = $"select danjumingxitable.* from danjutable,danjumingxitable where danjutable.djlx='{DanjuLeiXing.销售出库单 }' and danjumingxitable.danhao=danjutable.dh and danjumingxitable.weishuiheji>0";
            var mingxis = danjumingxitableService.Getdanjumingxitablelst(sql);
            if (mingxis.Count > 0)
            {
                return true;
            }
            else
            { return false; }
        }
    }
}

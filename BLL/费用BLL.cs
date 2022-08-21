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
  public   class 费用BLL
    {
        public static void 保存单据(DanjuTable danju,List<danjumingxitable > mingxis )
        {
            //if (SysInfo.GetInfo.own != "审核制")
            //{
            //    danju.zhuangtai = "已审核";
            //}
            //else
            //{
            //    danju.zhuangtai = "未审核";
            //}
            danju.dh = 单据BLL.检查单号(danju.dh);
            //保存单据明细
            foreach(var m in mingxis )
            {
                m.danhao = danju.dh;
                danjumingxitableService.Insertdanjumingxitable(m);
            }

            if(danju.yaoqiu ==ShouzhiStyle.收入 )
            {
                danju.totalmoney = danju.je;
                danju.je = 0;
            }
            DanjuTableService.InsertDanjuTable(danju);
            var newdanju = DanjuTableService.GetOneDanjuTable(x => x.dh == danju.dh);
            if (danju.zhuangtai == "已审核")
            {
                单据审核(danju.dh);
                账户BLL.刷新剩余金额(newdanju);
            }
        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> mingxis)
        {
            DanjuTable olddanju = DanjuTableService.GetOneDanjuTable(x => x.dh == danju.dh);
            //删除信息
            //if (SysInfo.GetInfo.own != string.Empty)
            //{
            //    if (SysInfo.GetInfo.own != "审核制")
            //    {
            if (olddanju.zhuangtai == "已审核")
            {
                反审核单据(danju.dh);
            }
                //}
            //}
            if (danju.yaoqiu == ShouzhiStyle.收入)
            {
                danju.totalmoney = danju.je;
                danju.je = 0;
            }
            if (olddanju.yaoqiu == ShouzhiStyle.收入)
            {
                danju.RemainMoney -=( olddanju.totalmoney  - danju.totalmoney) ;
            }
            else
            {
                danju.RemainMoney +=( olddanju.je - danju.je);
            }
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            //保存单据明细
            foreach (var m in mingxis)
            {
                //m.danhao = danju.dh;
                danjumingxitableService.Insertdanjumingxitable(m);
            }
            //if (SysInfo.GetInfo.own != string.Empty)
            //{
                if (danju.zhuangtai == "已审核")
                {
                    单据审核(danju.dh); 
                    账户BLL.修改刷新(danju);
                }
            //}
            //else
            //{
            //    单据审核(danju.dh);
            //}
           
        }
        public static void 删除(string danhao)
        {
            //删除信息
            var old = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            if (old.zhuangtai == "已审核")
            {
                反审核单据(danhao);
            }
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            if (!string.IsNullOrEmpty(old.dh))
            {
                if (old.zhuangtai == "已审核")
                {
                    账户BLL.删除刷新(old);
                }
            }
        }

        public static void 单据审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            if (danju.yaoqiu == "支出")
            {
                收款单BLL.减少账号余额(danju);
                订单BLL.增加费用(danju);
            }
            else
            {
                danju.je = danju.totalmoney;
                收款单BLL.增加账号余额(danju);
                订单BLL.减少费用(danju);
                danju.je = 0;
            }
            danju.zhuangtai = "已审核";
            danju.Deliverytime = DateTime.Now;
            Connect.DbHelper().Updateable<DanjuTable>(danju).ExecuteCommand();
        }
        public static void 反审核单据(string danhao)
        {
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                if (danju.yaoqiu == "收入")
                {
                    danju.je = danju.totalmoney;
                    收款单BLL.减少账号余额(danju);
                    订单BLL.增加费用(danju);
                }
                else
                {
                    收款单BLL.增加账号余额(danju);
                    订单BLL.减少费用(danju);
                }
            danju.zhuangtai = "未审核";
            danju.Deliverytime = DateTime.MinValue ;
            Connect.DbHelper().Updateable<DanjuTable>(danju).ExecuteCommand();
        }
    }
}

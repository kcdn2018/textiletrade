using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 收款单BLL
    {
        public static async  void 保存(DanjuTable danju,List<ProcessTable> orderTables,List<skmx > skmxes  )
        {
           
                danju.dh = 单据BLL.检查单号(danju.dh);           
                DanjuTableService.InsertDanjuTable(danju);
                danjumingxitableService.Insertdanjumingxitable(new danjumingxitable { danhao = danju.dh, weishuiheji = danju.totalmoney, hanshuiheji = 0 - danju.je });
                SaveToSkmx(skmxes);

            await Task.Run(() =>
            {  
                var danhao = danju.dh;
                var newdanju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao );
                var skmxlist = skmxService.Getskmxlst(x => x.dh == danhao);
                var orders = ProcessTableService.GetProcessTablelst(x => x.receiptnum == danhao);
                订单BLL.减少剩余金额(orders);
                订单进度BLL.新增进度(orders);
                来往明细BLL.增加来往记录(newdanju);
                财务BLL.减少应收款(newdanju);
                财务BLL.增加剩余额度(newdanju.ksbh, newdanju.je);
                增加账号余额(newdanju);
                ///保存到收款明细表             
                减少剩余金额(skmxes);
                账户BLL.刷新剩余金额(newdanju);
            });
        }
        private static void SaveToSkmx(List<skmx> skmxes)
        {
            skmxService.Insertskmxlst(skmxes);
        }
        private static void 减少剩余金额(List<skmx > skmxes )
        {
            foreach (var s in skmxes )
            {
                var re = RemainMoneyTableService.GetOneRemainMoneyTable(x => x.ReceiptNum == s.skyy);
                re.ShengYuMoney -= s.je;
                RemainMoneyTableService.UpdateRemainMoneyTable($"ShengYuMoney='{re.ShengYuMoney }'", x => x.ReceiptNum == re.ReceiptNum);
            }
        }
        private static void 增加剩余金额(List<skmx> skmxes)
        {
            foreach (var s in skmxes)
            {
                var re = RemainMoneyTableService.GetOneRemainMoneyTable(x => x.ReceiptNum == s.skyy);
                re.ShengYuMoney += s.je;
                RemainMoneyTableService.UpdateRemainMoneyTable($"ShengYuMoney='{re.ShengYuMoney }'", x => x.ReceiptNum == re.ReceiptNum);
            }
        }
        public  static void 增加账号余额(DanjuTable danju )
        {
            var sk = SKFSService.GetOneSKFS(x => x.Skfs == danju.ShoukuanFangshi);
            if (sk.Skfs != string.Empty)
            {
                sk.Zhanghuyue += danju.je;
                SKFSService.UpdateSKFS($"Zhanghuyue='{sk.Zhanghuyue }'", x => x.BH == sk.BH);
            }      
         
        }
        public  static void 减少账号余额(DanjuTable danju)
        {
            var sk = SKFSService.GetOneSKFS(x => x.Skfs == danju.ShoukuanFangshi);
            if (sk.Skfs != string.Empty)
            {
                sk.Zhanghuyue -= danju.je;
                SKFSService.UpdateSKFS($"Zhanghuyue='{sk.Zhanghuyue }'", x => x.BH == sk.BH);
            }
        }
        public static   void 修改(DanjuTable newdanju, List<ProcessTable> orderTables, List<skmx> skmxes)
        {
           
                 var old = DanjuTableService.GetOneDanjuTable(x => x.dh == newdanju.dh);
                //var olddanju = DanjuTableService.GetOneDanjuTable(x => x.dh == newdanju.dh);

                DanjuTableService.UpdateDanjuTable(newdanju, x => x.dh == newdanju.dh);
                 var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == newdanju.dh);
                 danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
                 danjumingxitableService.Insertdanjumingxitable(new danjumingxitable { danhao = danju.dh, hanshuiheji = danju.je });
                 var skmxlist = skmxService.Getskmxlst(x => x.dh == danju.dh);
                 SaveToSkmx(skmxes);
                 增加剩余金额(skmxlist);
                 删除收款单明细(danju.dh);
                 订单BLL.增加剩余金额(ProcessTableService.GetProcessTablelst(x => x.receiptnum == danju.dh));
                 减少账号余额(old);
                 财务BLL.减少剩余额度(old.ksbh, old.je);
                 财务BLL.增加应收款(old);
                 来往明细BLL.修改(danju);
                 财务BLL.减少应收款(danju);
                 订单BLL.减少剩余金额(orderTables);
                 订单进度BLL.删除进度(danju.dh);
                 订单进度BLL.新增进度(orderTables);
                 财务BLL.增加剩余额度(danju.ksbh, danju.je);
                 增加账号余额(danju);
                ///保存到收款明细表
                减少剩余金额(skmxService.Getskmxlst(x => x.dh == danju.dh));
                 账户BLL.修改刷新(danju);

        }
        private static void 删除收款单明细(string danhao)
        {
            skmxService.Deleteskmx(x => x.dh == danhao);
        }
        public static async void 删除(string danhao)
        {
            await Task.Run(() =>
              {
                  增加剩余金额(skmxService.Getskmxlst(x => x.dh == danhao));
                  删除收款单明细(danhao);
                  var old = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                  danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
                  var ordertables = ProcessTableService.GetProcessTablelst(x => x.receiptnum == danhao);
                  订单BLL.增加剩余金额(ordertables);
                  财务BLL.增加应收款(old);
                  来往明细BLL.删除来往记录(old);
                  订单进度BLL.删除进度(danhao);
                  减少账号余额(old);
                  DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
                  账户BLL.删除刷新(old);
              });
        }
    }
}

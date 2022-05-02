using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 付款单BLL
    {
        public static   void 保存(DanjuTable Olddanju)
        {
                Olddanju.dh = 单据BLL.检查单号(Olddanju.dh);
                danjumingxitableService.Insertdanjumingxitable(new danjumingxitable { danhao = Olddanju.dh, weishuiheji = Olddanju.totalmoney, hanshuiheji = 0 - Olddanju.je });
                DanjuTableService.InsertDanjuTable(Olddanju);
                DanjuTable danju = DanjuTableService.GetOneDanjuTable(x => x.dh == Olddanju.dh);
                来往明细BLL.增加来往记录(danju);
                财务BLL.减少应付款(danju);
                收款单BLL.减少账号余额(danju);
                账户BLL.刷新剩余金额(danju);
        }
        public static   void 修改(DanjuTable danju)
        {
                收款单BLL.增加账号余额(danju);
                var old = DanjuTableService.GetOneDanjuTable(x => x.dh == danju.dh);
                danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
                财务BLL.增加应付款(old);
                来往明细BLL.修改(danju);
                财务BLL.减少应付款(danju);
                收款单BLL.减少账号余额(old);
                var zhanghu = SKFSService.GetOneSKFS(x => x.Skfs == danju.ShoukuanFangshi);
                danju .RemainMoney +=( old.je - danju.je);
                DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
                danjumingxitableService.Insertdanjumingxitable(new danjumingxitable { danhao = danju.dh, weishuiheji = danju.totalmoney, hanshuiheji = 0 - danju.je });
                账户BLL.修改刷新(danju);
        }
        public static  void 删除(string danhao)
        {
                var old = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                财务BLL.增加应付款(old);
                来往明细BLL.删除来往记录(old);
                收款单BLL.增加账号余额(old);
                danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
                DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
                账户BLL.删除刷新(old);
        }
    }
}

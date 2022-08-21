using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.自定义类
{
  public   class SelectStockHelper
    {
        public static Boolean Select(ButtonEdit stockname,GridView grid,List<danjumingxitable > danjumingxitables)
        {
            if (stockname.Text == "")
            {
                MessageBox.Show("请先选择仓库名称", "错误", MessageBoxButtons.OK);
                return false;
            }
            var fm = new 库存选择() { StockName = stockname.Text };
            fm.ShowDialog();
            var i = grid.FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                if (danjumingxitables.Where(x => x.Bianhao == pingzhong.BH && x.ganghao == pingzhong.GH && x.houzhengli == pingzhong.houzhengli && x.yanse == pingzhong.YS).Count() > 0)
                {
                    MessageBox.Show($"缸号:" + pingzhong.GH + $"\r\n编号:{pingzhong.BH }\r\n后整理:{pingzhong.houzhengli }\r\n颜色:{pingzhong.YS }\r\n已经存在信息！不能重复添加");
                    continue;
                }
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao = pingzhong.BH;
                danjumingxitables[i].guige = pingzhong.GG;
                danjumingxitables[i].chengfeng = pingzhong.CF;
                danjumingxitables[i].pingming = pingzhong.PM;
                danjumingxitables[i].kezhong = pingzhong.KZ;
                danjumingxitables[i].menfu = pingzhong.MF;
                danjumingxitables[i].FrabicWidth = pingzhong.FrabicWidth;
                danjumingxitables[i].danwei = "米";
                danjumingxitables[i].ContractNum = pingzhong.ContractNum;
                danjumingxitables[i].CustomName = pingzhong.CustomName;
                danjumingxitables[i].OrderNum = pingzhong.orderNum;
                danjumingxitables[i].kuanhao = pingzhong.kuanhao;
                danjumingxitables[i].houzhengli = pingzhong.houzhengli;
                danjumingxitables[i].yanse = pingzhong.YS;
                danjumingxitables[i].Chengpingyanse = pingzhong.YS;
                danjumingxitables[i].ganghao = pingzhong.GH;
                danjumingxitables[i].chengpingjuanshu = pingzhong.JS;
                danjumingxitables[i].toupimishu = pingzhong.MS;
                danjumingxitables[i].chengpingmishu = pingzhong.MS;
                danjumingxitables[i].Kuwei = pingzhong.Kuwei;
                danjumingxitables[i].Huahao = pingzhong.Huahao;
                danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                danjumingxitables[i].rq = DateTime.Now ;
                danjumingxitables[i].PiBuChang = pingzhong.PibuChang;
                danjumingxitables[i].Pihao = pingzhong.Pihao;
                danjumingxitables[i].IsHanshui = QueryTime.IsTax;
                danjumingxitables[i].AveragePrice = pingzhong.AvgPrice;
                danjumingxitables[i].CustomerLotNo = pingzhong.CustomerLotNo;
                danjumingxitables[i].hanshuidanjia = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == pingzhong.orderNum && x.sampleNum == pingzhong.BH && x.Kuanhao == pingzhong.kuanhao
                && x.ColorNum == pingzhong.ColorNum && x.color == pingzhong.YS && x.Huahao == pingzhong.Huahao).price;
                danjumingxitables[i].hanshuiheji = danjumingxitables[i].hanshuidanjia * pingzhong.MS;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() );
                    }
            }
            fm.Dispose();
            return true;
        }
    }
}

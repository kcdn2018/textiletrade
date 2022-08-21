using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.自定义类
{
  public   class SelectJuanHelper
    {
        public static void SelectJuan(GridControl gridcontrol,GridView gridview,List<JuanHaoTable > juanList, List<danjumingxitable > danjumingxitables)
        {
            foreach (var d in danjumingxitables)
            {
                d.chengpingmishu = 0;
                d.chengpingjuanshu = 0;
            }
            foreach (var i in gridview.GetSelectedRows())
            {
                var juan = new JuanHaoTable();
                juan = juanList.First(x => x.ID == (int)gridview.GetRowCellValue(i, "ID"));
                var d = danjumingxitables.Where(x => x.OrderNum == juan.OrderNum && x.Bianhao == juan.SampleNum && x.ganghao == juan.GangHao && x.kuanhao == juan.kuanhao
                 && x.houzhengli == juan.Houzhengli && x.yanse == juan.yanse && x.Huahao == juan.Huahao && x.ColorNum == juan.ColorNum).ToList();
                if (d.Count > 0)
                {
                    if (d[0].danwei != juan.Danwei)
                    {
                        if (MessageBox.Show ("缸号：" + juan.GangHao + "\r\n" + "颜色：" + juan.yanse + "\r\n合同号：" + juan.Hetonghao + "\r\n编号：" + juan.SampleNum + "\r\n款号：" + juan.kuanhao + "\r\n品名：" + juan.SampleName + "\r\n单位不一致！是否把单据明细的单位调成卷的单位？","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes )
                        {
                            d[0].danwei = juan.Danwei;
                        }
                    }
                }
            }
            foreach (var i in gridview.GetSelectedRows())
            {
                var juan = new JuanHaoTable();
                juan = juanList.First(x => x.ID == (int)gridview.GetRowCellValue(i, "ID"));
                var d = danjumingxitables.Where(x => x.OrderNum == juan.OrderNum && x.Bianhao == juan.SampleNum && x.ganghao == juan.GangHao && x.kuanhao == juan.kuanhao
                 && x.houzhengli == juan.Houzhengli && x.yanse == juan.yanse && x.Huahao == juan.Huahao && x.ColorNum == juan.ColorNum).ToList();
                if (d.Count > 0)
                {
                    if (d[0].danwei == juan.Danwei)
                    {
                        d[0].chengpingmishu += juan.biaoqianmishu;
                        d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                    }
                    else
                    {
                        if (d[0].danwei == "米" && juan.Danwei == "码")
                        {
                            d[0].chengpingmishu += juan.biaoqianmishu * (decimal)0.9144;
                            d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                        }
                        else
                        {
                            if (d[0].danwei == "码" && juan.Danwei == "码")
                            {
                                d[0].chengpingmishu += juan.biaoqianmishu;
                                d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                            }
                            else
                            {
                                d[0].chengpingmishu += juan.biaoqianmishu / (decimal)0.9144;
                                d[0].toupimishu = juan.MaShu != 0 ? d[0].chengpingmishu / (100 + (100 - juan.MaShu) / 100) : d[0].chengpingmishu;
                            }
                        }
                    }
                    string s = juan.biaoqianmishu.ToString() + "  " + d[0].chengpingmishu.ToString();
                    d[0].chengpingjuanshu++;
                }
            }
            foreach (var d in danjumingxitables)
            {
                d.hanshuiheji = d.hanshuidanjia * d.chengpingmishu;
            }
            gridcontrol .RefreshDataSource();
        }
    }
}

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
  public   class SelectProductHelper
    {
        public static void Select(GridView grid,List<danjumingxitable > danjumingxitables)
        {
            var fm = new 品种选择();
            fm.ShowDialog();
            var i = grid .FocusedRowHandle;
            foreach (var pingzhong in fm.pingzhong)
            {
                danjumingxitables[i].bizhong = "人民币￥";
                danjumingxitables[i].Bianhao = pingzhong.bh;
                danjumingxitables[i].guige = pingzhong.gg;
                danjumingxitables[i].chengfeng = pingzhong.cf;
                danjumingxitables[i].pingming = pingzhong.pm;
                danjumingxitables[i].kezhong = pingzhong.kz;
                danjumingxitables[i].menfu = pingzhong.mf;
                danjumingxitables[i].FrabicWidth = pingzhong.mf;
                danjumingxitables[i].danwei = "米";
                danjumingxitables[i].EnglishName = pingzhong.EnglishName;
                danjumingxitables[i].PibuName  = pingzhong.PibuName ;
                i++;
                if (i == danjumingxitables.Count - 1)
                    for (int j = 0; j < 30; j++)
                    {
                        danjumingxitables.Add(new danjumingxitable() );
                    }
            }
        }
    }
}

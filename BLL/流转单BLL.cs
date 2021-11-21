using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace 后整理管理系统.BLL
{
  public   class 流转单BLL
    {
        public static void 保存(Liuzhuancard liuzhuandan,List<liuzhuanmingxi > mingxis,List <StockTable > stocks,List<danjumingxitable > buliaomingxi )
        {
            var houzhengli = liuzhuandan.Beizhu;
            var cardnum = liuzhuandan.CardNum;
            LiuzhuancardService .InsertLiuzhuancard (liuzhuandan);
            foreach (var mingxi in mingxis)
            {
               liuzhuanmingxiService .Insertliuzhuanmingxi (mingxi);
            }
            foreach (var m in buliaomingxi )
            {
                danjumingxitableService.Insertdanjumingxitable(m);
                StockTableService.UpdateStockTable($"LiuzhuanCard='{cardnum  }',houzhengli='{houzhengli }'", x => x.orderNum == m.OrderNum &&
                x.CKMC == liuzhuandan.StockName&&x.BH ==m.Bianhao &&x.GH==m.ganghao &&x.PM ==m.pingming &&x.kuanhao ==m.kuanhao 
                && x.CustomName == m.CustomName && x.Huahao ==m.Huahao &&x.YS==m.yanse &&x.ColorNum ==m.ColorNum ) ;
            }
            //foreach (var s in stocks )
            //{
            //    s.LiuzhuanCard = liuzhuandan.CardNum;
            //    StockTableService .UpdateStockTable (s,x => x.ID == s.ID);
            //}
            Task.Run(() => {
                var danjumingxilist = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == liuzhuandan.CardNum);
                foreach (var d in danjumingxilist )
                {
                    var res = danjumingxitableService.Getdanjumingxitablelst($"select danjumingxitable.* from danjumingxitable,danjutable where danjutable.djlx='{DanjuLeiXing.入库单 }'" +
                        $" and danjumingxitable.bianhao='{d.Bianhao}' and danjumingxitable.pingming='{d.pingming}' and danjumingxitable.guige='{d.guige}'" +
                        $" and danjumingxitable.yanse='{d.yanse}'  and danjumingxitable.ganghao='{d.ganghao}' and danjumingxitable.danhao=danjutable.dh");
                    if (res.Count > 0)
                    {
                        danjumingxitableService.Updatedanjumingxitable($"houzhengli='{houzhengli }'", x => x.ID == res[0].ID);
                    }
                }
            });
        }
        public static void 修改(Liuzhuancard liuzhuandan, List<liuzhuanmingxi> mingxis, List<StockTable> stocks, List<danjumingxitable> buliaomingxi)
        {

            LiuzhuancardService.UpdateLiuzhuancard (liuzhuandan,x=>x.ID==liuzhuandan.ID );
            Connect.CreatConnect().DoSQL($"delete from liuzhuanmingxi  where cardnum='{liuzhuandan.CardNum }'");
            danjumingxitableService.Deletedanjumingxitable(x=>x.danhao ==liuzhuandan.CardNum);
            foreach (var mingxi in mingxis)
            {
                liuzhuanmingxiService.Insertliuzhuanmingxi(mingxi);
            }
            Connect.CreatConnect().DoSQL($"update stocktable set liuzhuancard='',houzhengli='' where liuzhuancard='{liuzhuandan.CardNum }'");
            //foreach (var s in stocks)
            //{
            //    s.LiuzhuanCard = liuzhuandan.CardNum;
            //    s.houzhengli = liuzhuandan.Beizhu;
            //    StockTableService.UpdateStockTable(s, x => x.ID == s.ID);
            //}
            foreach (var m in buliaomingxi)
            {
                danjumingxitableService.Insertdanjumingxitable(m);
                StockTableService.UpdateStockTable($"LiuzhuanCard='{liuzhuandan.CardNum }',houzhengli='{liuzhuandan.Beizhu }'", x => x.orderNum == m.OrderNum &&
              x.CKMC == liuzhuandan.StockName && x.BH == m.Bianhao && x.GH == m.ganghao && x.PM == m.pingming && x.kuanhao == m.kuanhao&&x.CustomName ==m.CustomName 
               && x.Huahao == m.Huahao && x.YS == m.yanse && x.ColorNum == m.ColorNum);
            }
        }
    }
}

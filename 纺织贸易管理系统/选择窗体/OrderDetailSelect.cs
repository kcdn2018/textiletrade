using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纺织贸易管理系统.选择窗体
{
    public class OrderDetailSelect
    {/// <summary>
    /// 订单明细选择赋值到单据明细
    /// </summary>
    /// <param name="rowindex">行号</param>
    /// <param name="danjumingxitables">单据明细列表</param>
    /// <param name="ToupiList">染色取坯列表</param>
    /// <param name="gongyi">工艺</param>
    /// <param name="danhao">单号</param>
    /// <param name="rq">日期</param>
        public static void Select(int rowindex, List<danjumingxitable> danjumingxitables, List<RangShequpiTable> ToupiList, string gongyi, string danhao, DateTime rq)
        {
            if (danjumingxitables[rowindex].OrderNum != null)
            {
                var fm = new 订单明细选择() { OrderNum = danjumingxitables[rowindex].OrderNum };
                fm.ShowDialog();
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == danjumingxitables[rowindex].OrderNum);
                var i = rowindex;
                foreach (var pingzhong in fm.pingzhong)
                {
                    danjumingxitables[i].bizhong = "人民币￥";
                    danjumingxitables[i].Bianhao = pingzhong.sampleNum;
                    danjumingxitables[i].guige = pingzhong.Specifications;
                    danjumingxitables[i].chengfeng = pingzhong.Component;
                    danjumingxitables[i].pingming = pingzhong.sampleName;
                    danjumingxitables[i].kezhong = pingzhong.weight;
                    danjumingxitables[i].menfu = pingzhong.width;
                    danjumingxitables[i].danwei = "米";
                    danjumingxitables[i].OrderNum = pingzhong.OrderNum;
                    danjumingxitables[i].kuanhao = pingzhong.Kuanhao;
                    danjumingxitables[i].yanse = pingzhong.color;
                    danjumingxitables[i].chengpingmishu =pingzhong.Shengyumishu ;
                    danjumingxitables[i].ContractNum = order.ContractNum;
                    danjumingxitables[i].CustomName = order.CustomerName;
                    danjumingxitables[i].Huahao = pingzhong.Huahao;
                    danjumingxitables[i].ColorNum = pingzhong.ColorNum;
                    danjumingxitables[i].CustomerColorNum = pingzhong.CustomerColorNum;
                    danjumingxitables[i].CustomerPingMing = pingzhong.CustomerPingMing;
                    var mx = ToupiList.Where(x => x.SampleNum == pingzhong.sampleNum && x.OrderNum == pingzhong.OrderNum && x.color == pingzhong.color).ToList();
                    if (mx.Count > 0)
                    {
                        danjumingxitables[i].houzhengli = mx[0].houzhengli + "+" + gongyi;
                        danjumingxitables[i].ganghao = mx[0].ganghao;
                    }
                    else
                    {
                        danjumingxitables[i].houzhengli = gongyi;
                    }
                    i++;
                    if (i == danjumingxitables.Count - 1)
                        for (int j = 0; j < 30; j++)
                        {
                            danjumingxitables.Add(new danjumingxitable() { danhao = danhao, rq = rq });
                        }
                }
                fm.Dispose();
            }
        }
      }
 }
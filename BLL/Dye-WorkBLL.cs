using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
    /// <summary>
    /// 染厂业务处理
    /// </summary>
   public  class Dye_WorkBLL
    {
        /// <summary>
        /// 增加染厂库存
        /// </summary>
        /// <param name="Dye_workName">染厂名字</param>
        /// <param name="mingxiS">明细列表</param>
        public static void IncreaseStock(string Dye_workName,List<danjumingxitable> mingxiS)
        {
            var lianxiren = LXRService.GetOneLXR(x => x.MC == Dye_workName);
            if (lianxiren.Leixing == "染厂") //只有染厂才能添加到染厂库存
            {
                foreach (var m in mingxiS)
                {
                    var stock = Connect.DbHelper().Queryable<RangChangStockTable>().First(x => x.CKMC == Dye_workName && x.BH == m.Bianhao && x.MF == m.menfu && x.YS == m.yanse &&
                   x.Houzhengli == m.houzhengli && x.gonghuoshang == m.PiBuChang && x.Kuanhao == m.kuanhao && x.ordernum == m.OrderNum);
                    if(stock !=null ) //已经存在增加数字
                    {
                        stock.MS += m.chengpingmishu;
                        stock.JS += m.chengpingjuanshu;
                        stock.ShengyuMishu += m.chengpingmishu;
                        Connect.DbHelper().Updateable<RangChangStockTable>(stock).ExecuteCommand();
                    }
                    else
                    {
                        //直接新增记录
                        RangChangStockTableService.InsertRangChangStockTable(new RangChangStockTable()
                        {
                            BH = m.Bianhao,
                            CaigouDanhao = m.rkdh,
                            CF = m.chengfeng,
                            CKMC = Dye_workName,
                            GG = m.guige,
                            gonghuoshang = m.PiBuChang,
                            Houzhengli = m.houzhengli,
                            GH = m.ganghao,
                            JS = m.chengpingjuanshu,
                            Kuanhao = m.kuanhao,
                            KZ = m.kezhong,
                            MF = m.menfu,
                            ordernum = m.OrderNum,
                            MS = m.chengpingmishu,
                            own = string.Empty,
                            PM = m.pingming,
                            RKDH = m.danhao,
                            RQ = m.rq,
                            ShengyuMishu = m.chengpingmishu,
                            YS = m.yanse,
                            Zhuangtai = string.Empty
                        });
                    }
                }
            }
        }
        /// <summary>
        /// 减少染厂库存
        /// </summary>
        /// <param name="Dye_workName">染厂名称</param>
        /// <param name="mingxiS">明细列表</param>
        public static void DecreaseStock(string Dye_workName, List<danjumingxitable> mingxiS)
        {
            var lianxiren = LXRService.GetOneLXR(x => x.MC == Dye_workName);
            if (lianxiren.Leixing == "染厂") //只有染厂才能添加到染厂库存
            {
                foreach (var m in mingxiS)
                {
                    var stock = Connect.DbHelper().Queryable<RangChangStockTable>().First(x => x.CKMC == Dye_workName && x.BH == m.Bianhao && x.MF == m.menfu && x.YS == m.yanse &&
                   x.Houzhengli == m.houzhengli && x.gonghuoshang == m.PiBuChang && x.Kuanhao == m.kuanhao && x.ordernum == m.OrderNum);
                    if (stock != null) //已经存在增加数字
                    {
                        stock.MS -= m.chengpingmishu;
                        stock.JS -= m.chengpingjuanshu;
                        stock.ShengyuMishu -= m.chengpingmishu;
                        Connect.DbHelper().Updateable<RangChangStockTable>(stock).ExecuteCommand();
                        
                    }
                    else
                    {
                        //直接新增记录
                        RangChangStockTableService.InsertRangChangStockTable(new RangChangStockTable()
                        {
                            BH = m.Bianhao,
                            CaigouDanhao = m.rkdh,
                            CF = m.chengfeng,
                            CKMC = Dye_workName,
                            GG = m.guige,
                            gonghuoshang = m.PiBuChang,
                            Houzhengli = m.houzhengli,
                            GH = m.ganghao,
                            JS =- m.chengpingjuanshu,
                            Kuanhao = m.kuanhao,
                            KZ = m.kezhong,
                            MF = m.menfu,
                            ordernum = m.OrderNum,
                            MS =- m.chengpingmishu,
                            own = string.Empty,
                            PM = m.pingming,
                            RKDH = m.danhao,
                            RQ = m.rq,
                            ShengyuMishu =- m.chengpingmishu,
                            YS = m.yanse,
                            Zhuangtai = string.Empty
                        });
                    }
                }
            }
            RangChangStockTableService.DeleteRangChangStockTable(x => x.JS  == 0);
        }
    }
}

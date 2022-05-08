using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Tools;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 库存BLL
    {
        public static void 增加库存(List<danjumingxitable> danjumingxitables,DanjuTable danjuTable  )
        {
                foreach (var mingxi in danjumingxitables)
                {
                    var stock =StockTableService.GetOneStockTable  (x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.MF == mingxi.menfu && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse &&
                      x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum && x.CustomName == mingxi.CustomName
                       && x.Pihao == mingxi.Pihao && x.PibuChang == mingxi.PiBuChang);
                    //库存没有这个布 当编号为空的时候
                    if (stock.ID==0 )
                    {
                        stock.AvgPrice = mingxi.hanshuidanjia + mingxi.AveragePrice + (danjuTable.yunfei + danjuTable.ChaCheFei + danjuTable.ZhuangXieFei) / danjumingxitables.Sum(x => x.chengpingmishu);
                        stock.BH = mingxi.Bianhao;
                        stock.biaoqianmishu = 0;
                        stock.CF = mingxi.chengfeng;
                        stock.CKMC = danjuTable.ckmc;
                        stock.ContractNum = mingxi.ContractNum;
                        stock.CustomName = mingxi.CustomName;
                        stock.GG = mingxi.guige;
                        stock.GH = mingxi.ganghao;
                        stock.houzhengli = mingxi.houzhengli;
                        stock.JS = mingxi.chengpingjuanshu;
                        stock.kaijianmishu = 0;
                        stock.kuanhao = mingxi.kuanhao;
                        stock.Kuwei = mingxi.Kuwei;
                        stock.KZ = mingxi.kezhong;
                        stock.MF = mingxi.menfu;
                        stock.MS = mingxi.chengpingmishu;
                        stock.orderNum = mingxi.OrderNum;
                        stock.own = danjuTable.own;
                        stock.PM = mingxi.pingming;
                        stock.RKDH = danjuTable.ksmc;
                        stock.RQ = danjuTable.rq;
                        stock.TotalMoney = mingxi.hanshuiheji;
                        stock.YS = mingxi.yanse;
                        stock.Huahao = mingxi.Huahao;
                        stock.ColorNum = mingxi.ColorNum;
                        stock.CustomerColorNum = mingxi.CustomerColorNum;
                        stock.CustomerPingMing = mingxi.CustomerPingMing;
                        stock.RukuNum = mingxi.chengpingmishu;
                        stock.Rangchang = mingxi.Rangchang;
                        stock.PibuChang = mingxi.PiBuChang;
                        stock.Pihao = mingxi.Pihao;
                        stock.LiuzhuanCard = danjuTable.LiuzhuanCard;
                        stock.Remarkers = mingxi.beizhu;
                        stock.FrabicWidth = mingxi.FrabicWidth;
                        StockTableService.InsertStockTable(stock);
                    }
                    //如果已经存在
                    else
                    {
                        stock.MS += mingxi.chengpingmishu;
                        stock.JS += mingxi.chengpingjuanshu;
                        stock.TotalMoney += (mingxi.hanshuiheji + mingxi.AveragePrice * mingxi.chengpingmishu);
                        stock.RukuNum += mingxi.chengpingmishu;
                        if (stock.MS != 0)
                        {
                            stock.AvgPrice = stock.MS == 0 ? 0 : (int)stock.TotalMoney / stock.MS;
                        }
                        stock.Remarkers = mingxi.beizhu;
                        //     StockTableService.UpdateStockTable(stock, x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse  &&
                        //x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                        StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);
                    }
                    增加订单明细的库存数(mingxi, danjuTable.ckmc);
                }
        }
        public static void 增加订单明细的库存数(danjumingxitable mingxi, string StockName)
        {
            var order = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == mingxi.OrderNum && x.color == mingxi.yanse
               && x.Kuanhao == mingxi.kuanhao  && x.CustomerPingMing == mingxi.CustomerPingMing && x.sampleNum == mingxi.Bianhao && x.width == mingxi.menfu);
            if (!string.IsNullOrEmpty(order.sampleNum))
            {
                order.StockNum += mingxi.chengpingmishu;
                var stock = StockInfoTableService.GetOneStockInfoTable(x => x.mingcheng == StockName);
                if (!string.IsNullOrEmpty(stock.mingcheng) && stock.Leixing != "次品仓库")
                {
                    OrderDetailTableService.UpdateOrderDetailTable($"StockNum='{order.StockNum }'", x => x.ID == order.ID);
                }
                else
                {
                    if(string.IsNullOrEmpty(stock.mingcheng))
                    {
                        var lxr = LXRService.GetOneLXR(x => x.MC == StockName);
                        if(lxr.Leixing == Gonhuoshang.涂层厂 )
                        {
                            order.JiaGongchangNum += mingxi.chengpingmishu;
                            order.HouzhengliStockNum += mingxi.chengpingmishu;
                            OrderDetailTableService.UpdateOrderDetailTable($"JiaGongchangNum='{order.JiaGongchangNum }',HouzhengliStockNum='{order.HouzhengliStockNum }'", x => x.ID == order.ID);
                        }
                        else
                        {
                            if (lxr.Leixing == Gonhuoshang.染厂)
                            {
                                order.RanChangNum  += mingxi.chengpingmishu;
                                OrderDetailTableService.UpdateOrderDetailTable($"RanChangNum='{order.RanChangNum }'", x => x.ID == order.ID);
                            }
                            else
                            {
                                order.HouzhengliStockNum += mingxi.chengpingmishu;
                                OrderDetailTableService.UpdateOrderDetailTable($"HouzhengliStockNum='{order.HouzhengliStockNum }'", x => x.ID == order.ID);
                            }
                        }
                    }
                }
            }
        }
        public static void 减少订单明细的库存数(danjumingxitable mingxi, string StockName)
        {
            var order = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == mingxi.OrderNum && x.color == mingxi.yanse
               && x.Kuanhao == mingxi.kuanhao && x.CustomerPingMing == mingxi.CustomerPingMing && x.sampleNum == mingxi.Bianhao && x.width  == mingxi.menfu);
            if (!string.IsNullOrEmpty(order.sampleNum))
            {
                order.StockNum -= mingxi.chengpingmishu;
                var stock = StockInfoTableService.GetOneStockInfoTable(x => x.mingcheng == StockName);
                if (!string.IsNullOrEmpty(stock.mingcheng) && stock.Leixing != "次品仓库")
                {
                    OrderDetailTableService.UpdateOrderDetailTable($"StockNum='{order.StockNum }'", x => x.ID == order.ID);
                }
                else
                {
                    if (string.IsNullOrEmpty(stock.mingcheng))
                    {
                        var lxr = LXRService.GetOneLXR(x => x.MC == StockName);
                        if (lxr.Leixing == Gonhuoshang.涂层厂)
                        {
                            order.JiaGongchangNum -= mingxi.chengpingmishu;
                            order.HouzhengliStockNum -= mingxi.chengpingmishu;
                            OrderDetailTableService.UpdateOrderDetailTable($"JiaGongchangNum='{order.JiaGongchangNum }',HouzhengliStockNum='{order.HouzhengliStockNum }'", x => x.ID == order.ID);
                        }
                        else
                        {
                            if (lxr.Leixing == Gonhuoshang.染厂 )
                            {
                                order.RanChangNum  -= mingxi.chengpingmishu;
                                OrderDetailTableService.UpdateOrderDetailTable($"RanChangNum='{order.RanChangNum }'", x => x.ID == order.ID);
                            }
                            else
                            {
                                order.HouzhengliStockNum -= mingxi.chengpingmishu;
                                OrderDetailTableService.UpdateOrderDetailTable($"HouzhengliStockNum='{order.HouzhengliStockNum }'", x => x.ID == order.ID);
                            }
                        }
                    }
                }
            }
        }
        public static void 减少库存(List<danjumingxitable> danjumingxitables, DanjuTable danjuTable)
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock =StockTableService.GetOneStockTable (x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.MF == mingxi.menfu && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse &&
                  x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum && x.CustomName == mingxi.CustomName
                   && x.Pihao == mingxi.Pihao && x.PibuChang == mingxi.PiBuChang);
                //库存没有这个布  当编号为空的时候
                if (stock.ID==0)
                {
                    stock.AvgPrice = mingxi.Cost ;
                    stock.BH = mingxi.Bianhao;
                    stock.biaoqianmishu = 0;
                    stock.CF = mingxi.chengfeng;
                    stock.CKMC = danjuTable.ckmc;
                    stock.ContractNum = mingxi.ContractNum;
                    stock.CustomName = mingxi.CustomName;
                    stock.GG = mingxi.guige;
                    stock.GH = mingxi.ganghao;
                    stock.houzhengli = mingxi.houzhengli;
                    stock.JS = 0 - mingxi.chengpingjuanshu;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.kuanhao;
                    stock.Kuwei = mingxi.Kuwei;
                    stock.KZ = mingxi.kezhong;
                    stock.MF = mingxi.menfu;
                    stock.MS = 0 - mingxi.chengpingmishu;
                    stock.orderNum = mingxi.OrderNum;
                    stock.own = danjuTable.own;
                    stock.PM = mingxi.pingming;
                    stock.RKDH = mingxi.danhao;
                    stock.RQ = danjuTable.rq;
                    stock.TotalMoney = 0 - mingxi.hanshuiheji;
                    stock.YS = mingxi.yanse;
                    stock.Huahao = mingxi.Huahao;
                    stock.ColorNum = mingxi.ColorNum;
                    stock.CustomerColorNum = mingxi.CustomerColorNum;
                    stock.CustomerPingMing = mingxi.CustomerPingMing;
                    stock.Rangchang = mingxi.Rangchang;
                    stock.RKDH = danjuTable.ksmc;
                    stock.PibuChang = mingxi.PiBuChang;
                    stock.Pihao = mingxi.Pihao;
                    stock.LiuzhuanCard = danjuTable.LiuzhuanCard;
                    stock.Remarkers = mingxi.beizhu;
                    stock.FrabicWidth = mingxi.FrabicWidth;
                    if(danjuTable.djlx ==DanjuLeiXing.销售退货单 )
                    {
                        stock.RukuNum -= mingxi.chengpingjuanshu;
                    }
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {           
                        stock.MS -= mingxi.chengpingmishu;
                        stock.JS -= mingxi.chengpingjuanshu;
                    if (danjuTable.djlx.Contains("入库"))
                    { stock.RukuNum -= mingxi.chengpingmishu; }
                    if (danjuTable.djlx == DanjuLeiXing.销售退货单)
                    {
                        stock.RukuNum -= mingxi.chengpingjuanshu;
                    }
                    stock.TotalMoney -= mingxi.chengpingmishu *mingxi.AveragePrice ;
                    if (stock.TotalMoney != 0&&stock.MS!=0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    stock.Remarkers = mingxi.beizhu;
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse  &&
                    //x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao&&x.Kuwei==mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID); 
                    清零库存(stock);
                 
                }
                减少订单明细的库存数(mingxi, danjuTable.ckmc);
            }           
        }
        /// <summary>
        /// 减少生产入库库存
        /// </summary>
        /// <param name="danjumingxitables"></param>
        /// <param name="danjuTable"></param>
        public static void 减少入库库存(List<danjumingxitable> danjumingxitables, DanjuTable danjuTable)
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.YS == mingxi.yanse &&
                 x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.PM == mingxi.pingming  && x.CF == mingxi.chengfeng &&x.KZ==mingxi.kezhong
                  && x.Pihao == mingxi.Pihao && x.PibuChang == mingxi.PiBuChang);
                //库存没有这个布  当编号为空的时候
                if (stock.ID == 0)
                {
                    stock.AvgPrice = mingxi.hanshuidanjia;
                    stock.BH = mingxi.Bianhao;
                    stock.biaoqianmishu = 0;
                    stock.CF = mingxi.chengfeng;
                    stock.CKMC = danjuTable.ckmc;
                    stock.ContractNum = mingxi.ContractNum;
                    stock.CustomName = mingxi.CustomName;
                    stock.GG = mingxi.guige;
                    stock.GH = mingxi.ganghao;
                    stock.houzhengli = mingxi.houzhengli;
                    stock.JS = 0 - mingxi.chengpingjuanshu;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.kuanhao;
                    stock.Kuwei = mingxi.Kuwei;
                    stock.KZ = mingxi.kezhong;
                    stock.MF = mingxi.menfu;
                    stock.MS = 0 - mingxi.chengpingmishu;
                    stock.orderNum = mingxi.OrderNum;
                    stock.own = danjuTable.own;
                    stock.PM = mingxi.pingming;
                    stock.RKDH = mingxi.danhao;
                    stock.RQ = danjuTable.rq;
                    stock.TotalMoney = 0 - mingxi.hanshuiheji;
                    stock.YS = mingxi.yanse;
                    stock.Huahao = mingxi.Huahao;
                    stock.ColorNum = mingxi.ColorNum;
                    stock.CustomerColorNum = mingxi.CustomerColorNum;
                    stock.CustomerPingMing = mingxi.CustomerPingMing;
                    stock.RKDH = danjuTable.ksmc;
                    stock.Remarkers = mingxi.beizhu;
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {
                    stock.MS -= mingxi.chengpingmishu;
                    stock.JS -= mingxi.chengpingjuanshu;
                    stock.TotalMoney -= mingxi.hanshuiheji;
                    stock.RukuNum -= mingxi.chengpingmishu;
                    if (stock.TotalMoney != 0 && stock.MS != 0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    stock.Remarkers = mingxi.beizhu;
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse  &&
                    //x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao&&x.Kuwei==mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);  
                    清零库存(stock);
                }
                减少订单明细的库存数(mingxi, danjuTable.ckmc);
            }          
        }
        /// <summary>
        /// 增加生产入库库存
        /// </summary>
        /// <param name="danjumingxitables"></param>
        /// <param name="danjuTable"></param>
        public static void 增加入库库存(List<danjumingxitable> danjumingxitables, DanjuTable danjuTable)
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.YS == mingxi.yanse &&
                 x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.PM == mingxi.pingming && x.CF == mingxi.chengfeng && x.KZ == mingxi.kezhong);
                //库存没有这个布  当编号为空的时候
                if (stock.ID == 0)
                {
                    stock.AvgPrice = mingxi.hanshuidanjia;
                    stock.BH = mingxi.Bianhao;
                    stock.biaoqianmishu = 0;
                    stock.CF = mingxi.chengfeng;
                    stock.CKMC = danjuTable.ckmc;
                    stock.ContractNum = mingxi.ContractNum;
                    stock.CustomName = mingxi.CustomName;
                    stock.GG = mingxi.guige;
                    stock.GH = mingxi.ganghao;
                    stock.houzhengli = mingxi.houzhengli;
                    stock.JS =  mingxi.chengpingjuanshu;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.kuanhao;
                    stock.Kuwei = mingxi.Kuwei;
                    stock.KZ = mingxi.kezhong;
                    stock.MF = mingxi.menfu;
                    stock.MS = mingxi.chengpingmishu;
                    stock.orderNum = mingxi.OrderNum;
                    stock.own = danjuTable.own;
                    stock.PM = mingxi.pingming;
                    stock.RKDH = mingxi.danhao;
                    stock.RQ = danjuTable.rq;
                    stock.TotalMoney =  mingxi.hanshuiheji;
                    stock.YS = mingxi.yanse;
                    stock.Huahao = mingxi.Huahao;
                    stock.ColorNum = mingxi.ColorNum;
                    stock.CustomerColorNum = mingxi.CustomerColorNum;
                    stock.CustomerPingMing = mingxi.CustomerPingMing;
                    stock.Rangchang = mingxi.Rangchang;
                    stock.Remarkers = mingxi.beizhu;
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {
                    stock.MS += mingxi.chengpingmishu;
                    stock.JS += mingxi.chengpingjuanshu;
                    stock.TotalMoney -= mingxi.hanshuiheji;
                    if (stock.TotalMoney != 0 && stock.MS != 0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    stock.Remarkers = mingxi.beizhu;
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse  &&
                    //x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao&&x.Kuwei==mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID); 
                    清零库存(stock);
                } 
                增加订单明细的库存数(mingxi, danjuTable.ckmc);
            }          
        }
        public static void 清零库存(StockTable s)
        {
            //不录库存明细的
            var juan = JuanHaoTableService.GetJuanHaoTablelst(x => x.SampleNum == s.BH && x.OrderNum == s.orderNum && x.Houzhengli == s.houzhengli && x.GangHao == s.GH && x.yanse == s.YS && x.kuanhao == s.kuanhao && x.state == 0 && x.Huahao == s.Huahao && x.Ckmc == s.CKMC);
            if (juan.Count == 0)
            {
                if (s.MS == 0 && s.JS == 0)
                {
                    StockTableService.DeleteStockTable(x => x.ID == s.ID);
                    return;
                    //StockTableService.UpdateStockTable ($"IsFinish='1'", x => x.ID == s.ID);
                }
                if (s.IsCheckDone == "已结束")
                {
                    StockTableService.DeleteStockTable(x => x.ID == s.ID);
                    return;
                    //StockTableService.UpdateStockTable ($"IsFinish='1'", x => x.ID == s.ID);
                }
                if (s.IsCheckDone == string.Empty)
                {
                    if (s.JS <= 0)
                    {
                        StockTableService.DeleteStockTable(x => x.ID == s.ID);
                        return;
                    }
                    //StockTableService.UpdateStockTable ($"IsFinish='1'", x => x.ID == s.ID);
                }
            }
        }
        public static void 清零库存(List<StockTable> stocks)
        {
            foreach (var s in stocks)
            {
                var juan = JuanHaoTableService.GetJuanHaoTablelst(x => x.SampleNum == s.BH && x.OrderNum == s.orderNum && x.Houzhengli == s.houzhengli && x.GangHao == s.GH && x.yanse == s.YS && x.kuanhao == s.kuanhao && x.state == 0);
                if (juan.Count >= 0)
                {
                    StockTableService.DeleteStockTable(x => x.ID == s.ID);
                }
            }
        }
        public static void 减少库存(List<RangShequpiTable > rangShequpiTables ,DanjuTable danjuTable )
        {
            foreach (var mingxi in rangShequpiTables )
            {
               var stock=StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.SampleNum && x.YS == mingxi.color &&
                    x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Remarkers && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                    //库存没有这个布  当编号为空的时候
                if (stock.ID == 0)
                {
                    stock.AvgPrice = 0;
                    stock.BH = mingxi.SampleNum ;
                    stock.biaoqianmishu = 0;
                    stock.CF = mingxi.chengfeng;
                    stock.CKMC = danjuTable.ckmc;
                    stock.ContractNum = mingxi.ContractNum;
                    stock.CustomName = mingxi.CustomName;
                    stock.GG = mingxi.Specifications ;
                    stock.GH = mingxi.ganghao;
                    stock.houzhengli = mingxi.houzhengli;
                    stock.JS = 0 - mingxi.ToupiJuanshu ;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.kuanhao;
                    stock.Kuwei = mingxi.Remarkers;
                    stock.KZ = mingxi.kezhong;
                    stock.MF = mingxi.menfu;
                    stock.MS = 0 - mingxi.ToupiMishu ;
                    stock.orderNum = mingxi.OrderNum;
                    stock.own = danjuTable.own;
                    stock.PM = mingxi.sampleName ;
                    stock.RKDH = mingxi.CaigouDanhao ;
                    stock.RQ = danjuTable.rq;
                    stock.TotalMoney = 0;
                    stock.YS = mingxi.color ;
                    stock.Huahao = mingxi.Huahao;
                    stock.ColorNum = mingxi.ColorNum;
                    stock.CustomerColorNum = mingxi.CustomerColorNum;
                    stock.CustomerPingMing = mingxi.CustomerPingMing;
                    stock.RukuNum = 0 - mingxi.ToupiMishu;
                    stock.PibuChang = mingxi.PibuChang;
                    stock.Pihao = mingxi.Pihao;
                    stock.Remarkers = mingxi.Remarkers;
                    stock.FrabicWidth = mingxi.FrabicWidth;
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {
                    stock.MS -= mingxi.ToupiMishu ;
                    stock.JS -= mingxi.ToupiJuanshu ;
                    stock.TotalMoney -= mingxi.ToupiMishu*stock.AvgPrice ;
                    stock.RukuNum -= mingxi.ToupiMishu;
                    if (stock.TotalMoney != 0 && stock.MS != 0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    stock.Remarkers = mingxi.Remarkers;
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.SampleNum  && x.YS == mingxi.color  &&
                    //x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Remarkers && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID); 
                    清零库存(stock);
                   
                }
                var danjumingxi = new danjumingxitable()
                {
                    chengpingmishu = mingxi.ToupiMishu,
                    OrderNum = mingxi.OrderNum,
                    yanse = mingxi.color,
                    kuanhao = mingxi.kuanhao,
                    CustomerPingMing = mingxi.CustomerPingMing,
                    ColorNum = mingxi.ColorNum,
                    Bianhao = mingxi.SampleNum,
                };
                减少订单明细的库存数(danjumingxi, danjuTable.ckmc);
            }
           
        }
        public static void 增加库存(List<RangShequpiTable> rangShequpiTables, DanjuTable danjuTable)
        {
            foreach (var mingxi in rangShequpiTables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.SampleNum && x.YS == mingxi.color &&
                    x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Remarkers && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum  );
                //库存没有这个布  当编号为空的时候
                if (stock.ID == 0)
                {
                    stock.AvgPrice = mingxi.Danjia ;
                    stock.BH = mingxi.SampleNum;
                    stock.biaoqianmishu = 0;
                    stock.CF = mingxi.chengfeng;
                    stock.CKMC = danjuTable.ckmc;
                    stock.ContractNum = mingxi.ContractNum;
                    stock.CustomName = mingxi.CustomName;
                    stock.GG = mingxi.Specifications;
                    stock.GH = mingxi.ganghao;
                    stock.houzhengli = mingxi.houzhengli;
                    stock.JS =  mingxi.ToupiJuanshu;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.kuanhao;
                    stock.Kuwei = mingxi.Remarkers;
                    stock.KZ = mingxi.kezhong;
                    stock.MF = mingxi.menfu;
                    stock.MS = mingxi.ToupiMishu;
                    stock.orderNum = mingxi.OrderNum;
                    stock.own = danjuTable.own;
                    stock.PM = mingxi.sampleName;
                    stock.RKDH = mingxi.CaigouDanhao;
                    stock.RQ = danjuTable.rq;
                    stock.TotalMoney = mingxi.Heji ;
                    stock.YS = mingxi.color;
                    stock.Huahao = mingxi.Huahao;
                    stock.ColorNum = mingxi.ColorNum;
                    stock.CustomerColorNum = mingxi.CustomerColorNum;
                    stock.CustomerPingMing = mingxi.CustomerPingMing;
                    stock.RukuNum = mingxi.ToupiMishu;
                    stock.PibuChang = mingxi.PibuChang;
                    stock.Pihao = mingxi.Pihao;
                    stock.Rangchang = danjuTable.ksmc ;
                    stock.Remarkers = mingxi.Remarkers;
                    stock.FrabicWidth = mingxi.FrabicWidth;
                    //stock.RukuNum = mingxi.ToupiMishu;
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {
                    stock.MS += mingxi.ToupiMishu;
                    stock.JS += mingxi.ToupiJuanshu;
                    stock.TotalMoney +=  mingxi.Heji ;
                    stock.RukuNum += mingxi.ToupiMishu;
                    if (stock.TotalMoney != 0 && stock.MS != 0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    stock.Remarkers = mingxi.Remarkers;
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.SampleNum && x.YS == mingxi.color &&
                    //x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Remarkers && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);                
                } 
                var danjumingxi = new danjumingxitable()
                    {
                        chengpingmishu = mingxi.ToupiMishu,
                        OrderNum = mingxi.OrderNum,
                        yanse = mingxi.color,
                        kuanhao = mingxi.kuanhao,
                        CustomerPingMing = mingxi.CustomerPingMing,
                        ColorNum = mingxi.ColorNum,
                        Bianhao = mingxi.SampleNum,
                    };
                增加订单明细的库存数(danjumingxi, danjuTable.ckmc  );
            }
        }
        public static void 增加库存(List<ChangliangTable> changliangTables)
        {
            foreach (var mingxi in changliangTables )
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == mingxi.Ckmc  && x.orderNum == "" && x.BH == mingxi.PingzhongBianhao  && x.YS == "" &&
                x.kuanhao == mingxi.Pihao  && x.houzhengli == "" && x.GH == "" && x.Kuwei == mingxi.Kuwei );
                //库存没有这个布  当编号为空的时候
                if (stock.ID == 0)
                {
                    stock.AvgPrice =0;
                    stock.BH = mingxi.PingzhongBianhao ;
                    stock.biaoqianmishu = 0;
                    stock.CF = "";
                    stock.CKMC = mingxi .Ckmc;
                    stock.ContractNum = "";
                    stock.CustomName = "";
                    stock.GG = mingxi.GuiGe ;
                    stock.GH ="";
                    stock.houzhengli = "";
                    stock.JS = 1;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.Pihao ;
                    stock.Kuwei = mingxi.Kuwei ;
                    stock.KZ ="";
                    stock.MF = "";
                    stock.MS = mingxi.Shuliang ;
                    stock.orderNum ="";
                    stock.own =mingxi.Yuangong ;
                    stock.PM = mingxi.PingMing ;
                    stock.RKDH = mingxi.Danhao;
                    stock.RQ = mingxi .Riqi ;
                    stock.TotalMoney = 0;
                    stock.RukuNum = mingxi.Shuliang;
                    stock.YS = "";                  
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {
                    stock.MS += mingxi.Shuliang ;
                    stock.JS +=1;
                    stock.TotalMoney += 0;
                    stock.RukuNum += mingxi.Shuliang;
                    if (stock.TotalMoney != 0 && stock.MS != 0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == mingxi .Ckmc && x.orderNum == "" && x.BH == mingxi.PingzhongBianhao  && x.YS =="" &&
                    //x.kuanhao == mingxi.Pihao  && x.houzhengli == "" && x.GH == "" && x.Kuwei == mingxi.Kuwei );
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);
                }
            }
        }
        public static void 减少库存(List<ChangliangTable> changliangTables)
        {
            foreach (var mingxi in changliangTables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == mingxi.Ckmc && x.orderNum == "" && x.BH == mingxi.PingzhongBianhao && x.YS == "" &&
                x.kuanhao == mingxi.Pihao && x.houzhengli == "" && x.GH == "" && x.Kuwei == mingxi.Kuwei);
                //库存没有这个布  当编号为空的时候
                if (stock.ID == 0)
                {
                    stock.AvgPrice = 0;
                    stock.BH = mingxi.PingzhongBianhao;
                    stock.biaoqianmishu = 0;
                    stock.CF = "";
                    stock.CKMC = mingxi.Ckmc;
                    stock.ContractNum = "";
                    stock.CustomName = "";
                    stock.GG = mingxi.GuiGe;
                    stock.GH = "";
                    stock.houzhengli = "";
                    stock.JS =- 1;
                    stock.kaijianmishu = 0;
                    stock.kuanhao = mingxi.Pihao;
                    stock.Kuwei = mingxi.Kuwei;
                    stock.KZ = "";
                    stock.MF = "";
                    stock.MS =0- mingxi.Shuliang;
                    stock.orderNum = "";
                    stock.own = mingxi.Yuangong;
                    stock.PM = mingxi.PingMing;
                    stock.RKDH = mingxi.Danhao;
                    stock.RQ = mingxi.Riqi;
                    stock.TotalMoney = 0;
                    stock.YS = "";
                    StockTableService.InsertStockTable(stock);
                }
                //如果已经存在
                else
                {
                    stock.MS -= mingxi.Shuliang;
                    stock.JS -= 1;
                    stock.TotalMoney += 0;
                    if (stock.TotalMoney != 0 && stock.MS != 0)
                    {
                        stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                    }
                    else
                    {
                        stock.AvgPrice = 0;
                    }
                    //     StockTableService.UpdateStockTable(stock, x => x.CKMC == mingxi.Ckmc && x.orderNum == "" && x.BH == mingxi.PingzhongBianhao && x.YS == "" &&
                    //x.kuanhao == mingxi.Pihao && x.houzhengli == "" && x.GH == "" && x.Kuwei == mingxi.Kuwei);
                    StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);
                }
            }
        }
        /// <summary>
        /// 检查库存中是否有这个商品,返回False表示有布料没库存否则表示全部有库存
        /// </summary>
        /// <param name="danjumingxitables">单据</param>
        /// <param name="danjuTable"></param>
        /// <returns></returns>
        public static danjumingxitable    检查库存 (List<danjumingxitable > danjumingxitables ,DanjuTable danjuTable )
        {
            foreach (var mingxi in danjumingxitables.Where (x=>x.Bianhao !=null).ToList ())
            {
                var stock = Connect.DbHelper ().Queryable <StockTable >().First (x => x.CKMC == danjuTable.ckmc && x.orderNum == mingxi.OrderNum && x.BH == mingxi.Bianhao && x.YS == mingxi.yanse &&
                x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                //库存没有这个布  当编号为空的时候
              if(stock==null)
                {
                    return mingxi  ;
                }
            }
            return new danjumingxitable ();
        }
        public static RangShequpiTable  检查库存(List<RangShequpiTable> danjumingxitables, DanjuTable danjuTable)
        {
            foreach (var mingxi in danjumingxitables.Where(x => x.SampleNum  != null).ToList())
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ksmc  && x.orderNum == mingxi.OrderNum && x.BH == mingxi.SampleNum && x.YS == mingxi.color &&
              x.kuanhao == mingxi.kuanhao && x.houzhengli == mingxi.houzhengli && x.GH == mingxi.ganghao && x.Kuwei == mingxi.Remarkers && x.Huahao == mingxi.Huahao && x.ColorNum == mingxi.ColorNum);
                //库存没有这个布  当编号为空的时候
                if (stock.BH == string.Empty)
                {
                    return mingxi;
                }
            }
            return new RangShequpiTable ();
        }
        public static void 增加库存(StockTable stocktable)
        {
            var stock = StockTableService.GetOneStockTable(x => x.CKMC == stocktable.CKMC  && x.orderNum == stocktable  .orderNum  && x.BH == stocktable.BH  && x.YS == stocktable.YS  &&
              x.kuanhao == stocktable .kuanhao && x.houzhengli ==stocktable .houzhengli && x.GH == stocktable.GH && x.Kuwei == stocktable .Kuwei && x.Huahao == stocktable.Huahao);
            //库存没有这个布  当编号为空的时候
            if (stock.ID == 0)
            {
                StockTableService.InsertStockTable(stocktable );
            }
            //如果已经存在
            else
            {
                stock.MS += stocktable.MS;
                stock.JS += stocktable.JS ;
                stock.biaoqianmishu += stock.biaoqianmishu;
                stock.yijianjuanshu += stock.yijianjuanshu;
                stock.yijianmishu += stock.yijianmishu;
                stock.TotalMoney +=stocktable.TotalMoney ;
                stock.RukuNum += stock.RukuNum;
                if (stock.MS != 0)
                {
                    stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                }
                StockTableService.UpdateStockTable(stock, x=>x.ID==stock.ID );
            }
            增加订单明细的库存数(new danjumingxitable() { 
                OrderNum=stocktable .orderNum ,
                Bianhao = stocktable.BH ,
                chengpingmishu = stocktable.MS ,
                chengpingjuanshu = stocktable.JS ,
                ganghao = stocktable.GH ,
                yanse = stocktable.YS ,
                ColorNum = stocktable.ColorNum ,
                kuanhao = stocktable.kuanhao ,
                Huahao = stocktable.Huahao ,
                CustomerColorNum = stocktable.CustomerColorNum ,
                CustomerPingMing = stocktable.CustomerPingMing 
            }, stocktable .CKMC );
        }
        public static void 减少库存(StockTable stocktable)
        {
            var stock = StockTableService.GetOneStockTable(x => x.CKMC == stocktable.CKMC && x.orderNum == stocktable.orderNum && x.BH == stocktable.BH && x.YS == stocktable.YS &&
              x.kuanhao == stocktable.kuanhao && x.houzhengli == stocktable.houzhengli && x.GH == stocktable.GH && x.Kuwei == stocktable.Kuwei && x.Huahao == stocktable.Huahao);
            //库存没有这个布  当编号为空的时候
            if (stock.ID == 0)
            {
                StockTableService.InsertStockTable(stocktable);
            }
            //如果已经存在
            else
            {
                stock.MS -= stocktable.MS;
                stock.JS -= stocktable.JS;
                stock.biaoqianmishu -= stock.biaoqianmishu;
                stock.yijianjuanshu -= stock.yijianjuanshu;
                stock.yijianmishu -= stock.yijianmishu;
                stock.TotalMoney -= stocktable.TotalMoney;
                stock.RukuNum -= stock.RukuNum;
                if (stock.MS != 0)
                {
                    stock.AvgPrice = (int)stock.TotalMoney / stock.MS;
                }
                StockTableService.UpdateStockTable(stock, x => x.ID == stock.ID);
            }
            减少订单明细的库存数(new danjumingxitable()
            {
                OrderNum = stocktable.orderNum,
                Bianhao = stocktable.BH,
                chengpingmishu = stocktable.MS,
                chengpingjuanshu = stocktable.JS,
                ganghao = stocktable.GH,
                yanse = stocktable.YS,
                ColorNum = stocktable.ColorNum,
                kuanhao = stocktable.kuanhao,
                Huahao = stocktable.Huahao,
                CustomerColorNum = stocktable.CustomerColorNum,
                CustomerPingMing = stocktable.CustomerPingMing
            }, stocktable.CKMC);
        }
        public static void 增加发货数量(DanjuTable danjuTable, List<danjumingxitable> danjumingxitables)
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.YS == mingxi.yanse &&
                    x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.PM == mingxi.pingming && x.CF == mingxi.chengfeng && x.KZ == mingxi.kezhong);
                if (stock.ID > 0)
                {
                    stock.YiFaNum += mingxi.chengpingmishu;
                    StockTableService.UpdateStockTable($"YiFaNum='{stock.YiFaNum}'", x => x.ID == stock.ID);
                }

            }
        }
        public static  void 减少发货数量(DanjuTable danjuTable, List<danjumingxitable> danjumingxitables)
        {
            foreach (var mingxi in danjumingxitables)
            {
                var stock = StockTableService.GetOneStockTable(x => x.CKMC == danjuTable.ckmc && x.YS == mingxi.yanse &&
                    x.GH == mingxi.ganghao && x.Kuwei == mingxi.Kuwei && x.PM == mingxi.pingming && x.CF == mingxi.chengfeng && x.KZ == mingxi.kezhong);
                if (stock.ID >0)
                {
                    stock.YiFaNum -= mingxi.chengpingmishu;
                    StockTableService.UpdateStockTable($"YiFaNum='{stock.YiFaNum}'", x => x.ID == stock.ID);
                }
            }
        }
        public static void 检验完毕(int id)
        {
            StockTableService.UpdateStockTable("IsCheckDone='已结束',ms=biaoqianmishu,js=yijianjuanshu", x => x.ID == id);
        }
        public static void 检验未完毕(int id)
        {
            StockTableService.UpdateStockTable("IsCheckDone='未结束'", x => x.ID == id);
        }
    }
}

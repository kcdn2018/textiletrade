using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 订单BLL
    {
        public static  string CheckOrderNum(string danhao,DateTime date )
        {
            while (!string.IsNullOrEmpty(OrderTableService.GetOneOrderTable(x => x.OrderNum == danhao).OrderNum))
            {
                danhao = danhao.Substring(0, danhao.Length -3)+ (danhao.Substring(danhao.Length -3,3).TryToInt()+1).ToString ();
            }
            return danhao;
        }
        public static void 新增(OrderTable order,List <OrderDetailTable > orderDetailTables )
        {
            if (SysInfo.GetInfo.own != "审核制")
            {
                order .state = "已审核";
            }
            order.YifuMoney = order.Deposit;
            order.HejiLilun = order.Deposit;
            order.OrderNum = 订单BLL.CheckOrderNum(order.OrderNum , order.Orderdate );
            OrderTableService.InsertOrderTable(order);
            if (orderDetailTables.Sum(x => x.OtherCost) > 0)
            {             
                DanjuTableService.InsertDanjuTable(CreatDanju(orderDetailTables, order));
                //来往明细BLL.增加来往记录(CreatDanju(orderDetailTables, order));
                //财务BLL.增加应收款(CreatDanju(orderDetailTables, order));
                //财务BLL.增加应开发票(CreatDanju(orderDetailTables, order)); 
            }
            foreach (var o in orderDetailTables)
            {
                o.OrderNum = order.OrderNum;
                o.Shengyumishu = o.YutouMishu - o.Yitoumishu;
                 //OrderDetailTableService.InsertOrderDetailTable(o); 
                 
                if(o.OtherCost !=0)
                {                                     
                    增加单据明细(o, order);                 
                }
            }
            OrderDetailTableService.InsertOrderDetailTablelst(orderDetailTables);
        }
        private static void 增加单据明细(OrderDetailTable orderDetailTable, OrderTable order)
        {
            danjumingxitableService.Insertdanjumingxitable(new danjumingxitable
            {
                danhao = order.OrderNum,
                pingming = orderDetailTable.sampleName,
                Bianhao = orderDetailTable.sampleNum,
                menfu = orderDetailTable.width,
                kezhong = orderDetailTable.weight,
                chengfeng = orderDetailTable.Component,
                guige = orderDetailTable.Specifications,
                CustomerColorNum = orderDetailTable.CustomerColorNum,
                Chengpingyanse = orderDetailTable.color,
                chengpingmishu = 1,
                CustomerPingMing = orderDetailTable.CustomerPingMing,
                hanshuiheji = orderDetailTable.OtherCost,
                yanse = orderDetailTable.color
            });
        }
        private static DanjuTable CreatDanju(List < OrderDetailTable> orderDetailTables,OrderTable order )
        {
            if (orderDetailTables.Count > 0)
            {
                var orderDetailTable = orderDetailTables[0];
                return new DanjuTable { dh = orderDetailTable.OrderNum, ksbh = order.CustomerNum, ksmc = order.CustomerName, je = orderDetailTables.Sum(x=>x.OtherCost), Hanshui = order.Rax ? "含税" : "未税", Qiankuan = "欠款", djlx = DanjuLeiXing.销售订单, rq = order.Orderdate };
            }
            else
            {
                return new DanjuTable();
            }
        }
        public static void 修改(OrderTable order,List<OrderDetailTable > orderDetailTables )
        {
            if (SysInfo.GetInfo.own != "审核制")
            {
                order.state = "已审核";
            }
            //删除单据表信息   
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == order.OrderNum);
            //财务BLL.减少应收款(danju);
            //财务BLL.减少应开发票(danju);
            //来往明细BLL.删除来往记录(DanjuTableService.GetOneDanjuTable(x => x.dh == order.OrderNum));
            DanjuTableService.DeleteDanjuTable(x => x.dh == order.OrderNum);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == order.OrderNum);
            /////
            OrderTableService.UpdateOrderTable(order, x=>x.OrderNum==order.OrderNum );
            var oldDetail = OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum == order.OrderNum);
            foreach (var d in orderDetailTables )
            {
                var l = (from item in oldDetail where item.sampleNum == d.sampleNum && item.Kuanhao == d.Kuanhao && item.color == d.color select item).ToList ();
                if (l.Count >0)
                {
                    d.consignmentNum = l[0].consignmentNum;
                }
            }
            OrderDetailTableService.DeleteOrderDetailTable(x => x.OrderNum == order.OrderNum);
            if (orderDetailTables.Sum(x => x.OtherCost) > 0)
            {
                //来往明细BLL.增加来往记录(CreatDanju(orderDetailTables, order));
                DanjuTableService.InsertDanjuTable(CreatDanju(orderDetailTables, order));
                //财务BLL.增加应收款(CreatDanju(orderDetailTables, order));
                //财务BLL.增加应开发票(CreatDanju(orderDetailTables, order));
            }
            foreach (var o in orderDetailTables )
            {
                o.Shengyumishu = o.YutouMishu - o.Yitoumishu;
                OrderDetailTableService.InsertOrderDetailTable(o);
                if (o.OtherCost != 0)
                {                 
                    增加单据明细(o, order);                
                }
            }
        }
        public static bool 删除(string orderNum)
        {
            if (检查是否能删除(OrderTableService.GetOneOrderTable(x => x.OrderNum == orderNum)))
            {
                //foreach (var danju in DanjuTableService.GetDanjuTablelst(x => x.dh == orderNum))
                //{
                //    财务BLL.减少应收款(danju);
                //    财务BLL.减少应开发票(danju);
                //}
                OrderTableService.DeleteOrderTable(x => x.OrderNum == orderNum);
                OrderDetailTableService.DeleteOrderDetailTable(x => x.OrderNum == orderNum);
                //来往明细BLL.删除来往记录(DanjuTableService.GetOneDanjuTable (x=>x.dh==orderNum ));
                DanjuTableService.DeleteDanjuTable(x => x.dh == orderNum);
                danjumingxitableService.Deletedanjumingxitable(x => x.danhao == orderNum);
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool 检查是否能删除(OrderTable order )
        {
                                                                                                                                            
            //已经有费用记录的不能删除
            if (order.Cost  > 0)
            {
                return false;
            }
            return true;
        }
        public static void 增加费用(List<danjumingxitable > danjumingxitables ,DanjuTable danjuTable )
        {
            foreach(var mingxi in danjumingxitables )
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == mingxi.OrderNum);
                 if (order.OrderNum != string.Empty)
                {
                    if(danjuTable.djlx==DanjuLeiXing.销售退货单 )
                    {
                        order.Cost += 计算单米布运费(danjuTable);
                    }
                    else
                    {
                        if (danjuTable.djlx == DanjuLeiXing.采购退货单)
                        {
                            order.Cost += mingxi.hanshuiheji - 计算单米布运费(danjuTable);
                        }
                        if(danjuTable.djlx==DanjuLeiXing.销售出库单 )
                        {
                            order.Cost +=计算单米布运费(danjuTable);
                        }
                        else
                        {
                            order.Cost += mingxi.hanshuiheji + 计算单米布运费(danjuTable);
                        }
                    }
                    //order.Cost += mingxi.hanshuiheji+计算单米布运费(danjuTable );
                    OrderTableService.UpdateOrderTable(order, x => x.OrderNum == order.OrderNum);
                }
            }
        }
        public static void 增加费用(DanjuTable danjuTable)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == danjuTable.ordernum);
            if (order.OrderNum != null)
            {
                order.Cost += danjuTable.je;
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == order.OrderNum);
            }
            
        }
        public static void 减少费用(DanjuTable danjuTable)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == danjuTable.ordernum);
            if (order.OrderNum != null)
            {
                order.Cost -= danjuTable.je;
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == order.OrderNum);
            }
        }
        private static decimal 计算单米布运费(DanjuTable danjuTable )
        {
            if (danjuTable.TotalMishu != 0)
            {
                decimal yunfei = (int)((danjuTable.yunfei +danjuTable.ChaCheFei +danjuTable.ZhuangXieFei )/ danjuTable.TotalMishu);
                return yunfei;
            }
            else { return 0; }
        }
        public static void 减少费用(List<danjumingxitable > danjumingxitables,DanjuTable danjuTable  )
        {
            foreach (var mingxi in danjumingxitables)
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == mingxi.OrderNum);
                if (order.OrderNum != null)
                {
                    if(danjuTable.djlx ==DanjuLeiXing.采购退货单 )
                    {
                        order.Cost -= mingxi.hanshuiheji + 计算单米布运费(danjuTable);
                    }
                    else
                    {
                        order.Cost -= mingxi.hanshuiheji - 计算单米布运费(danjuTable);
                    }
                    OrderTableService.UpdateOrderTable($"Cost='{order.Cost }'", x => x.OrderNum == order.OrderNum);
                }
            }
        }
        //审核订单
        public static void 审核订单(string OrderNum)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
            try
            {
                order.state = "已审核";
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == OrderNum);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        public static void 反审核订单(string OrderNum)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
            try
            {
                order.state = "未审核";
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == OrderNum);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static void 增加已发货数量(List<danjumingxitable > mingxis)
        {
            try
            {
                foreach (var mingxi in mingxis)
                {
                    var orderdetail = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == mingxi.OrderNum &&
                    x.sampleNum == mingxi.Bianhao && x.color == mingxi.yanse && x.Kuanhao == mingxi.kuanhao&&x.Huahao ==mingxi.Huahao&&x.CustomerPingMing ==mingxi.CustomerPingMing &&x.CustomerColorNum ==mingxi.CustomerColorNum  );
                    if (orderdetail.sampleNum != string.Empty)
                    {
                        if (mingxi.danwei == orderdetail.danwei)
                        {
                            orderdetail.consignmentNum += mingxi.chengpingmishu;
                            orderdetail.Shengyumishu -= mingxi.chengpingmishu;
                        }
                        else
                        {
                            if(mingxi.danwei=="米" && orderdetail.danwei =="码")
                            {
                                orderdetail.consignmentNum +=( mingxi.chengpingmishu/(0.9144).TryToDecmial ());
                                orderdetail.Shengyumishu -=( mingxi.chengpingmishu/(0.9144).TryToDecmial ());
                            }
                            else
                            {
                                if (mingxi.danwei == "码" && orderdetail.danwei == "米")
                                {
                                    orderdetail.consignmentNum += (mingxi.chengpingmishu * (0.9144).TryToDecmial());
                                    orderdetail.Shengyumishu -= (mingxi.chengpingmishu *(0.9144).TryToDecmial());
                                }
                            }
                        }
                        OrderDetailTableService.UpdateOrderDetailTable($"consignmentNum='{orderdetail.consignmentNum }',Shengyumishu='{orderdetail.Shengyumishu }'", x => x.ID == orderdetail.ID);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void 减少已发货数量(List<danjumingxitable> mingxis)
        {
            try
            {
                foreach (var mingxi in mingxis)
                {
                    var orderdetail = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == mingxi.OrderNum &&
                    x.sampleNum == mingxi.Bianhao && x.color == mingxi.yanse && x.Kuanhao == mingxi.kuanhao && x.Huahao == mingxi.Huahao && x.CustomerPingMing == mingxi.CustomerPingMing && x.CustomerColorNum == mingxi.CustomerColorNum);
                    if (orderdetail.sampleNum != string.Empty)
                    {
                        if (mingxi.danwei == orderdetail.danwei)
                        {
                            orderdetail.consignmentNum -= mingxi.chengpingmishu;
                            orderdetail.Shengyumishu += mingxi.chengpingmishu;
                        }
                        else
                        {
                            if (mingxi.danwei == "米" && orderdetail.danwei == "码")
                            {
                                orderdetail.consignmentNum -= (mingxi.chengpingmishu / (0.9144).TryToDecmial());
                                orderdetail.Shengyumishu += (mingxi.chengpingmishu / (0.9144).TryToDecmial());
                            }
                            else
                            {
                                if (mingxi.danwei == "码" && orderdetail.danwei == "米")
                                {
                                    orderdetail.consignmentNum -= (mingxi.chengpingmishu * (0.9144).TryToDecmial());
                                    orderdetail.Shengyumishu += (mingxi.chengpingmishu * (0.9144).TryToDecmial());
                                }
                            }
                            //    orderdetail.consignmentNum -= mingxi.chengpingmishu;
                            //orderdetail.Shengyumishu += mingxi.chengpingmishu;
                            OrderDetailTableService.UpdateOrderDetailTable($"consignmentNum='{orderdetail.consignmentNum }',Shengyumishu='{orderdetail.Shengyumishu }'", x => x.ID == orderdetail.ID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void 增加发货金额(List<danjumingxitable> mingxis)
        {
            try
            {
                foreach (var mingxi in mingxis)
                {
                    var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == mingxi.OrderNum);
                 
                    if (order.OrderNum!= string.Empty)
                    {
                        if (mingxi.bizhong == "人民币")
                        {
                            order.FaHuoMoney += mingxi.hanshuiheji;
                        }
                        else
                        {
                            if (RateModel.CurrentRate != 0)
                            {
                                order.FaHuoMoney += mingxi.hanshuiheji * RateModel.CurrentRate;
                            }
                        }
                        OrderTableService.UpdateOrderTable (order , x => x.OrderNum == mingxi.OrderNum);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void 减少发货金额(List<danjumingxitable> mingxis)
        {
            try
            {
                foreach (var mingxi in mingxis)
                {
                    var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == mingxi.OrderNum);

                    if (order.OrderNum != string.Empty)
                    {                       
                        order.FaHuoMoney -= mingxi.hanshuiheji;                      
                        Connect.DbHelper().Updateable<OrderTable>(order).ExecuteCommand();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void 减少剩余金额(List<ProcessTable> orderTables )
        {
            foreach (var o in orderTables)
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == o.OrderNum);
                order.YifuMoney += o.TotalMoney;
                order.ShengYuMoney -= o.TotalMoney;
                order.HejiLilun = order.YifuMoney - order.Cost;
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == o.OrderNum);
            }
        }
        public static void 增加剩余金额(List<ProcessTable> orderTables)
        {
            foreach (var o in orderTables)
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == o.OrderNum);
                order.YifuMoney -= o.TotalMoney;
                order.ShengYuMoney += o.TotalMoney;
                order.HejiLilun = order.YifuMoney - order.Cost;
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == o.OrderNum);
            }
        }
        public static void 增加剩余金额(List<danjumingxitable > danjumingxitables )
        {
            foreach (var o in danjumingxitables )
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == o.OrderNum);
                order.ShengYuMoney += o.hanshuiheji ;
                order.HejiLilun = order.YifuMoney - order.Cost;
                Connect.DbHelper().Updateable(order).ExecuteCommand();
            }
        }
        public static void 减少剩余金额(List<danjumingxitable> danjumingxitables)
        {
            foreach (var o in danjumingxitables)
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == o.OrderNum);
                order.ShengYuMoney -= o.hanshuiheji;
                order.HejiLilun = order.YifuMoney - order.Cost;
                Connect.DbHelper().Updateable(order).ExecuteCommand();
            }
        }
        /// <summary>
        /// 检测该订单的货是否已经全部发完，全部发完返回true 否则返回False
        /// </summary>
        /// <param name="OrderNum">订单号</param>
        /// <returns></returns>
        public static Boolean 检查是否发完(string OrderNum)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
            if(order.state =="已完成")
            {
                return true;
            }
            var orderDetails = OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum == OrderNum && x.consignmentNum <x.Num);
            return orderDetails.Count > 0 ? false : true;
        }
        /// <summary>
        /// 改变订单的状态 让订单状态显示完成
        /// </summary>
        /// <param name="OrderNum"></param>
        public static async  void 结束订单(string OrderNum)
        {
           await Task.Run(() => { 
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
                order.state = "已完成";
                order.HejiLilun = order.FaHuoMoney - order.Deposit-order.Cost;
                OrderTableService.UpdateOrderTable($"state='已完成',HejiLilun='{order.HejiLilun }'", x => x.OrderNum == OrderNum);
                ShengChanDanTableService.UpdateShengChanDanTable("State='已结束订单'", x => x.OrderNum ==OrderNum );
                //添加工艺(OrderNum);
            });
          
        }
        /// <summary>
        /// 计算利润
        /// </summary>
        /// <param name="OrderNum"></param>
        public static async  void 计算利润(string OrderNum)
        {
            await  Task.Run (() =>
            {
                var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
                order.HejiLilun = order.FaHuoMoney - order.Deposit-order.Cost ;
                OrderTableService.UpdateOrderTable(order, x => x.OrderNum == OrderNum);
                //添加工艺(OrderNum);
            });
        }
        /// <summary>
        /// 改变订单的状态 让订单状态显示未完成
        /// </summary>
        /// <param name="OrderNum"></param>
        public static void 重启订单(string OrderNum)
        {
            var order = OrderTableService.GetOneOrderTable(x => x.OrderNum == OrderNum);
            order.state = "已审核";
            OrderTableService.UpdateOrderTable(order, x => x.OrderNum == OrderNum);
            ShengChanDanTableService.UpdateShengChanDanTable("State=''", x => x.OrderNum == OrderNum);
        }
        private static void 添加工艺(string ordernum)
        {
            var details = OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum == ordernum).Select (x=>x.sampleNum ).Distinct ().ToList ();
            foreach (var d in details )
            {
                ShengChengGongYiService.DeleteShengChengGongYi(m => m.SPBH ==d);
                var pros = ProcessTableService.GetProcessTablelst(x => x.OrderNum == ordernum && x.Documenttype != DanjuLeiXing.付款单 && x.Documenttype != DanjuLeiXing.发票开具
                && x.Documenttype != DanjuLeiXing.发票签收
                && x.Documenttype != DanjuLeiXing.发货通知单
                && x.Documenttype != DanjuLeiXing.委外加工单
                && x.Documenttype != DanjuLeiXing.采购退货单
                && x.Documenttype != DanjuLeiXing.销售退货单
                && x.Documenttype != DanjuLeiXing.销售出库单
                &&x.sampleNum==d);
                foreach (var p in pros )
                {
                    ShengChengGongYiService.InsertShengChengGongYi(new ShengChengGongYi() { SPBH = d ,JG = p.price, JGDW = p.supplierName, JGGY = p.Documenttype, JGBH = p.MachineType }) ;
                }
                dbService.Updatedb($"Update db set cbj='{pros.Sum(x=>x.price )}' where bh='{d}'");
                dbService.Updatedb($"Update db set hzljg='{pros.Where (x=>x.Documenttype !=DanjuLeiXing.采购入库单 ).ToList ().Sum(x => x.price)}' where bh='{d}'");
            }
        }
        /// <summary>
        /// 增加订单明细中的已投米数和减少订单明细的剩余米数
        /// </summary>
        /// <param name="danjumingxitable"></param>
        public static void 增加已投米数(danjumingxitable danjumingxitable )
        {
            if(string.IsNullOrEmpty(danjumingxitable.OrderNum) ==false )
            {
                var order = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == danjumingxitable.OrderNum && x.color == danjumingxitable.yanse
                 && x.Kuanhao == danjumingxitable.kuanhao && x.ColorNum == danjumingxitable.ColorNum && x.CustomerPingMing == danjumingxitable.CustomerPingMing&&x.sampleNum ==danjumingxitable.Bianhao );
                if(!string.IsNullOrEmpty(order.sampleNum ))
                {
                    order.Yitoumishu += danjumingxitable.chengpingmishu;
                    OrderDetailTableService.UpdateOrderDetailTable(order, x => x.ID==order.ID);
                }
            }
        }
        /// <summary>
        /// 减少订单明细中的已投米数和增加订单明细的剩余米数
        /// </summary>
        /// <param name="danjumingxitable"></param>
        public static void 减少已投米数(danjumingxitable danjumingxitable)
        {
            if (string.IsNullOrEmpty(danjumingxitable.OrderNum) == false)
            {
                var order = OrderDetailTableService.GetOneOrderDetailTable(x => x.OrderNum == danjumingxitable.OrderNum && x.color == danjumingxitable.yanse&&x.sampleNum==danjumingxitable.Bianhao &&x.sampleName ==danjumingxitable.pingming 
                 && x.Kuanhao == danjumingxitable.kuanhao && x.ColorNum == danjumingxitable.ColorNum && x.CustomerPingMing == danjumingxitable.CustomerPingMing);
                if (!string.IsNullOrEmpty(order.sampleNum))
                {
                    order.Yitoumishu -= danjumingxitable.chengpingmishu;
                    OrderDetailTableService.UpdateOrderDetailTable(order, x => x.OrderNum == danjumingxitable.OrderNum && x.color == danjumingxitable.yanse && x.sampleNum == danjumingxitable.Bianhao && x.sampleName == danjumingxitable.pingming
                && x.Kuanhao == danjumingxitable.kuanhao && x.ColorNum == danjumingxitable.ColorNum && x.CustomerPingMing == danjumingxitable.CustomerPingMing);
                }
            }
        }
        /// <summary>
        /// 检查订单是否存在其他费用
        /// </summary>
        /// <param name="OrderNum"></param>
        /// <returns>存在返回True 不存在返回False 没有找到订单也返回False</returns>
        public static Boolean  CheckOtherCost(string OrderNum)
        {
            if(!string.IsNullOrEmpty (OrderNum ))
            {
                var orderdetail = OrderDetailTableService.GetOrderDetailTablelst(x => x.OrderNum == OrderNum&&x.OtherCost >0);
                return orderdetail.Count > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 返回True 表示已经存在，false表示不存在
        /// </summary>
        /// <param name="Hetonghao"></param>
        /// <returns></returns>
        public static bool 检查合同号(string Hetonghao)
        {
            var orderlist = OrderTableService.GetOneOrderTable (x => x.ContractNum == Hetonghao);
            return !string.IsNullOrEmpty (orderlist.OrderNum ) ? true : false;
        }
    }
}

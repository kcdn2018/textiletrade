using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 可发卷BLL
    {
        public static void 卷出库(List<JuanHaoTable  > juanHaos )
        {
            //foreach (var j in juanHaos )
            //{
            //    var juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == j.JuanHao );
            //    juan.state = 0;
            //    JuanHaoTableService.UpdateJuanHaoTable(juan, x => x.JuanHao == juan.JuanHao);
            //}
            foreach(var j in juanHaos )
            {
                if (j.state == 0)
                {
                    JuanHaoTableService.UpdateJuanHaoTable("state='1'", x => x.Danhao == juanHaos[0].Danhao);
                }
            }
            
        }
        /// <summary>
        /// 单号
        /// </summary>
        /// <param name="Danhao"></param>
        public static void 卷入库(string Danhao)
        {          
            //foreach (var juan in juanhaos)
            //{ 
            //    juan.Danhao =string.Empty ;
                JuanHaoTableService.UpdateJuanHaoTable($"Danhao='',state='0',LogID='0'", x => x.Danhao == Danhao  );
            //}
        }
        public static void 卷新增(BindingList<JuanHaoTable > juanHaoTables )
        {
            var j = juanHaoTables[0];
            JuanHaoTableService.DeleteJuanHaoTable(x => x.OrderNum == j.OrderNum && x.SampleNum == j.SampleNum && x.GangHao == j.GangHao && x.kuanhao == j.kuanhao && x.Houzhengli == j.Houzhengli && x.yanse == j.yanse&&x.Huahao ==j.Huahao &&x.ColorNum==j.ColorNum );
            foreach(var juan in juanHaoTables )
            {
                JuanHaoTableService.InsertJuanHaoTable(juan);
            }
        }
        /// <summary>
        /// 删除卷
        /// </summary>
        /// <param name="j">卷编号</param>
        public static string  卷删除(string  j)
        {
            var juan = JuanHaoTableService.GetOneJuanHaoTable(x => x.JuanHao == j);
            var stock = StockTableService.GetOneStockTable(x => x.BH == juan.SampleNum && x.YS == juan.yanse && x.ColorNum == juan.ColorNum && x.orderNum == juan.OrderNum
            && x.kuanhao == juan.kuanhao && x.Huahao == juan.Huahao && x.houzhengli == juan.Houzhengli && x.CKMC == juan.Ckmc && x.GH == juan.GangHao);
            if (stock.BH != string.Empty)
            {
                stock.yijianmishu -= juan.biaoqianmishu;
                stock.yijianjuanshu -= 1;
                stock.biaoqianmishu -= juan.biaoqianmishu;
                StockTableService.UpdateStockTable(stock, x => x.CKMC == stock.CKMC && x.ColorNum == stock.ColorNum && x.YS == stock.YS && x.orderNum == stock.orderNum && x.BH == stock.BH && x.kuanhao == stock.kuanhao
               && x.houzhengli == stock.houzhengli && x.kuanhao == stock.kuanhao && x.Huahao == stock.Huahao && x.GH == stock.GH);
                JuanHaoTableService.DeleteJuanHaoTable(x => x.JuanHao == j);
                DeleteLogService.InsertDeleteLog(new DeleteLog()
                {
                    date = DateTime.Now,
                    useID = string.Empty,
                    Log = "删除卷" + juan.JuanHao + " 缸号为" + juan.GangHao + " 颜色为" + juan.yanse + " 长度为 " + juan.biaoqianmishu
                }) ;
                return "删除成功";
            }
            else
            {
                return "该卷对应的布料仓库中已经不存在！不能删除";
            }         
        }
       
    }
}

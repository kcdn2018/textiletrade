using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace BLL
{
 public static   class 打样单BLL
    {
        /// <summary>
        /// 保存后整理打样单
        /// </summary>
        /// <param name="danjumingxitables"></param>
        /// <param name="danjuTable"></param>
        /// <param name="houzhenglis"></param>
        public static void 保存(List<danjumingxitable > danjumingxitables , DanjuTable danjuTable, List<ShengchandanHouzhengli> houzhenglis)
        {
            danjuTable.dh = 单据BLL.检查单号(danjuTable.dh);
            foreach (var c in danjumingxitables)
            {
                c.danhao = danjuTable.dh;
                danjumingxitableService.Insertdanjumingxitable (c);
            }
            DanjuTableService.InsertDanjuTable(danjuTable);
            foreach (var h in houzhenglis)
            {
                h.shengchandanhao = danjuTable.dh;
            }
            ShengchandanHouzhengliService.InsertShengchandanHouzhenglilst(houzhenglis);
            财务BLL.增加应收发票(danjuTable);
            财务BLL.增加应付款(danjuTable);
            来往明细BLL.增加来往记录(danjuTable);
            //danjuTable.ksbh = danjuTable.wuliuBianhao;
            //danjuTable.ksmc = danjuTable.SaleMan;
            //来往明细BLL.增加来往记录(danjuTable);
            //财务BLL.增加应收款(danjuTable);
            //财务BLL.增加应开发票(danjuTable);

        }
        /// <summary>
        /// 打样指示单
        /// </summary>
        /// <param name="colorTables"></param>
        /// <param name="danjuTable"></param>
        /// <param name="houzhenglis"></param>
        /// <param name="yaoqius"></param>
        public static void 保存(List<ShengchandanSeLaodu> colorTables ,DanjuTable danjuTable ,List<ShengchandanHouzhengli > houzhenglis ,List<ShengChanDanHouZhengLiYaoQiu > yaoqius)
        {
            danjuTable.dh = 单据BLL.检查单号(danjuTable .dh);
            foreach (var c in colorTables )
            {
                c.shengchandanhao = danjuTable.dh;
                ShengchandanSeLaoduService.InsertShengchandanSeLaodu (c);
            }
            DanjuTableService.InsertDanjuTable(danjuTable);
            foreach (var h in houzhenglis )
            {
                h.shengchandanhao = danjuTable.dh;
            }
            ShengchandanHouzhengliService.InsertShengchandanHouzhenglilst(houzhenglis);
            foreach(var y in yaoqius )
            {
                y.ShengChanDanHao = danjuTable.dh;
            }
            ShengChanDanHouZhengLiYaoQiuService.InsertShengChanDanHouZhengLiYaoQiulst (yaoqius);
            if(danjuTable.ordernum !="")
            {     
                 订单BLL.增加费用(danjuTable);
                订单进度BLL.新增进度(danjuTable);
            }
            财务BLL.增加应收发票(danjuTable);
            财务BLL.增加应付款(danjuTable);
            if (danjuTable.je > 0)
            {
                来往明细BLL.增加来往记录(danjuTable);
            }
            //danjuTable.ksbh = danjuTable.wuliuBianhao;
            //danjuTable.ksmc = danjuTable.SaleMan;
            //来往明细BLL.增加来往记录(danjuTable);
            //财务BLL.增加应收款(danjuTable);
            //财务BLL.增加应开发票(danjuTable);
         
        }
        /// <summary>
        /// 修改打样指示单
        /// </summary>
        /// <param name="colorTables"></param>
        /// <param name="danjuTable"></param>
        /// <param name="houzhenglis"></param>
        /// <param name="yaoqius"></param>
        public static void 修改(List<ShengchandanSeLaodu> colorTables, DanjuTable danjuTable, List<ShengchandanHouzhengli> houzhenglis, List<ShengChanDanHouZhengLiYaoQiu> yaoqius)
        {
            ShengchandanSeLaoduService .DeleteShengchandanSeLaodu(x => x.shengchandanhao  == danjuTable.dh);
            //减少费用
            var olddanju = DanjuTableService.GetOneDanjuTable(x => x.dh == danjuTable.dh);
            if(olddanju.ordernum!="")
            {          
                    订单BLL.减少费用(olddanju );                
            }
            财务BLL.减少应收发票 (olddanju );
            财务BLL.减少应付款 (olddanju );
            来往明细BLL.删除来往记录 (olddanju );
            //删除进度
            订单进度BLL.删除进度(danjuTable.dh);
            DanjuTableService.UpdateDanjuTable(danjuTable, x => x.dh == danjuTable.dh );         
            ShengchandanHouzhengliService.DeleteShengchandanHouzhengli(x => x.shengchandanhao == danjuTable.dh);
            ShengChanDanHouZhengLiYaoQiuService.DeleteShengChanDanHouZhengLiYaoQiu(x => x.ShengChanDanHao == danjuTable.dh);
            ///重新添加
            foreach (var c in colorTables)
            {
                ShengchandanSeLaoduService.InsertShengchandanSeLaodu (c);
            }
            ShengchandanHouzhengliService.InsertShengchandanHouzhenglilst(houzhenglis);
            ShengChanDanHouZhengLiYaoQiuService.InsertShengChanDanHouZhengLiYaoQiulst(yaoqius);
            if (danjuTable.ordernum != "")
            {
                订单BLL.增加费用(danjuTable);
                订单进度BLL.新增进度(danjuTable);
            }
            财务BLL.增加应收发票(danjuTable);
            财务BLL.增加应付款(danjuTable);
            来往明细BLL.增加来往记录(danjuTable);
            /////////处理客户部分
            //olddanju .ksbh = olddanju .wuliuBianhao;
            //olddanju.ksmc = olddanju .SaleMan;
            //财务BLL.减少应收款(olddanju );
            //财务BLL.减少应开发票(olddanju );
            //danjuTable.ksbh = danjuTable.wuliuBianhao;
            //danjuTable.ksmc = danjuTable.SaleMan;
            //danjuTable.djlx = danjuTable.jiagongleixing;
            //财务BLL.增加应收款(danjuTable);
            //财务BLL.增加应开发票(danjuTable);
            //来往明细BLL.增加来往记录(danjuTable  );
        }
        /// <summary>
        /// 修改后整理打样单
        /// </summary>
        /// <param name="danjumingxitables"></param>
        /// <param name="danjuTable"></param>
        /// <param name="houzhenglis"></param>
        public static void 修改(List<danjumingxitable > danjumingxitables, DanjuTable danjuTable, List<ShengchandanHouzhengli> houzhenglis)
        {
            ShengchandanSeLaoduService.DeleteShengchandanSeLaodu(x => x.shengchandanhao == danjuTable.dh);
            //减少费用
            var olddanju = DanjuTableService.GetOneDanjuTable(x => x.dh == danjuTable.dh);
            财务BLL.减少应收发票(olddanju);
            财务BLL.减少应付款(olddanju);
            来往明细BLL.删除来往记录(olddanju);
           
            DanjuTableService.UpdateDanjuTable(danjuTable, x => x.dh == danjuTable.dh);
            ShengchandanHouzhengliService.DeleteShengchandanHouzhengli(x => x.shengchandanhao == danjuTable.dh);
            ShengChanDanHouZhengLiYaoQiuService.DeleteShengChanDanHouZhengLiYaoQiu(x => x.ShengChanDanHao == danjuTable.dh);
            ///重新添加
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danjuTable.dh);
            foreach (var c in danjumingxitables )
            {
                danjumingxitableService.Insertdanjumingxitable (c);
            }
            ShengchandanHouzhengliService.InsertShengchandanHouzhenglilst(houzhenglis);
            财务BLL.增加应收发票(danjuTable);
            财务BLL.增加应付款(danjuTable);
            来往明细BLL.增加来往记录(danjuTable);
           
        }
        public static void 删除(string danhao)
        {
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            //减少费用
            var olddanju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao );
            if (olddanju.ordernum != "")
            {
                订单BLL.减少费用(olddanju);
                //删除进度
                订单进度BLL.删除进度(danhao );
            }
            ColorTableService.DeleteColorTable(x => x.ColorNum == danhao);
            DanjuTableService.DeleteDanjuTable( x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            ShengchandanHouzhengliService.DeleteShengchandanHouzhengli(x => x.shengchandanhao == danhao);
            ShengChanDanHouZhengLiYaoQiuService.DeleteShengChanDanHouZhengLiYaoQiu(x => x.ShengChanDanHao == danhao);
            财务BLL.减少应收发票(olddanju);
            财务BLL.减少应付款(olddanju);
            来往明细BLL.删除来往记录(olddanju );
            /////////////处理客户部分
            //olddanju.ksbh = olddanju.wuliuBianhao;
            //olddanju.ksmc = olddanju.SaleMan;
            //财务BLL.减少应收款(olddanju );
            //财务BLL.减少应开发票(olddanju );
        }
      
    }
}

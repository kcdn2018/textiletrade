using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 委外取货单BLL
    {
        public static  void 保存单据(DanjuTable danju,List<danjumingxitable > danjumingxitables ,List <RangShequpiTable> rangsetoupiTables)
        {
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            var gonghuoshang = LXRService.GetOneLXR(x=>x.MC ==danju.ksmc).Leixing ;
            foreach (var d in danjumingxitables.Where(x=>x.Bianhao!=null).ToList ())
            {
                d.danhao = danju.dh;
                if (gonghuoshang == Gonhuoshang.染厂)
                {
                    d.Rangchang = danju.ksmc;
                }
            }
           danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());
            foreach (var j in rangsetoupiTables)
            {
                j.DocumentNum = danju.dh;
            } 
            RangShequpiTableService .InsertRangShequpiTablelst (rangsetoupiTables);    
            ///保存生产工艺信息
            var gongyi = ShengchandanGongyiService.GetOneShengchandanGongyi(x => x.gongyimingcheng == danju.jiagongleixing);
            if(gongyi.gongyimingcheng==string.Empty )
            {
                ShengchandanGongyiService.InsertShengchandanGongyi(new ShengchandanGongyi() { gongyimingcheng = danju.jiagongleixing, shengchandanhao=danju.dh , value =true });
            }
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }
            else
            {
                单据审核(danju.dh);
            }
            
        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables, List<RangShequpiTable> rangsetoupiTables)
        {
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danju.dh);
                }
            }
            else
            {
                单据反审核(danju.dh);
            }
            Thread.Sleep(200);
            DanjuTableService.UpdateDanjuTable (danju,x=>x.dh==danju.dh );
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            RangShequpiTableService.DeleteRangShequpiTable(x => x.DocumentNum == danju.dh);
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());
             RangShequpiTableService.InsertRangShequpiTablelst(rangsetoupiTables);
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }
            
        }
        public static List<string> 获取加工类型()
        {
           return ShengchandanGongyiService.GetShengchandanGongyilst().Select(x=>x.gongyimingcheng ).ToList ();
        }
        public static async  void  单据审核(string danhao)
        {
            await Task.Run(() => { 
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                var qupilist = RangShequpiTableService.GetRangShequpiTablelst(x => x.DocumentNum == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);
                来往明细BLL.增加来往记录(danju);
                财务BLL.增加应付款(danju);
                财务BLL.增加应收发票(danju);
                订单BLL.增加费用(danjumingxitables, danju);
                库存BLL.增加库存(danjumingxitables, danju);
                单据BLL.审核(danhao);
                订单进度BLL.新增进度(danjumingxitables, danju);
                danju.ckmc = danju.ksmc;
                库存BLL.减少库存(qupilist, danju);
            });
        }
        public static  async void 单据反审核(string danhao)
        {        
            await Task.Run(() => {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                var qupilist = RangShequpiTableService.GetRangShequpiTablelst(x => x.DocumentNum == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
                来往明细BLL.删除来往记录(danju);
                财务BLL.减少应付款(danju);
                财务BLL.减少应收发票(danju);
                订单BLL.减少费用(danjumingxitables, danju);
                库存BLL.减少库存(danjumingxitables, danju);
                单据BLL.未审核(danhao);
                danju.ckmc = danju.ksmc;
                库存BLL.增加库存(qupilist, danju);
                订单进度BLL.删除进度(danju.dh);
            });
        }
        public static void 删除单据(string danhao)
        {
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao);
                }
            }
            else
            {
                单据反审核(danhao);
            }
            Thread.Sleep(200);
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            RangShequpiTableService.DeleteRangShequpiTable(x => x.DocumentNum == danhao);
        }
    }
}

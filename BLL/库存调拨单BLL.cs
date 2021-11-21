using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 库存调拨单BLL
    {
        public static void 保存单据(DanjuTable danju,List<danjumingxitable > danjumingxitables,List<JuanHaoTable >juanHaos )
        {
            if (SysInfo.GetInfo.own != "审核制")
            {
                danju.zhuangtai = "已审核";
            }
            else
            {
                danju.zhuangtai = "未审核";
            }
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            foreach (var d in danjumingxitables.Where(x=>x.Bianhao!=null).ToList ())
            {
                d.danhao = danju.dh;
            }
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            JuanHaoTableService.UpdateJuanHaoTableList(x=>x.Ckmc==danju.shouhuodizhi , juanHaos );
            if (SysInfo.GetInfo.own != string.Empty )
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
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables,List<JuanHaoTable >juanHaos )
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
            System.Threading.Thread.Sleep(500);
            DanjuTableService.UpdateDanjuTable (danju,x=>x.dh==danju.dh );
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            RangShequpiTableService.DeleteRangShequpiTable(x => x.DocumentNum == danju.dh);
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }           
        }
     
        public static async  void 单据审核(string danhao)
        {
            await Task.Run (() => { 
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao); 
            DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);       
            库存BLL.增加库存(danjumingxitables, danju);
            单据BLL.审核(danhao);         
            订单进度BLL.新增进度(danjumingxitables, danju);
            danju.ckmc = danju.ksmc;
            库存BLL.减少库存(danjumingxitables , danju);
            });
        }
        public static async  void 单据反审核(string danhao)
        {
            await Task.Run (()=>
            {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                danju.zhuangtai = "未审核";
                DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danhao);
                库存BLL.减少库存(danjumingxitables, danju);
                单据BLL.未审核(danhao);
                danju.ckmc = danju.ksmc;
                库存BLL.增加库存(danjumingxitables, danju);
                订单进度BLL.删除进度(danju.dh);
            });
        }
        public static void 删除单据(string danhao)
        {
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao );
                }
            }
            else
            {
                单据反审核(danhao );
            }
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            RangShequpiTableService.DeleteRangShequpiTable(x => x.DocumentNum == danhao);
        }
    }
}

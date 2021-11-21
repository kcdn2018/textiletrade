using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 盘盈入库单BLL
    {
        public static void 保存单据(DanjuTable danju,List <danjumingxitable > danjumingxitables )
        {
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            foreach (var m in danjumingxitables.Where(x =>!string.IsNullOrWhiteSpace(x.Bianhao )).ToList())
            {
                m.danhao = danju.dh;    
            }   
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x=>!string.IsNullOrWhiteSpace(x.Bianhao)).ToList());       
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
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
        {
            if (SysInfo.GetInfo.own != string.Empty )
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
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh); 
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());         
            if (SysInfo.GetInfo.own != string.Empty )
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }             
        }
        public static void 删除单据(string danhao)
        {
            if (SysInfo.GetInfo.own != string.Empty )
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao);
                }
            }
            Thread.Sleep(500);
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
        }
        public static   void 单据审核(string danhao)
        {
 
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);
                库存BLL.增加库存(danjumingxitables, danju); 
        }
        public static   void 单据反审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
                库存BLL.减少库存(danjumingxitables, danju); 
        }
    }
}

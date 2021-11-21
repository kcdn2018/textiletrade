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
   public static  class 销售退货单BLL
    {
        public static void 保存单据(DanjuTable danju,List <danjumingxitable > danjumingxitables )
        {
            
                danju.dh = 单据BLL.检查单号(danju.dh);
                danju.je = 0 - danju.je;
                DanjuTableService.InsertDanjuTable(danju);            
                foreach (var m in danjumingxitables.Where(x => x.Bianhao != null).ToList())
                {
                    m.danhao = danju.dh;
                    m.chengpingmishu = 0 - m.chengpingmishu;
                    m.chengpingjuanshu = 0 - m.chengpingjuanshu;
                    m.hanshuidanjia = 0 - m.hanshuidanjia;
                    m.hanshuiheji = 0 - m.hanshuiheji;
                }
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => x.Bianhao != null).ToList());
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
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
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
            danju.je = 0 - danju.je;
            foreach (var m in danjumingxitables.Where(x => x.Bianhao != null).ToList())
            {
                m.danhao = danju.dh;
                m.chengpingmishu = 0 - m.chengpingmishu;
                m.chengpingjuanshu = 0 - m.chengpingjuanshu;
                m.hanshuidanjia = 0 - m.hanshuidanjia;
                m.hanshuiheji = 0 - m.hanshuiheji;              
            }
            DanjuTableService.UpdateDanjuTable (danju,x=>x.dh==danju.dh );
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            danjumingxitableService.Insertdanjumingxitablelst (danjumingxitables.Where(x => x.Bianhao != null).ToList());
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }
            
        }
        public static void 删除单据(string danhao)
        {
            销售发货单BLL.删除单据(danhao);
        }
        public static void 单据审核(string danhao)
        {
            销售发货单BLL.单据审核(danhao);   
        }
        public static void 单据反审核(string danhao)
        {
            销售发货单BLL.单据反审核(danhao);
        } 
    }
}

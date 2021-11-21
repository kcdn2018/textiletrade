using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 委外发货单BLL
    {
        public static void 保存单据(DanjuTable danju,List<danjumingxitable > danjumingxitables ,List <JuanHaoTable > juanHaoTables)
        {
            if(SysInfo.GetInfo.own !="审核制")
            {
                danju.zhuangtai = "已审核";
            }
            else
            {
                danju.zhuangtai = "未审核";
            }
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            foreach (var d in danjumingxitables.Where(x=>!string.IsNullOrEmpty ( x.Bianhao)).ToList ())
            {
                d.danhao = danju.dh;          
            }
             danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            ///保存卷号
            List<FahuoDan> fahuoDans = new List<FahuoDan>();
            foreach (var j in juanHaoTables)
            {
                fahuoDans.Add(new FahuoDan()
                {
                    bh = j.SampleNum,
                    pm = j.SampleName,
                    GG = j.guige,
                    gh = j.GangHao,
                    ys = j.yanse,
                    jh = j.JuanHao,
                    mis = j.biaoqianmishu.ToString(),
                    color = j.yanse,
                    Gangjuanhao = j.PiHao.ToString(),
                    dh = danju.dh,
                    rq = danju.rq,
                });
                j.Danhao = danju.dh;
                if (j.state == 0)
                {
                    j.state = 1;
                }
            }
            Connect.DbHelper().Updateable(juanHaoTables).ExecuteCommand();
            FahuoDanService.InsertFahuoDanlst(fahuoDans);
            if (SysInfo.GetInfo.own!="审核制")
            {
                审核(danju.dh);
            }
            
        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables, List<JuanHaoTable> juanHaoTables)
        {
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    反审核(danju.dh);
                }
            }
            Thread.Sleep(200);
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
           danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables.Where(x => !string.IsNullOrEmpty(x.Bianhao)).ToList());
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    审核(danju.dh);
                }
            }
            //处理卷号
            List<FahuoDan> fahuoDans = new List<FahuoDan>();
            foreach (var j in juanHaoTables)
            {
                fahuoDans.Add(new FahuoDan()
                {
                    bh = j.SampleNum,
                    pm = j.SampleName,
                    GG = j.guige,
                    gh = j.GangHao,
                    ys = j.yanse,
                    jh = j.JuanHao,
                    mis = j.biaoqianmishu.ToString(),
                    color = j.yanse,
                    Gangjuanhao = j.PiHao.ToString(),
                    dh = danju.dh,
                    rq = danju.rq,
                });
                j.Danhao = danju.dh;
                if (j.state == 0)
                {
                    j.state = 1;
                }
            }
            Connect.DbHelper().Updateable(juanHaoTables).ExecuteCommand();
            FahuoDanService.InsertFahuoDanlst(fahuoDans);
            
        }
        public static void 删除单据(string danhao)
        {
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    反审核(danhao);
                }
            }
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
        }
        public static async void 审核(string danhao)
        {
            await Task.Run(() => {
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxis = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='已审核'", x => x.dh == danhao);
                订单BLL.增加费用(danjumingxis, danju);
                订单进度BLL.新增进度(danjumingxis, danju);
                库存BLL.减少库存(danjumingxis, danju);
                danju.ckmc = danju.ksmc;
                库存BLL.增加库存(danjumingxis, danju); 
            });
        }
        public static async void 反审核(string danhao)
        {
            await Task.Run(() => { 
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxis = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
                订单BLL.减少费用(danjumingxis, danju);
                订单进度BLL.删除进度(danhao);
                库存BLL.增加库存(danjumingxis, danju);
                danju.ckmc = danju.ksmc;
                库存BLL.减少库存(danjumingxis, danju);
                可发卷BLL.卷入库(danhao);
            });
        }
    }
}

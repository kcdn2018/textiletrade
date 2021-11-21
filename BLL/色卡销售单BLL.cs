using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
    public static class 色卡销售单BLL
    {
        public static void 保存单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
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
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null).ToList())
            {
                d.danhao = danju.dh;
                danjumingxitableService.Insertdanjumingxitable(d);
            }

            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据审核(danju.dh);
                }
            }

        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
        {

            //删除信息
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danju.dh);
                }
            }
            Thread.Sleep(500);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            FahuoDanService.DeleteFahuoDan(x => x.dh == danju.dh);
            //var juans = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == danju.dh);
            //foreach (var juan in juans)
            //{
            //    juan.Danhao = "";
            //    juan.state = 0;
            //    JuanHaoTableService.UpdateJuanHaoTable(juan, x => x.JuanHao == juan.JuanHao);
            //}
            //清除卷号状态
            JuanHaoTableService.UpdateJuanHaoTable($"state='0',Danhao=''", x => x.Danhao == danju.dh);
            // 
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            foreach (var d in danjumingxitables.Where(x => x.Bianhao != null).ToList())
            {
                danjumingxitableService.Insertdanjumingxitable(d);
            }
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
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own != "审核制")
                {
                    单据反审核(danhao);
                }
            }
            Thread.Sleep(500);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
            FahuoDanService.DeleteFahuoDan(x => x.dh == danhao);
            //清除卷号状态
            JuanHaoTableService.UpdateJuanHaoTable($"state='0',Danhao=''", x => x.Danhao ==danhao );
            //var juans = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == danhao);
            //foreach (var juan in juans)
            //{
            //    juan.Danhao = "";
            //    juan.state = 0;
            //    JuanHaoTableService.UpdateJuanHaoTable(juan, x => x.JuanHao == juan.JuanHao);
            //}
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);

        }
        public static List<danjumingxitable> GetFahuodanMingxi(string danhao)
        {
            return danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
        }
        public static string 单据审核(string danhao)
        {
            
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            if (财务BLL.查询额度(danju.ksbh, danju.je) == false)
            {
                return "剩余额度不足";
            }
      
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                danju.zhuangtai = "已审核";
                var juanhaos = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == danhao);
                DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danhao);
                来往明细BLL.增加来往记录(danju);
                财务BLL.增加应收款(danju);
                财务BLL.增加应开发票(danju);
                订单BLL.增加费用(danjumingxitables, danju);
                库存BLL.减少库存(danjumingxitables, danju);
                单据BLL.审核(danhao);
                订单进度BLL.新增进度(danjumingxitables, danju);
                订单BLL.增加已发货数量(danjumingxitables);
                订单BLL.增加发货金额(danjumingxitables);
                订单BLL.增加剩余金额(danjumingxitables);
                财务BLL.减少剩余额度(danju.ksbh, danju.je);
         
            return "审核成功";

        }
        public static void 单据反审核(string danhao)
        {           
                var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                var danjumingxitables = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danhao);
                danju.zhuangtai = "未审核";
                var juanhaos = JuanHaoTableService.GetJuanHaoTablelst(x => x.Danhao == danhao);
                DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danhao);
                来往明细BLL.删除来往记录(danju);
                财务BLL.减少应收款(danju);
                财务BLL.减少应开发票(danju);
                订单BLL.减少费用(danjumingxitables, danju);
                库存BLL.增加库存(danjumingxitables, danju);
                单据BLL.未审核(danhao);
                订单进度BLL.删除进度(danju.dh);
                订单BLL.减少已发货数量(danjumingxitables);
                订单BLL.减少发货金额(danjumingxitables);
                订单BLL.减少剩余金额(danjumingxitables);
                财务BLL.增加剩余额度(danju.ksbh, danju.je);
        }
    }
}

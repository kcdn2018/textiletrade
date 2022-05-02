using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using 纺织贸易管理系统;

namespace BLL
{
    public static class 单据BLL
    {
        /// <summary>
        /// 检查这个单号是否已经审核 
        /// </summary>
        /// <param name="danhao"></param>
        /// <returns></returns>
        public static Boolean 检查是否已经审核(string danhao)
        {
            if (SysInfo.GetInfo.own != string.Empty)
            {
                if (SysInfo.GetInfo.own == "审核制")
                {
                    var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
                    if (danju.zhuangtai == "已审核")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void 审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            if (danju.djlx == DanjuLeiXing.打样工艺单)
            {
                DanjuTableService.UpdateDanjuTable($"zhuangtai='已审核',remarker='{ DateTime.Now.ToShortDateString()}'", x => x.dh == danhao);
            }
            else
            {
                DanjuTableService.UpdateDanjuTable($"zhuangtai='已审核'", x => x.dh == danhao);
            }
        }
        public static void 未审核(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            if (danju.djlx == DanjuLeiXing.打样工艺单)
            {
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核',remarker=''", x => x.dh == danhao);
            }
            else
            {
                DanjuTableService.UpdateDanjuTable("zhuangtai='未审核'", x => x.dh == danhao);
            }
        }
        public static void 单据保存(DanjuTable danju, List<danjumingxitable> danjumingxitables)
        {
            danju.dh = 单据BLL.检查单号(danju.dh );
            DanjuTableService.InsertDanjuTable(danju);
            foreach (var d in danjumingxitables )
            { d.danhao = danju.dh; }
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables);
        }
        public static void 删除单据(string danhao)
        {
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danhao);
        }
        public static void 修改单据(DanjuTable danju, List<danjumingxitable> danjumingxitables)
        {
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            danjumingxitableService.Deletedanjumingxitable(x => x.danhao == danju.dh);
            danjumingxitableService.Insertdanjumingxitablelst(danjumingxitables);
        }
        public static string 检查单号(string danhao)
        {
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            if (danju.dh == string.Empty)
            {
                return danhao;
            }
            else
            {
                if (QueryTime.DanjubianhaoRule == "类型+年份+月份+日+累计编号")
                {
                    var newdanhao = danhao.Substring(0, danhao.Length - 3) + (Convert.ToInt32(danhao.Substring(danhao.Length - 3, 3)) + 1).ToString();
                    while (DanjuTableService.GetDanjuTablelst(x => x.dh == newdanhao).Count > 0)
                    {
                        newdanhao = newdanhao.Substring(0, newdanhao.Length - 3) + (Convert.ToInt32(newdanhao.Substring(newdanhao.Length - 3, 3)) + 1).ToString();
                    }
                    return newdanhao;
                }
                else
                {
                    var newdanhao = danhao.Substring(0, danhao.Length - 5) +string.Format ("{0:00000}", (Convert.ToInt32(danhao.Substring(danhao.Length - 5, 5)) + 1));
                    while (DanjuTableService.GetDanjuTablelst(x => x.dh == newdanhao).Count > 0)
                    {
                        newdanhao = newdanhao .Substring(0, newdanhao .Length - 5) + string.Format("{0:00000}", (Convert.ToInt32(newdanhao .Substring(newdanhao .Length - 5, 5)) + 1));
                    }
                    return newdanhao;
                }
            }
        }
        public static string 检查生产单号(string danhao)
        {
            var danju = ShengChanDanTableService .GetOneShengChanDanTable (x => x.shengchandanhao  == danhao);
            if (danju.shengchandanhao  == string.Empty)
            {
                return danhao;
            }
            else
            {
                if (QueryTime.DanjubianhaoRule == "类型+年份+月份+日+累计编号")
                {
                    var newdanhao = danhao.Substring(0, danhao.Length - 3) + (Convert.ToInt32(danhao.Substring(danhao.Length - 3, 3)) + 1).ToString();
                    while (ShengChanDanTableService.GetShengChanDanTablelst(x => x.shengchandanhao == newdanhao).Count > 0)
                    {
                        newdanhao = newdanhao.Substring(0, newdanhao.Length - 3) + (Convert.ToInt32(newdanhao.Substring(newdanhao.Length - 3, 3)) + 1).ToString();
                    }
                    return newdanhao;
                }
                else
                {
                    var newdanhao = danhao.Substring(0, danhao.Length - 5) + string.Format("{0:00000}", (Convert.ToInt32(danhao.Substring(danhao.Length - 5, 5)) + 1));
                    while (ShengChanDanTableService.GetShengChanDanTablelst(x => x.shengchandanhao == newdanhao).Count > 0)
                    {
                        newdanhao = danhao.Substring(0, danhao.Length - 5) + string.Format("{0:00000}", (Convert.ToInt32(newdanhao .Substring(newdanhao .Length - 5, 5)) + 1));
                    }
                    return newdanhao;
                }
            }
        }
    }
}

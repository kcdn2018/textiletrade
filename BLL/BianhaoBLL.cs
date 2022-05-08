using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Tools;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class BianhaoBLL
    {
        /// <summary>
        /// 创建用户编号
        /// </summary>
        /// <returns></returns>
        public static string CreatYonghuBianhao()
        {
            var dt =SQLHelper.SQLHelper .Chaxun($"select * from yhb order by yhBH desc");
            if (dt.Rows.Count == 0)
            {
                return  "10001";
            }
            else
            {
                var bh = dt.Rows[0]["yhBH"].ToString();              
                bh = (Convert.ToInt32(bh) + 1).ToString();
                return   bh;
            }
        }
        /// <summary>
        /// 创建联系人编号
        /// </summary>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        public static string CreatBianhao(string firstLetter)
        {
            var dt = SQLHelper.SQLHelper.Chaxun($"select BH from lxr where bh like '{firstLetter}%'order by BH desc");
            if (dt.Rows.Count == 0)
            {
                return firstLetter + "100001";
            }
            else
            {
                var bh = dt.Rows[0]["BH"].ToString();
                bh = bh.Substring(bh.Length - 4);
                bh = (Convert.ToInt32(bh) + 100001).ToString();
                return firstLetter + bh;
            }
        }
        /// <summary>
        /// 创建新的员工编号
        /// </summary>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        public static string CreatYuangongBianhao(string firstLetter)
        {
            var dt = SQLHelper.SQLHelper.Chaxun("select bianhao from yuangongtable order by bianhao desc");
            if (dt.Rows.Count == 0)
            {
                return firstLetter + "100001";
            }
            else
            {
                var bh = dt.Rows[0]["bianhao"].ToString();
                bh = bh.Substring(bh.Length - 2);
                bh = (Convert.ToInt32(bh) + 100001).ToString();
                return firstLetter + bh;
            }
        }
        /// <summary>
        /// 创建仓库编号
        /// </summary>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        public static string CreatStockBianhao(string firstLetter)
        {
            var dt = SQLHelper.SQLHelper.Chaxun($"select bianhao from StockInfoTable order by bianhao desc");
            if (dt.Rows.Count == 0)
            {
                return firstLetter + "100001";
            }
            else
            {
                var bh = dt.Rows[0]["bianhao"].ToString();
                bh = bh.Substring(bh.Length - 2);
                bh = (Convert.ToInt32(bh) + 100001).ToString();
                return firstLetter + bh;
            }
        }
        /// <summary>
        /// 创建品种编号
        /// </summary>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        public static string CreatPingZhongBianhao(string firstLetter, string pingming, string houzhengli)
        {
            if (SettingService.GetSetting(new Model.Setting() { formname = "", settingname = "样布编号", settingValue = "" }).settingValue == "区分后整")
            {
                var year = DateTime.Now.Year;
                firstLetter += year.ToString().Substring(2, 2);
                if (string.IsNullOrEmpty(pingming))
                {
                    var dt2 = SQLHelper.SQLHelper.Chaxun($"select bh from db order by bh desc ");
                    if (dt2.Rows.Count > 0)
                    {
                        var b = dt2.Rows[0]["bh"].ToString();
                        b = b.Substring(firstLetter.Length, b.Length - firstLetter.Length);
                        b = b.Split('-')[0];
                        return firstLetter + (Convert.ToInt32(b) + 1).ToString();
                    }
                    else
                    { return firstLetter + "1001"; }
                }
                try
                {
                    var dt = SQLHelper.SQLHelper.Chaxun($"select bh from db where pm='{pingming}' order by bh desc");
                    if (dt.Rows.Count == 0)
                    {
                        var dt2 = SQLHelper.SQLHelper.Chaxun($"select bh from db order by bh desc ");
                        if (dt2.Rows.Count > 0)
                        {
                            var b = dt2.Rows[0]["bh"].ToString();
                            b = b.Substring(firstLetter.Length, b.Length - firstLetter.Length);
                            b = b.Split('-')[0];
                            b = (Convert.ToInt32(b) + 1).ToString();
                            switch (b.Length)
                            {
                                case 1:
                                    b = "00" + b;
                                    break;
                                case 2:
                                    b = "0" + b;
                                    break;
                            }
                            return firstLetter + b;
                        }
                        else
                        { return firstLetter + "001"; }
                    }
                    else
                    {
                        var bh = dt.Rows[0]["bh"].ToString();
                        var pmbh = bh.Split('-')[0];
                        if (pmbh.Length >= firstLetter.Length)
                        {
                            pmbh = pmbh.Substring(firstLetter.Length, pmbh.Length -firstLetter .Length );
                            if (bh.Split('-').Length == 2)
                            {
                                bh = pmbh + "-" + (Convert.ToUInt16(bh.Split('-')[1]) + 1).ToString();
                            }
                            else
                            {
                                bh = pmbh + "-1";
                            }
                        }
                        return firstLetter + bh;
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                var dt2 = SQLHelper.SQLHelper.Chaxun($"select bh from db order by id desc ");
                if (dt2.Rows.Count > 0)
                {
                    try
                    {
                        var b = dt2.Rows[0]["bh"].ToString();
                        b = b.Substring(firstLetter.Length, b.Length - firstLetter.Length);
                        b = b.Split('-')[0];
                        return firstLetter + string.Format("{0:000000}", (Convert.ToInt32(b) + 1));
                    }
                    catch
                    {
                        var b = dt2.Rows[0]["id"].TryToInt();
                        //b = b.Substring(firstLetter.Length, b.Length - firstLetter.Length);
                        //b = b.Split('-')[0];
                        return firstLetter + string.Format("{0:00000}", (Convert.ToInt32(b) + 1));
                    }
                }
                else
                { return firstLetter + "000001"; }
            }
        }
        /// <summary>
        /// 生产单号
        /// </summary>
        /// <param name="danjuleixing"></param>
        /// <param name="dateTime"></param>
        /// <param name="lx"></param>
        /// <returns></returns>
        public static string CreatShengchangDanhao(string danjuleixing, DateTime dateTime, string lx)
        {
            if (QueryTime.DanjubianhaoRule == "类型+年份+月份+日+累计编号")
            {
                var list = ShengChanDanTableService.GetShengChanDanTablelst(x => x.riqi == dateTime.Date).OrderBy(x => x.shengchandanhao).ToList();
                if (list.Count > 0)
                {
                    var bh = (int.Parse(list[list.Count - 1].shengchandanhao.Substring(list[list.Count - 1].shengchandanhao.Length - 3, 3)) + 1);
                    return danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + bh.ToString();
                }
                else
                {
                    return danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + "101";
                }
            }
            else
            {
                var date = new DateTime(DateTime.Now.Year ,1,1) ;
                var list = ShengChanDanTableService.GetShengChanDanTablelst(x => x.riqi >= date.Date ).OrderByDescending (x => x.ID   ).ToList();
                if(list.Count ==0)
                {
                    return danjuleixing + date.Year.ToString() + "00001";
                }
                else
                {
                    var newdanhao = danjuleixing + date.Year.ToString() +string.Format ("{0:00000}",int.Parse ( list [0].shengchandanhao.Substring (list[0].shengchandanhao.Length -5,5))+1);
                    while (ShengChanDanTableService.GetShengChanDanTablelst(x => x.shengchandanhao == newdanhao).Count > 0)
                    {
                        newdanhao = newdanhao.Substring(0, newdanhao.Length - 5) + string.Format("{0:00000}", (Convert.ToInt32(newdanhao.Substring(newdanhao.Length - 5, 5)) + 1));
                    }
                    return newdanhao;
                }
            }
        }
        /// <summary>
        /// 创建单号
        /// </summary>
        /// <param name="danjuleixing"></param>
        /// <returns></returns>
        public static string CreatDanhao(string danjuleixing,DateTime dateTime ,string lx)
        {
            if (QueryTime.DanjubianhaoRule == "类型+年份+月份+日+累计编号")
            {
                var list = DanjuTableService.GetDanjuTablelst(x => x.dh.Contains(danjuleixing) && x.rq  >= dateTime.Date&&x.rq <=dateTime.Date.AddDays (1) && x.djlx == lx).OrderBy(x => x.id).ToList();
                if (list.Count > 0)
                {
                    var bh = (int.Parse(list[list.Count - 1].dh.Substring(list[list.Count - 1].dh.Length - 3, 3)) + 1);
                    var dh = danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + bh.ToString();
                    while (!string.IsNullOrEmpty(DanjuTableService.GetOneDanjuTable(x => x.dh == dh).dh))
                    {
                        bh++;
                        dh = danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + bh.ToString();
                    }
                    return dh;
                }
                else
                {

                    return danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + "101";
                }
            }
            else
            {
                var date = new DateTime(DateTime.Now.Year, 1, 1);
                var list = DanjuTableService.GetDanjuTablelst(x => x.rq >= date.Date&&x.djlx ==lx).OrderByDescending(x => x.id).ToList();
                if (list.Count == 0)
                {
                    return danjuleixing + date.Year.ToString() + "00001";
                }
                else
                {
                    return danjuleixing + date.Year.ToString() + string.Format("{0:00000}", int.Parse(list[0].dh.Substring(list[0].dh.Length - 5, 5)) + 1);
                }
            }
            }
        /// <summary>
        /// 创建订单号
        /// </summary>
        /// <param name="danjuleixing"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string CreatOrderNum(string danjuleixing,DateTime dateTime )
        {
            if (QueryTime.DanjubianhaoRule == "类型+年份+月份+日+累计编号")
            {
                if (系统设定.GetSet(new Model.Setting() { formname = "", settingname = "编号规则", settingValue = "按日期时间" }).settingValue == "按日期时间")
                {
                    var danhao = danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
                    danhao += DateTime.Now.Second.ToString();
                    return danhao;
                }
                else
                {
                    var orderlist = OrderTableService.GetOrderTablelst($"select * from ordertable where orderDate between '{dateTime}' and '{dateTime.AddDays(1)}' order by OrderNum asc");
                    if (orderlist.Count > 0)
                    {
                        var ordernum = danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day);
                        var num =(orderlist[orderlist.Count - 1].OrderNum.Substring(orderlist[orderlist.Count - 1].OrderNum.Length - 3)).TryToInt();
                        num++;
                        ordernum +=String .Format ("{0:000}",num ) ;
                        return ordernum;
                    }
                    else
                    {
                        return danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + "101";
                    }
                }
            }
            else
            {
                var date = new DateTime(DateTime.Now.Year, 1, 1);
                var list = OrderTableService.GetOrderTablelst(x => x.Orderdate >= date.Date).OrderByDescending(x => x.ID).ToList();
                if (list.Count == 0)
                {
                    return danjuleixing + date.Year.ToString() + "00001";
                }
                else
                {
                    return danjuleixing + date.Year.ToString() + string.Format("{0:00000}", int.Parse(list[0].OrderNum .Substring(list[0].OrderNum .Length - 5, 5)) + 1);
                }
            }
        }
        /// <summary>
        /// 创建一卷号
        /// </summary>
        /// <returns></returns>
        public static string CreatJuanhao(string ganghao,string pihao)
        {
            var danhao = "JH" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            danhao += DateTime.Now.Second.ToString() + ganghao +pihao ;
            return danhao;
        }
        /// <summary>
        /// 创建色号
        /// </summary>
        /// <returns></returns>
        public static string CreatSeHao()
        {
            var dt = SQLHelper.SQLHelper.Chaxun("select id,ColorNum from ColorTable order by id desc");
            if (dt.Rows.Count == 0)
            {
                return "100001";
            }
            else
            {
                var bh = dt.Rows[0]["ID"].ToString();
                bh = (Convert.ToInt32(bh) + 100001).ToString();
                return  bh;
            }
        }
        /// <summary>
        /// 创建收款方式编号
        /// </summary>
        /// <returns></returns>
        public static string CreatShouKuangFangshiBianhao()
        {
            var dt = SQLHelper.SQLHelper.Chaxun("select* from skfs order by id desc");
            if (dt.Rows.Count == 0)
            {
                return "100001";
            }
            else
            {
                var bh = dt.Rows[0]["ID"].ToString();
                bh = (Convert.ToInt32(bh) + 100001).ToString();
                return bh;
            }
        }
        /// <summary>
        /// 创建流转卡号
        /// </summary>
        /// <param name="danjuleixing"></param>
        /// <param name="dateTime"></param>
        /// <param name="lx"></param>
        /// <returns></returns>
        public static string CreateLiuzhuanKahao(string danjuleixing, DateTime dateTime)
        {
            var list = LiuzhuancardService .GetLiuzhuancardlst  (x => x.Card_Date  == dateTime.Date).OrderBy(x =>x.ID ).ToList();
            if (list.Count > 0)
            {
                var bh = (int.Parse(list[list.Count - 1].CardNum .Substring(list[list.Count - 1].CardNum .Length - 3, 3)) + 1);
                return danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) +string.Format ("{0:000}", bh);
            }
            else
            {
                //if (list[0].dh == string.Empty)
                //{
                return danjuleixing + dateTime.Year.ToString().Substring(2, 2) + string.Format("{0:00}", dateTime.Month) + string.Format("{0:00}", dateTime.Day) + "001";
                //}
                //else
                //{
                //    return danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "102";
                //}
            }
            //var danhao = danjuleixing + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString();
            //danhao += DateTime.Now.Second.ToString() + userid;
            //return danhao;          
        }
        /// <summary>
        /// 创建架子编号
        /// </summary>
        /// <returns></returns>
        public static string CreatJiaziBianhao()
        {
            var dt = SQLHelper.SQLHelper.Chaxun("select jiaziID from jiazitable order by id desc");
            if(dt.Rows .Count ==0)
            {
                return "0001";
            }
            else
            {
              return  string.Format ("{0:0000}", dt.Rows[0]["jiaziID"].TryToInt() + 1);
            }
            
        }
        public static string CreatWuliuBianhao()
        {
            var dt = Connect.DbHelper().Queryable<WuliuTable>().ToList().OrderByDescending(x => x.id).ToList(); ;
            if (dt.Count  == 0)
            {
                return "WL100001";
            }
            else
            {
                var bh = dt[0].Bianhao ;
                bh = bh.Substring(bh.Length - 2);
                bh = (Convert.ToInt32(bh) + 100001).ToString();
                return "WL"+ bh;
            }
        }
    }
}

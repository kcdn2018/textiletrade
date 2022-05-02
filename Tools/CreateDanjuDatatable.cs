using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
   public static  class CreateDanjuDatatable
    {

        /// <summary>
        /// 把单据实例转换成打印单据DataTable
        /// </summary>
        /// <param name="danju">单据信息</param>
        /// <returns>Datatable</returns>
        public static DataTable DanjuConvertToDatatable(DanjuTable danju)
        {
            var dt = new DataTable("单据信息");
            dt.Columns.Add("单号",typeof (string));
            dt.Columns.Add("客商名称",typeof (string));
            dt.Columns.Add("日期",typeof (DateTime));
            dt.Columns.Add("联系人", typeof(string));
            dt.Columns.Add("联系电话", typeof(string));
            dt.Columns.Add("物流公司", typeof(string));
            dt.Columns.Add("车牌号", typeof(string));
            dt.Columns.Add("合计卷数", typeof(decimal));
            dt.Columns.Add("运费", typeof(decimal));
            dt.Columns.Add("合计米数", typeof(decimal));
            dt.Columns.Add("运单号", typeof(string));
            dt.Columns.Add("备注", typeof(string));
            dt.Columns.Add("收货地址", typeof(string));
            dt.Columns.Add("合计金额", typeof(decimal));
            dt.Columns.Add("发货地址", typeof(string));
            dt.Columns.Add("加工类型", typeof(string));
            dt.Columns.Add("加工要求", typeof(string));
            dt.Rows.Add();
            dt.Rows [0][0] = danju.dh;
            dt.Rows[0][1] = danju.ksmc ;
            dt.Rows[0][2] = danju.rq ;
            dt.Rows[0][3] = danju.lianxiren ;
            dt.Rows[0][4] = danju.lianxidianhua ;
            dt.Rows[0][5] = danju.wuliugongsi ;
            dt.Rows[0][6] = danju.CarNum ;
            dt.Rows[0][7] = danju.totaljuanshu ;
            dt.Rows[0][8] = danju.yunfei  ;
            dt.Rows[0][9] = danju.TotalMishu ;
            dt.Rows[0][10] = danju.wuliuBianhao;
            dt.Rows[0][11] = danju.bz;
            dt.Rows[0][12] = danju.shouhuodizhi ;
            dt.Rows[0][13] = danju.je ;
            dt.Rows[0][14] = danju.ckmc;
            dt.Rows[0][15] = danju.djlx ;
            dt.Rows[0][16] = danju.yaoqiu ;
            return dt;
        }
        /// <summary>
        /// 把实例转换成Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="danjuTable">实例名称</param>
        /// <param name="formInfo">窗体信息</param>
        /// <param name="dtname">返回的Datatable的名称</param>
        /// <returns>name是dtname的一个Datable</returns>
        public static DataTable CreateTable<T>(T  danjuTable,FormInfo formInfo,string dtname,string gsmc )
        {
            DataTable dt = new DataTable(dtname );
            var clist = Connect.GetColumntable(formInfo.FormName ,formInfo.GridviewName  , "10001");
            var pros = danjuTable.GetType().GetProperties();
            foreach(var c in clist  )
            {
                try
                {
                    //var t = pros.Where(x => x.Name == c.DataProperty).ToList()[0];
                    dt.Columns.Add(c.ColumnText );
                }
                catch
                {

                }
            }
            dt.Columns.Add("用户公司名称");
            dt.Columns.Add("用户公司电话");
            dt.Columns.Add("公司税号");
            dt.Columns.Add("公司地址");
            dt.Columns.Add("开户银行");
            dt.Columns.Add("银行账号");
            dt.Columns.Add("电子邮箱");
            dt.Rows.Add();
            try
            {
                foreach (var c in clist)
                {
                    var prolist = pros.Where(x => x.Name.ToLower() == c.DataProperty.ToLower ()).ToList ();
                    if (prolist.Count > 0)
                    {
                        dt.Rows[0][c.ColumnText] = prolist[0].GetValue(danjuTable, null);
                    }
                }
            }
            catch
            { }
            info gsinfo = new info();
            if(string.IsNullOrEmpty (gsmc))
            {
                gsinfo = infoService.Getinfolst()[0];
            }
            else
            {
                 gsinfo = infoService.GetOneinfo(x => x.gsmc == gsmc);
            }
            
            dt.Rows[0]["用户公司名称"] = gsinfo.gsmc;
            dt.Rows[0]["用户公司电话"] = gsinfo.GHSMC ;
            dt.Rows[0]["公司税号"] = gsinfo.TaxNum ;
            dt.Rows[0]["公司地址"] = gsinfo.Address;
            dt.Rows[0]["开户银行"] = gsinfo.BankName ;
            dt.Rows[0]["银行账号"] = gsinfo.BankNum ;
            dt.Rows[0]["电子邮箱"] = gsinfo.Email;
            return dt;
        }
        /// <summary>
        /// 把集合转换成Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mx">要转换的集合</param>
        /// <param name="formInfo">窗体信息</param>
        /// <returns></returns>
        public static DataTable CreateTable<T>(List<T> mx, FormInfo formInfo) where T:new ()
        {
            DataTable dt = new DataTable("单据明细");
            var clist = Connect.GetColumntable(formInfo.FormName, formInfo.GridviewName, "10001");
            T t=new T();
            var pros = t.GetType().GetProperties();
            foreach (var c in clist)
            {           
                    dt.Columns.Add(c.ColumnText);           
            }
            int row = 0;
            foreach (var m in mx)
            {
                dt.Rows.Add();
                foreach (var c in clist)
                {
                    dt.Rows[row][c.ColumnText] = pros.Where(x => x.Name == c.DataProperty).ToList()[0].GetValue(m, null);
                }
                row++;
            }
            return dt;
        }
        /// <summary>
        /// 把集合转换成Datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mx">要转换的集合</param>
        /// <param name="formInfo">窗体信息</param>
        /// <param name="dtname">datatable名称</param>
        /// <returns></returns>
        public static DataTable CreateTable<T>(List<T> mx, FormInfo formInfo,string dtname) where T : new()
        {
            DataTable dt = new DataTable(dtname );
            var clist = Connect.GetColumntable(formInfo.FormName, formInfo.GridviewName, "10001");
            T t = new T();
            var pros = t.GetType().GetProperties();
            foreach (var c in clist)
            {
                try
                {
                    dt.Columns.Add(c.ColumnText, pros.Where(x => x.Name == c.DataProperty).ToList()[0].PropertyType );
                }
                catch
                { }
            }
            int row = 0;
            foreach (var m in mx)
            {
                dt.Rows.Add();
                foreach (var c in clist)
                {
                    dt.Rows[row][c.ColumnText] = pros.Where(x => x.Name == c.DataProperty).ToList()[0].GetValue(m, null);
                }
                row++;
            }
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统;

namespace Model
{
    public class ShippingMark
    {
        public string 订单号 { get; set; }
        public string 缸号 { get; set; }
        public string 卷号 { get; set; }
        public string 合同号 { get; set; }
        public decimal 毛米数 { get; set; }
        public string 品名 { get; set; }
        public string 规格 { get; set; }
        public string 门幅 { get; set; }
        public string 克重 { get; set; }
        public string 颜色 { get; set; }
        public DateTime 日期 { get; set; }
        public string 成分 { get; set; }
        public string 单位 { get; set; }
        public string 缸卷 { get; set; }
        public string 等级 { get; set; }
        public string 备注 { get; set; }
        public decimal 码数 { get; set; }
        public decimal 净米数 { get; set; }
        public decimal 净码数 { get; set; }
        public decimal 合计扣米数 { get; set; }
        public string 款号 { get; set; }
        public string 后整理 { get; set; }
        public string 英文名 { get; set; }
        public string 客户品名 { get; set; }
        public string 客户色号 { get; set; }
        public string 色号 { get; set; }
        public string 花号 { get; set; }
        public string 布料编号 { get; set; }
        public string 检验员 { get; set; }
        public string 疵点 { get; set; }
        public string 条码信息 { get; set; }
        public string 客户缸号 { get; set; }
        public string 客户名称 { get; set; }
        public string 英文单位 { get; set; }
        public static DataTable CreateShippingDatatable(JuanHaoTable juan,int JuanhaoLen)
        {
            DataTable dt = new DataTable("唛头信息");
            var pros = new ShippingMark().GetType().GetProperties();
            foreach (var pro in pros)
            {
                dt.Columns.Add(pro.Name);
            }
            dt.Rows.Add();          
            dt.Rows[0]["订单号"] = juan.OrderNum;
            dt.Rows[0]["缸号"] = juan.GangHao;
            dt.Rows[0]["卷号"] = juan.JuanHao;
            dt.Rows[0]["合同号"] = juan.Hetonghao;
            dt.Rows[0]["毛米数"] = juan.MiShu.ToString("N1");
            dt.Rows[0]["品名"] = juan.SampleName;
            dt.Rows[0]["规格"] = juan.guige;
            dt.Rows[0]["门幅"] = juan.Menfu;
            dt.Rows[0]["克重"] = juan.Kezhong;
            dt.Rows[0]["颜色"] = juan.yanse;
            dt.Rows[0]["日期"] = juan.rq;
            dt.Rows[0]["成分"] = string.Empty;
            dt.Rows[0]["单位"] = juan.Danwei;
            string s = "{0:";
            for (int i = 0; i < JuanhaoLen; i++)
            {
                s += "0";
              }
            s += "}";
            dt.Rows[0]["缸卷"] =string.Format (s, juan.PiHao);
            dt.Rows[0]["等级"] = juan.DengJI;
            dt.Rows[0]["备注"] =juan.SumKouFeng ==0?juan.biaoqianmishu.ToString ():juan.biaoqianmishu .ToString ()+"+"+juan.SumKouFeng .ToString ();
            dt.Rows[0]["码数"] = (juan.biaoqianmishu / (decimal)0.9144).ToString();
            dt.Rows[0]["净米数"] =juan.biaoqianmishu .ToString ();
            dt.Rows[0]["净码数"] = (juan.biaoqianmishu / (decimal)0.9144).ToString();
            dt.Rows[0]["合计扣米数"] = juan.SumKouFeng.ToString("N1");
            dt.Rows[0]["款号"] = juan.kuanhao;
            dt.Rows[0]["后整理"] = juan.Houzhengli;
            dt.Rows[0]["英文名"] = juan .EnglishName;
            dt.Rows[0]["客户品名"] = juan.CustomerPingMing;
            dt.Rows[0]["客户色号"] = juan.CustomerColorNum;
            dt.Rows[0]["色号"] = juan.ColorNum;
            dt.Rows[0]["条码信息"] = juan.CustomerPingMing + juan.yanse + juan.OrderNum + string.Format("{0:000.00}", juan.biaoqianmishu).Replace(".", "") + juan.GangHao + string.Format("{0:000}", juan.PiHao);
            dt.Rows[0]["疵点"] = juan.Cidian;
            dt.Rows[0]["花号"] = juan.Huahao;
            dt.Rows[0]["布料编号"] = juan.SampleNum;
            dt.Rows[0]["客户名称"] = juan.CustomerName;
            dt.Rows[0]["检验员"] = juan.CheckID;
            dt.Rows[0]["客户缸号"] = juan.CustomerLotNo;
           switch (juan.Danwei )
            {
                case "米":
                    dt.Rows[0]["英文单位"] ="M";
                    break;
                case "码":
                    dt.Rows[0]["英文单位"] = "Y";
                    break;
                case "公斤":
                    dt.Rows[0]["英文单位"] = "KG";
                    break;
            }
            // try
            // {
            //     var jinmishu = juan.biaoqianmishu.ToString().Split('.');
            //     var res = juan.CustomerPingMing;
            //     res += juan .yanse;
            //     res += juan .OrderNum;
            //     res += String.Format("{0:000.00}", juan.biaoqianmishu.ToString().Replace(".", "");
            //     res += juan.GangHao;
            //     res += String.Format("{0:000}", juan.PiHao);
            // juan .条码信息 = res
            //maitou.毛米数 = FormatNumber(CDec(maitou.净米数) + CDec(maitou.合计扣米数), Setting.Decimal_digits)
            //         }
            // catch (Exception ex)
            // {
            //     MessageBox.Show("生成条码信息的时候发送错误！");
            //}
            return dt;
        }
    }
}

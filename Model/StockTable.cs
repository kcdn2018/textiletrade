using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
namespace 纺织贸易管理系统
{
    public class StockTable
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string BH { get; set; }
        public string PM { get; set; }
        public string GG { get; set; }
        public string CF { get; set; }
        public string KZ { get; set; }
        public string MF { get; set; }
        public string YS { get; set; }
        public decimal  JS { get; set; }
        public decimal  MS { get; set; }
        public string GH { get; set; }
        public string CKMC { get; set; }
        /// <summary>
        /// 布料最后一次来源
        /// </summary>
        public string RKDH { get; set; }
        public DateTime RQ { get; set; }
        public string own { get; set; }
        public decimal  biaoqianmishu { get; set; }
        public decimal  yijianmishu { get; set; }
        public decimal  kaijianmishu { get; set; }
        public decimal  yijianjuanshu { get; set; }
        public string kuanhao { get; set; }
        public string houzhengli { get; set; }
        public string orderNum { get; set; }
        public decimal  AvgPrice { get; set; }
        public decimal  TotalMoney { get; set; }
        public string Kuwei { get; set; }
        public string CustomName { get; set; }
        public string ContractNum { get; set; }
        public string Huahao { get; set; }
        public string ColorNum { get; set; }
        public string CustomerPingMing { get; set; }
        /// <summary>
        /// 染厂
        /// </summary>
        public string Rangchang { get; set; }
        /// <summary>
        /// 客户色号
        /// </summary>
        public string CustomerColorNum { get; set; }
        /// <summary>
        /// 流转卡卡号
        /// </summary>
        public string LiuzhuanCard { get; set; }
        /// <summary>
        /// 入库米数
        /// </summary>
        public System.Decimal RukuNum { get; set; }
        /// <summary>
        /// 已发货数量
        /// </summary>
        public System.Decimal YiFaNum { get; set; }
        /// <summary>
        /// 是否检验完毕
        /// </summary>
        public System.String IsCheckDone { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public System.String Pihao { get; set; }
        /// <summary>
        /// 坯布厂
        /// </summary>
        public System.String PibuChang { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public System.String Remarkers { get; set; }
    }
}

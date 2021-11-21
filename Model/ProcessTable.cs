using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class ProcessTable
     {
        /// <summary>
        /// 单号
        /// </summary>
        public string receiptnum { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNum { get; set; }
        public string sampleNum { get; set; }
        public string sampleName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 成分
        /// </summary>
        public string Component { get; set; }
        public string weight { get; set; }
        public string width { get; set; }
        public string color { get; set; }
        public decimal  price { get; set; }
        public string Currency { get; set; }
        public decimal  Num { get; set; }
        public decimal  Volumn { get; set; }
        public decimal  Code { get; set; }
        public decimal  Kg { get; set; }
        public string Unit { get; set; }
        public decimal  Total { get; set; }
        public string Remarkers { get; set; }
        /// <summary>
        /// 缸号
        /// </summary>
        public string Dyelot { get; set; }
        public string supplierNum { get; set; }
        public string supplierName { get; set; }
        public string Fhdd { get; set; }
        public DateTime rq { get; set; }
        public string rax { get; set; }
        public decimal  TotalNum { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string logisticsName { get; set; }
        public decimal  Freight { get; set; }
        public decimal  TotalMoney { get; set; }
        public decimal  TotalVolumn { get; set; }
        public decimal  TotalWeiShuiMoney { get; set; }
        public decimal  remainNum { get; set; }
        public decimal  RemainVolumn { get; set; }
        public string TelphoneNum { get; set; }
        public string Documenttype { get; set; }
        public string MachineType { get; set; }
        public string SampleRemarkers { get; set; }
        public string own { get; set; }
        public string zhuangtai { get; set; }
        public string FromDanhao { get; set; }
        public string Huahao { get; set; }
     }
}

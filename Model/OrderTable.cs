using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class OrderTable
     {
        public string OrderNum { get; set; }
        public DateTime Orderdate { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerName { get; set; }
        public decimal  SumMoney { get; set; }
        public bool Rax { get; set; }
        public string Remakers { get; set; }
        public string ContractNum { get; set; }
        public string  state { get; set; }
        public decimal  Deposit { get; set; }
        public DateTime delivery { get; set; } = DateTime.Now;
        public decimal  Cost { get; set; }
        public string MoneyType { get; set; }
        public string own { get; set; }
        public decimal  ShengYuMoney { get; set; }
        public decimal  YifuMoney { get; set; }
        public decimal  HejiLilun { get; set; }
        public decimal  FaHuoMoney { get; set; }
        public string Yaoqiu { get; set; }
        public string GengDanyuan { get; set; }
        public string DayangFei { get; set; }
        public string XiaogangFei { get; set; }
        public string ShengHe { get; set; }
        public string SaleMan { get; set; }
        public decimal  TotalNum { get; set; }
        public decimal ZhibanFei { get; set; }
        /// <summary>
        /// 交货地址
        /// </summary>
        public string JiaohuoAddress { get; set; }
        /// <summary>
        /// 客户地址
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// 需方邮箱
        /// </summary>
        public string NeedEmail { get; set; }
        /// <summary>
        /// 供方邮箱
        /// </summary>
        public string SuppertEmail { get; set; }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string JiesuanStyle { get; set; }
        /// <summary>
        /// 有拼色
        /// </summary>
        public string HavePingColor { get; set; }
        /// <summary>
        /// 无拼色
        /// </summary>
        public string NoPingColor { get; set; }
    }
}

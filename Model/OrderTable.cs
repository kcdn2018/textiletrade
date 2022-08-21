using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class OrderTable
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string OrderNum { get; set; }
        public DateTime Orderdate { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerName { get; set; }
        public decimal  SumMoney { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public bool Rax { get; set; }
        public string Remakers { get; set; }
        public string ContractNum { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string  state { get; set; }
        /// <summary>
        /// 定金
        /// </summary>
        public decimal  Deposit { get; set; }
        /// <summary>
        /// 交期
        /// </summary>
        public DateTime delivery { get; set; } = DateTime.Now;
        /// <summary>
        /// 费用
        /// </summary>
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
        /// <summary>
        /// 业务员
        /// </summary>
        public string SaleMan { get; set; }
        public decimal  TotalNum { get; set; }
        /// <summary>
        /// 制版费
        /// </summary>
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
        /// <summary>
        /// 结汇汇率
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 范围起始
        /// </summary>
        public int Scopefrom { get; set; }
        /// <summary>
        /// 范围截止
        /// </summary>
        public int ScopeEnd { get; set; }
        /// <summary>
        /// 装船日期
        /// </summary>
        public DateTime ShipmentTime { get; set; }
        /// <summary>
        /// 出海缸号
        /// </summary>
        public string  LoadingPort { get; set; }
        /// <summary>
        /// 签约公司
        /// </summary>
        public string SignCompany  { get; set; }
        /// <summary>
        /// 客户全称
        /// </summary>
        public string CustomerFullName { get; set; }
        /// <summary>
        /// FOB
        /// </summary>
        public string FOB { get; set; }
        /// <summary>
        /// 签约地址
        /// </summary>
        public string SignAddress { get; set; }
    }
}

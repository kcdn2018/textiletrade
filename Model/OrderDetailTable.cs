using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class OrderDetailTable
     {   
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// ID编号  自动增加列
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNum { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string sampleNum { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string sampleName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specifications { get; set; }
        /// <summary>
        /// 成分
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 克重
        /// </summary>
        public string weight { get; set; }
        /// <summary>
        /// 门幅
        /// </summary>
        public string width { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal  price { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal  Num { get; set; }
        /// <summary>
        /// 码数
        /// </summary>
        public decimal  Code { get; set; }
        /// <summary>
        /// 公斤数
        /// </summary>
        public decimal  Kg { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        public decimal  Total { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarkers { get; set; }
        /// <summary>
        /// 已发米数
        /// </summary>
        public decimal  consignmentNum { get; set; }
        public string own { get; set; }
        /// <summary>
        /// 款号
        /// </summary>
        public string Kuanhao { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string danwei { get; set; }
        /// <summary>
        /// 花号
        /// </summary>
        public string Huahao { get; set; }
        /// <summary>
        /// 色号
        /// </summary>
        public string ColorNum { get; set; }
       /// <summary>
       /// 客户品名
       /// </summary>
        public string CustomerPingMing { get; set; }
        /// <summary>
        /// 客户色号
        /// </summary>
        public string CustomerColorNum { get; set; }
        /// <summary>
        /// 预投米数
        /// </summary>
        public decimal YutouMishu { get; set; }
        /// <summary>
        /// 已投米数
        /// </summary>
        public decimal Yitoumishu { get; set; }
        /// <summary>
        /// 剩余需投米数
        /// </summary>
        public decimal Shengyumishu { get; set; }
        /// <summary>
        /// 其它费用
        /// </summary>
        public decimal OtherCost { get; set; }
        /// <summary>
        /// 费用类型
        /// </summary>
        public string OtherCostStyle { get; set; }
        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime Jiaohuoriqi { get; set; } = DateTime.Now.AddDays(10);
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 库存米数
        /// </summary>
        public decimal StockNum { get; set; }
        /// <summary>
        /// 加工厂米数
        /// </summary>
        public decimal JiaGongchangNum { get; set; }
        /// <summary>
        /// 染厂米数
        /// </summary>
        public decimal RanChangNum { get; set; }
        /// <summary>
        /// 后整理厂库存
        /// </summary>
        public decimal HouzhengliStockNum { get; set; }
    }
}

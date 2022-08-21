using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class ShengchanBuliaoInfo
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string BuliaoPingming { get; set; }
        public string Yanse { get; set; }
        public string Kuanhao { get; set; }
        public decimal  ChengpingMishu { get; set; }
        public decimal  YutouMishu { get; set; }
        public decimal  PibuPlaneNum { get; set; }
        public string ShengChanDanhao { get; set; }
        public DateTime PeiTongDate { get; set; }
        public string Kahao { get; set; }
        public decimal  PeitongPishu { get; set; }
        public decimal  PeitongMishu { get; set; }
        public decimal  ChengpingJuanshu { get; set; }
        public string Suolv { get; set; }
        public DateTime Jiaoqi { get; set; }
        /// <summary>
        /// 色号
        /// </summary>
        public string ColorNum { get; set; }
        /// <summary>
        /// 对色光源
        /// </summary>
        public string DuiSeGuangYuan { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string SampleNum { get; set; }
        /// <summary>
        /// 克重
        /// </summary>
        public string Kezhong { get; set; }
        /// <summary>
        /// 门幅
        /// </summary>
        public string Menfu { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Danwei { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarker { get; set; }
        /// <summary>
        /// 坯布单价
        /// </summary>
        public decimal  FricePrice { get; set; }
        /// <summary>
        /// 坯布单位
        /// </summary>
        public string FriceUnit { get; set; }
        /// <summary>
        /// 船样日期
        /// </summary>
        public string ShippingDate { get; set; }
        /// <summary>
        /// 预计出货日
        /// </summary>
        public string SellDate { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState { get; set; }
        /// <summary>
        /// 生产状态
        /// </summary>
        public string ProduceSate { get; set; }
    }
}

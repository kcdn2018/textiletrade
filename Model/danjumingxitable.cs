using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
namespace 纺织贸易管理系统
{
    public class danjumingxitable
     {
        /// <summary>
        /// 自增列
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string danhao { get; set; }
        public string Bianhao { get; set; }
        public string pingming { get; set; }
        public string guige { get; set; }
        public string chengfeng { get; set; }
        public string kezhong { get; set; }
        public string menfu { get; set; }
        public string yanse { get; set; }
        /// <summary>
        /// 缸号
        /// </summary>
        public string ganghao { get; set; }
        public string suilv { get; set; }
        /// <summary>
        /// 含税单价
        /// </summary>
        public decimal  hanshuidanjia { get; set; }
        /// <summary>
        /// 未税单价
        /// </summary>
        public  decimal   weishuidanjia { get; set; }
        public decimal  toupimishu { get; set; }
        public decimal  toupijuanshu { get; set; }
        /// <summary>
        /// 成品米数
        /// </summary>
        public decimal  chengpingmishu { get; set; }
        public decimal  chengpingjuanshu { get; set; }
        public decimal  suolv { get; set; }
        /// <summary>
        /// 含税合计
        /// </summary>
        public decimal  hanshuiheji { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>   
        public decimal  weishuiheji { get; set; }
        public string beizhu { get; set; }
        public string Chengpingyanse { get; set; }
        public string kuanhao { get; set; }
        public string houzhengli { get; set; }
        public decimal  mashu { get; set; }
        public decimal  gongjingshu { get; set; }
        public string danwei { get; set; }
        public string bizhong { get; set; }
        public string rkdh { get; set; }
        public string offerid { get; set; }
        public DateTime rq { get; set; }
        public string Kuwei { get; set; }
        public string OrderNum { get; set; }
        public string CustomName { get; set; }
        public string ContractNum { get; set; }
        public string Huahao { get; set; }
        public string ColorNum { get; set; }
        public string CustomerPingMing { get; set; }
        public string CustomerColorNum { get; set; }
        /// <summary>
        /// 是否含税
        /// </summary>
        public string  IsHanshui { get; set; }
        /// <summary>
        /// 平均单价
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 品质样
        /// </summary>
        public string  PingzhiYang { get; set; }
        /// <summary>
        /// 取走时间
        /// </summary>
        public string QuzhouDate { get; set; }
        /// <summary>
        /// 染厂
        /// </summary>
        public string Rangchang { get; set; }
        /// <summary>
        /// 坯布厂
        /// </summary>
        public string PiBuChang { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string Pihao { get; set; }
        /// <summary>
        /// 成本
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public decimal Profit { get; set; }
        /// <summary>
        /// 坯布门幅
        /// </summary>
        public string  FrabicWidth { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnglishName { get; set; }
        /// <summary>
        /// 坯布名称
        /// </summary>
        public string PibuName { get; set; }
        /// <summary>
        /// 采购或者加工单价
        /// </summary>
        public decimal BuyPrice { get; set; }
        /// <summary>
        /// 采购或者加工合计
        /// </summary>
        public decimal TotalBuy { get; set; }
    }
}

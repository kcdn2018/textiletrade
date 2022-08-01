using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class RangShequpiTable
     {
        public string DocumentNum { get; set; }
        public string SampleNum { get; set; }
        public string sampleName { get; set; }
        public string Specifications { get; set; }
        public decimal  ToupiMishu { get; set; }
        public decimal  ToupiJuanshu { get; set; }
        public string chengfeng { get; set; }
        public string kezhong { get; set; }
        public string menfu { get; set; }
        public string CaigouDanhao { get; set; }
        public DateTime riqi { get; set; }
        public string FactoryName { get; set; }
        public string FactoryNum { get; set; }
        public string Remarkers { get; set; }
        public string SampleRemarks { get; set; }
        public string OrderNum { get; set; }
        public string color { get; set; }
        public string ganghao { get; set; }
        public string kuanhao { get; set; }
        public string houzhengli { get; set; }
        public string rkdh { get; set; }
        public decimal  Danjia { get; set; }
        public decimal  Heji { get; set; }
        public string CustomName { get; set; }
        public string ContractNum { get; set; }
        public string Huahao { get; set; }
        public string ColorNum { get; set; }
        public string CustomerPingMing { get; set; }
        public string CustomerColorNum { get; set; }
        /// <summary>
        /// 平均价格
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public System.String Pihao { get; set; }
        /// <summary>
        /// 坯布厂
        /// </summary>
        public System.String PibuChang { get; set; }
        /// <summary>
        /// 坯布门幅
        /// </summary>
        public string FrabicWidth { get; set; }
        /// <summary>
        /// 剩余米数
        /// </summary>
        public decimal RemainingMetres { get; set; }
        public string EnglishName { get; set; }
    }
}

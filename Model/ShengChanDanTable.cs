using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class ShengChanDanTable
     {
        public string shengchandanhao { get; set; }
        public DateTime riqi { get; set; }
        public DateTime jiaohuoriqi { get; set; }
        public string OrderNum { get; set; }
        public string Hetonghao { get; set; }
        public decimal  Hejimishu { get; set; }
        public decimal  hejiyutoumishu { get; set; }
        /// <summary>
        /// 布料来源
        /// </summary>
        public string SampleFrom { get; set; }
        /// <summary>
        /// 跟单员
        /// </summary>
        public string Genduanyuan { get; set; }
        /// <summary>
        /// 下单员
        /// </summary>
        public string Xiadanyuan { get; set; }
        /// <summary>
        /// 加工厂
        /// </summary>
        public string Jiagongchang { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 开单人
        /// </summary>
        public string own { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
    }
}

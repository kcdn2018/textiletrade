using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class Liuzhuancard
     {
        public int ID { get; set; }
        public string CardNum { get; set; }
        public DateTime Card_Date { get; set; }
        public string Customer { get; set; }
        public string Pingming { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Guige { get; set; }
        public string Menfu { get; set; }
        public string Kezhong { get; set; }
        public string Color { get; set; }
        public decimal  Shuliang { get; set; }
        public string Ganghao { get; set; }
        public string Beizhu { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string own { get; set; }
    }
}

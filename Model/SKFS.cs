using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class SKFS
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string BH { get; set; }
        public string Skfs { get; set; }
        public string ZJC { get; set; }
        public string own { get; set; }
        public string Yinghangzhanghao { get; set; }
        public string Kaihuren { get; set; }
        public decimal Zhanghuyue { get; set; }
        public string Kaihuyinghang { get; set; }
    }
}

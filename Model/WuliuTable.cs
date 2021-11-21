using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class WuliuTable
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        public string Bianhao { get; set; }
        public string CarLeixing { get; set; }
        public string CarNum { get; set; }
        public string name { get; set; }
     }
}
